SET search_path TO hms_schema;

-- 1. 只允许 hmsuser 登录态  禁止修改/删除/创建 system role，禁止普通 role 没有 home_id
-- ====================================================================`

-- (1) 禁止 hmsuser 修改 system role(0)，或把普通role改为system role
CREATE OR REPLACE FUNCTION trg_bu_roles_cannot_modify_system_role()
RETURNS TRIGGER AS $$
DECLARE
    user_name text;
BEGIN
    user_name := CURRENT_USER;  -- 与 MySQL 的SESSION_USER类似

    IF user_name = 'hmsuser' AND (OLD.role_type = 0 OR NEW.role_type = 0) THEN
        RAISE EXCEPTION 'This user cannot modify system role or change a custom role to system role';
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER appuser_can_not_modify_system_role
BEFORE UPDATE ON roles
FOR EACH ROW EXECUTE FUNCTION trg_bu_roles_cannot_modify_system_role();

-- (2) 禁止 hmsuser 删除 system role(0)
CREATE OR REPLACE FUNCTION trg_bd_roles_cannot_delete_system_role()
RETURNS TRIGGER AS $$
DECLARE
    user_name text;
BEGIN
    user_name := CURRENT_USER;

    IF user_name = 'hmsuser' AND OLD.role_type = 0 THEN
        RAISE EXCEPTION 'This user cannot delete system role';
    END IF;

    RETURN OLD;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER appuser_can_not_delete_system_role
BEFORE DELETE ON roles
FOR EACH ROW EXECUTE FUNCTION trg_bd_roles_cannot_delete_system_role();

-- (3) 禁止 hmsuser 创建 system role(0)
CREATE OR REPLACE FUNCTION trg_bi_roles_cannot_create_system_role()
RETURNS TRIGGER AS $$
DECLARE
    user_name text;
BEGIN
    user_name := CURRENT_USER;

    IF user_name = 'hmsuser' AND NEW.role_type = 0 THEN
        RAISE EXCEPTION 'This user cannot create a system role';
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER appuser_can_not_create_system_role
BEFORE INSERT ON roles
FOR EACH ROW EXECUTE FUNCTION trg_bi_roles_cannot_create_system_role();

-- (4) 普通role（role_type != 0）必须传home_id
CREATE OR REPLACE FUNCTION trg_bi_roles_create_non_system_role_must_have_home()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.role_type != 0 AND NEW.home_id IS NULL THEN
        RAISE EXCEPTION 'home_id must be provided when is not a system role';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER create_nonsystem_role_must_in_a_home
BEFORE INSERT ON roles
FOR EACH ROW EXECUTE FUNCTION trg_bi_roles_create_non_system_role_must_have_home();

-- (5) 修改普通role（role_type != 0）必须有home_id
CREATE OR REPLACE FUNCTION trg_bu_roles_update_non_system_role_must_have_home()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.role_type != 0 AND NEW.home_id IS NULL THEN
        RAISE EXCEPTION 'home_id must be provided when is not a system role';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER update_nonsystem_role_must_in_a_home
BEFORE UPDATE ON roles
FOR EACH ROW EXECUTE FUNCTION trg_bu_roles_update_non_system_role_must_have_home();