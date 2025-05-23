SET search_path TO hms_schema;

INSERT INTO roles (role_id, role_type, role_name, role_description, home_id, created_at, updated_at) VALUES (1, 0, '家庭管理员', '家庭管理员, 拥有家庭内所有权限', null, '2025-01-09 14:33:47', '2025-01-10 15:00:07');
INSERT INTO roles (role_id, role_type, role_name, role_description, home_id, created_at, updated_at) VALUES (2, 0, '家庭成员', '家庭成员, 拥有家庭内大部分权限,除了部分重要操作', null, '2025-01-09 16:11:02', '2025-01-10 15:00:07');

SELECT setval('roles_role_id_seq', (SELECT MAX(role_id) FROM roles));