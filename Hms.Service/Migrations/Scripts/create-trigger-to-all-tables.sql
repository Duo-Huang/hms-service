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