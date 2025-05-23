SET search_path TO hms_schema;

INSERT INTO permissions (permission_id, permission_code, permission_description, created_at, updated_at) VALUES (1, 'home:edit', '修改家庭', '2025-01-13 12:12:08', '2025-03-02 09:59:07');
INSERT INTO permissions (permission_id, permission_code, permission_description, created_at, updated_at) VALUES (2, 'home:delete', '删除家庭', '2025-01-13 12:12:08', '2025-03-02 09:59:07');
INSERT INTO permissions (permission_id, permission_code, permission_description, created_at, updated_at) VALUES (3, 'home:member:invite', '邀请用户', '2025-03-02 09:48:30', '2025-03-02 09:59:07');
INSERT INTO permissions (permission_id, permission_code, permission_description, created_at, updated_at) VALUES (4, 'home:member:view', '查看成员(列表)', '2025-03-02 10:00:29', '2025-03-02 10:00:29');
INSERT INTO permissions (permission_id, permission_code, permission_description, created_at, updated_at) VALUES (5, 'home:member:delete', '删除成员', '2025-03-02 10:03:18', '2025-03-02 10:03:18');
INSERT INTO permissions (permission_id, permission_code, permission_description, created_at, updated_at) VALUES (6, 'home:member:edit', '修改成员', '2025-03-02 10:04:42', '2025-03-02 10:04:42');
INSERT INTO permissions (permission_id, permission_code, permission_description, created_at, updated_at) VALUES (7, 'home:role:create', '创建角色', '2025-03-02 10:17:06', '2025-03-02 10:17:06');
INSERT INTO permissions (permission_id, permission_code, permission_description, created_at, updated_at) VALUES (8, 'home:role:view', '查看角色', '2025-03-02 10:17:38', '2025-03-02 10:17:38');
INSERT INTO permissions (permission_id, permission_code, permission_description, created_at, updated_at) VALUES (9, 'home:role:edit', '修改角色', '2025-03-02 10:18:49', '2025-03-02 10:18:49');
INSERT INTO permissions (permission_id, permission_code, permission_description, created_at, updated_at) VALUES (10, 'home:role:delete', '删除角色', '2025-03-02 10:18:49', '2025-03-02 10:18:49');

SELECT setval('permissions_permission_id_seq', (SELECT MAX(permission_id) FROM permissions));