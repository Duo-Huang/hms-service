SET search_path TO hms_schema;

-- 2. 通用触发器：自动更新时间戳
-- 创建函数
CREATE OR REPLACE FUNCTION update_updated_at_column()
    RETURNS TRIGGER AS
$$
BEGIN
    NEW.updated_at = NOW();
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- 用于所有表的自动更新时间戳的触发器创建SQL
-- 使用示例: 在建表->所有表后面添加一条
-- EXECUTE FORMAT 来批量追加也可以

-- 3. 创建表

-- homes
CREATE TABLE homes
(
    home_id          SERIAL PRIMARY KEY,
    home_name        VARCHAR(30) NOT NULL,
    home_description VARCHAR(60),
    created_at       TIMESTAMP   NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at       TIMESTAMP   NOT NULL DEFAULT CURRENT_TIMESTAMP
);
COMMENT ON TABLE homes IS 'hms homes';
COMMENT ON COLUMN homes.home_id IS 'primary key';
COMMENT ON COLUMN homes.home_name IS 'home name';
COMMENT ON COLUMN homes.home_description IS 'home description';
COMMENT ON COLUMN homes.created_at IS 'created time';
COMMENT ON COLUMN homes.updated_at IS 'updated time';

-- messages
CREATE TABLE messages
(
    message_id      SERIAL PRIMARY KEY,
    message_type    SMALLINT     NOT NULL,
    message_content VARCHAR(500) NOT NULL,
    payload         JSON         NOT NULL,
    expiration      TIMESTAMP    NOT NULL,
    created_at      TIMESTAMP    NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at      TIMESTAMP    NOT NULL DEFAULT CURRENT_TIMESTAMP
);
COMMENT ON TABLE messages IS 'Home notification messages';
COMMENT ON COLUMN messages.message_id IS 'primary key';
COMMENT ON COLUMN messages.message_type IS '0 - notification, 1 - invitation msg...';
COMMENT ON COLUMN messages.message_content IS 'message content';
COMMENT ON COLUMN messages.payload IS 'extra info';
COMMENT ON COLUMN messages.expiration IS 'expiration time';
COMMENT ON COLUMN messages.created_at IS 'created time';
COMMENT ON COLUMN messages.updated_at IS 'updated time';

-- permissions
CREATE TABLE permissions
(
    permission_id          SERIAL PRIMARY KEY,
    permission_code        VARCHAR(200) NOT NULL UNIQUE,
    permission_description VARCHAR(300) NOT NULL,
    created_at             TIMESTAMP    NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at             TIMESTAMP    NOT NULL DEFAULT CURRENT_TIMESTAMP
);
COMMENT ON TABLE permissions IS 'permissions for roles';
COMMENT ON COLUMN permissions.permission_id IS 'primary key';
COMMENT ON COLUMN permissions.permission_code IS 'format: {module}:{function}:{action}, for example: financial:account:edit; action must be create/edit/view/delete';
COMMENT ON COLUMN permissions.permission_description IS 'permission description';
COMMENT ON COLUMN permissions.created_at IS 'created time';
COMMENT ON COLUMN permissions.updated_at IS 'updated time';

-- roles
CREATE TABLE roles
(
    role_id          SERIAL PRIMARY KEY,
    role_type        SMALLINT    NOT NULL CHECK (role_type IN (0, 1)),
    role_name        VARCHAR(30) NOT NULL,
    role_description VARCHAR(60),
    home_id          INTEGER,
    created_at       TIMESTAMP   NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at       TIMESTAMP   NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT role_name_home_id_unique UNIQUE (role_name, home_id),
    CONSTRAINT roles_homes_home_id_fk FOREIGN KEY (home_id) REFERENCES homes (home_id) ON UPDATE CASCADE ON DELETE CASCADE
);
COMMENT ON TABLE roles IS '';
COMMENT ON COLUMN roles.role_id IS 'primary key';
COMMENT ON COLUMN roles.role_type IS 'system role(0) or custom role(1)';
COMMENT ON COLUMN roles.role_name IS 'role name';
COMMENT ON COLUMN roles.role_description IS 'role description';
COMMENT ON COLUMN roles.home_id IS 'foreign key for homes';
COMMENT ON COLUMN roles.created_at IS 'created time';
COMMENT ON COLUMN roles.updated_at IS 'updated time';

-- role_permissions
CREATE TABLE role_permissions
(
    role_permission_id SERIAL PRIMARY KEY,
    role_id            INTEGER   NOT NULL,
    permission_id      INTEGER   NOT NULL,
    created_at         TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at         TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT role_id_permission_id_unique UNIQUE (role_id, permission_id),
    CONSTRAINT role_permissions_permissions_permission_id_fk FOREIGN KEY (permission_id)
        REFERENCES permissions (permission_id) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT role_permissions_roles_role_id_fk FOREIGN KEY (role_id)
        REFERENCES roles (role_id) ON UPDATE CASCADE ON DELETE CASCADE
);
COMMENT ON TABLE role_permissions IS 'role permisins relationship';
COMMENT ON COLUMN role_permissions.role_permission_id IS 'primary key';
COMMENT ON COLUMN role_permissions.role_id IS 'foreign key for roles';
COMMENT ON COLUMN role_permissions.permission_id IS 'foreign key for permissions';
COMMENT ON COLUMN role_permissions.created_at IS 'created time';
COMMENT ON COLUMN role_permissions.updated_at IS 'updated time';

