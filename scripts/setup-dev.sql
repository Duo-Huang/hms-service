-- 定义变量
\set db_name 'hms_dev'
\set migration_user 'hms_migration_user'
\set migration_password 'hms.dev.migration.1234'
\set app_user 'hmsuser'
\set app_password 'hms.dev.123'
\set schema_name 'hms_schema'

-- 1. 创建迁移用户
CREATE ROLE :migration_user WITH LOGIN PASSWORD :'migration_password';

-- 2. 创建应用用户
CREATE ROLE :app_user WITH LOGIN PASSWORD :'app_password';

-- 3. 创建 schema，并授权给 migration_user （确保其拥有创建对象权限）
CREATE SCHEMA :"schema_name" AUTHORIZATION :migration_user;

-- 4. 设置默认搜索路径
ALTER ROLE :migration_user SET search_path = :"schema_name", public;
ALTER ROLE :app_user SET search_path = :"schema_name", public;

-- 5. 授权数据库连接权限
GRANT CONNECT, TEMPORARY ON DATABASE :db_name TO :migration_user;
GRANT CONNECT ON DATABASE :db_name TO :app_user;

-- 6. 授权 schema 权限
GRANT USAGE ON SCHEMA :"schema_name" TO :migration_user;
GRANT CREATE ON SCHEMA :"schema_name" TO :migration_user;

GRANT USAGE ON SCHEMA :"schema_name" TO :app_user;

-- 7. 切换角色为 migration_user，设置默认权限，授权 app_user 对未来表的访问权限
SET ROLE :migration_user;

ALTER DEFAULT PRIVILEGES IN SCHEMA :"schema_name"
    GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO :app_user;

ALTER DEFAULT PRIVILEGES IN SCHEMA :"schema_name"
    GRANT USAGE, SELECT ON SEQUENCES TO :app_user;

-- 8. 给已有表和序列授权 app_user 访问权限
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA :"schema_name" TO :app_user;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA :"schema_name" TO :app_user;

-- 9. 恢复角色回 root
RESET ROLE;