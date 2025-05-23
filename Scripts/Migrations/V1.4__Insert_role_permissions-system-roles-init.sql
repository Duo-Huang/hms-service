SET search_path TO hms_schema;

INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (1, 1, 1, '2025-01-13 11:55:05', '2025-01-13 11:55:05');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (2, 1, 2, '2025-01-13 11:56:29', '2025-01-13 11:56:29');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (3, 1, 3, '2025-03-02 10:27:37', '2025-03-02 10:27:42');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (4, 1, 4, '2025-03-02 10:28:03', '2025-03-02 10:28:03');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (5, 1, 5, '2025-03-02 10:28:03', '2025-03-02 10:28:03');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (6, 1, 6, '2025-03-02 10:28:03', '2025-03-02 10:28:03');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (7, 1, 7, '2025-03-02 10:28:30', '2025-03-02 10:28:30');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (8, 1, 8, '2025-03-02 10:28:45', '2025-03-02 10:28:45');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (9, 1, 9, '2025-03-02 10:28:45', '2025-03-02 10:28:45');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (10, 1, 10, '2025-03-02 10:28:45', '2025-03-02 10:28:45');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (11, 2, 3, '2025-03-02 10:29:56', '2025-03-02 10:29:56');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (12, 2, 4, '2025-03-02 10:29:56', '2025-03-02 10:29:56');
INSERT INTO role_permissions (role_permission_id, role_id, permission_id, created_at, updated_at) VALUES (13, 2, 8, '2025-03-02 10:29:56', '2025-03-02 10:29:56');

SELECT setval('role_permissions_role_permission_id_seq', (SELECT MAX(role_permission_id) FROM role_permissions));