-- users
CREATE TABLE users
(
    user_id    SERIAL PRIMARY KEY,
    username   VARCHAR(30) NOT NULL UNIQUE,
    password   VARCHAR(30) NOT NULL,
    nickname   VARCHAR(30),
    created_at TIMESTAMP   NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP   NOT NULL DEFAULT CURRENT_TIMESTAMP
);
COMMENT ON TABLE users IS 'hms users table';
COMMENT ON COLUMN users.user_id IS 'primary key';
COMMENT ON COLUMN users.username IS 'username for login';
COMMENT ON COLUMN users.password IS 'password for login';
COMMENT ON COLUMN users.nickname IS 'The full name used for display';
COMMENT ON COLUMN users.created_at IS 'create time';
COMMENT ON COLUMN users.updated_at IS 'update time';

-- home_member_roles
CREATE TABLE home_member_roles
(
    member_id   SERIAL PRIMARY KEY,
    user_id     INTEGER   NOT NULL,
    home_id     INTEGER   NOT NULL,
    role_id     INTEGER,
    member_name VARCHAR(30),
    created_at  TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at  TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT user_id_home_id_unique UNIQUE (user_id, home_id),
    CONSTRAINT user_home_roles_homes_home_id_fk FOREIGN KEY (home_id)
        REFERENCES homes (home_id) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT user_home_roles_roles_role_id_fk FOREIGN KEY (role_id)
        REFERENCES roles (role_id) ON UPDATE SET NULL ON DELETE SET NULL,
    CONSTRAINT user_home_roles_users_user_id_fk FOREIGN KEY (user_id)
        REFERENCES users (user_id) ON UPDATE CASCADE ON DELETE CASCADE
);
COMMENT ON TABLE home_member_roles IS 'The role of a user in the home. A user can have only one unique role in a home.';
COMMENT ON COLUMN home_member_roles.member_id IS 'primary key';
COMMENT ON COLUMN home_member_roles.user_id IS 'foreign key for users';
COMMENT ON COLUMN home_member_roles.home_id IS 'foreign key for homes';
COMMENT ON COLUMN home_member_roles.role_id IS 'foreign key for roles';
COMMENT ON COLUMN home_member_roles.member_name IS 'home member name';
COMMENT ON COLUMN home_member_roles.created_at IS 'created time';
COMMENT ON COLUMN home_member_roles.updated_at IS 'updated time';

-- message_status
CREATE TABLE message_status
(
    message_status_id SERIAL PRIMARY KEY,
    user_id           INTEGER   NOT NULL,
    message_id        INTEGER   NOT NULL,
    status            SMALLINT  NOT NULL DEFAULT 0,
    created_at        TIMESTAMP NOT NULL,
    updated_at        TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT message_status_messages_message_id_fk FOREIGN KEY (message_id)
        REFERENCES messages (message_id) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT message_status_users_user_id_fk FOREIGN KEY (user_id)
        REFERENCES users (user_id) ON UPDATE CASCADE ON DELETE CASCADE
);
COMMENT ON TABLE message_status IS 'message status';
COMMENT ON COLUMN message_status.message_status_id IS 'primary key';
COMMENT ON COLUMN message_status.user_id IS 'foreign key for users';
COMMENT ON COLUMN message_status.message_id IS 'foreign key for messages';
COMMENT ON COLUMN message_status.status IS 'message status for a user, 0 - unread, 1 - read ...';
COMMENT ON COLUMN message_status.created_at IS 'created time';
COMMENT ON COLUMN message_status.updated_at IS 'updated time';

-- revoked_tokens
CREATE TABLE revoked_tokens
(
    id         SERIAL PRIMARY KEY,
    jti        VARCHAR(60) NOT NULL UNIQUE,
    expiration TIMESTAMP   NOT NULL,
    user_id    INTEGER     NOT NULL,
    created_at TIMESTAMP   NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP   NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT revoked_tokens_users_user_id_fk FOREIGN KEY (user_id)
        REFERENCES users (user_id) ON UPDATE CASCADE ON DELETE CASCADE
);
COMMENT ON TABLE revoked_tokens IS 'logged out tokens';
COMMENT ON COLUMN revoked_tokens.id IS 'primary key';
COMMENT ON COLUMN revoked_tokens.jti IS 'jwt id';
COMMENT ON COLUMN revoked_tokens.expiration IS 'expiration time';
COMMENT ON COLUMN revoked_tokens.user_id IS 'foreign key for users';
COMMENT ON COLUMN revoked_tokens.created_at IS 'created time';
COMMENT ON COLUMN revoked_tokens.updated_at IS 'updated time';

-- 4. 为所有含有updated_at的表添加触发器（未来你新增表，也如法炮制一行即可！）

DO
$$
    DECLARE
        r RECORD;
    BEGIN
        FOR r IN
            SELECT table_name
            FROM information_schema.columns
            WHERE column_name = 'updated_at'
              AND table_schema = current_schema()
            LOOP
                EXECUTE format('
            DROP TRIGGER IF EXISTS trg_set_updated_at_%1$s ON %1$I;
            CREATE TRIGGER trg_set_updated_at_%1$s
            BEFORE UPDATE ON %1$I
            FOR EACH ROW EXECUTE FUNCTION update_updated_at_column();
        ', r.table_name);
            END LOOP;
    END
$$;
