CREATE OR REPLACE PROCEDURE rent_equipment (
    p_equipment_id IN VARCHAR2,
    p_user_id       IN VARCHAR2
) AS
BEGIN
    -- 1. 貸出履歴テーブルに新規登録
    INSERT INTO lending_history (equipment_id, user_id, rental_date, return_date)
    VALUES (p_equipment_id, p_user_id, SYSDATE, NULL);

    -- 2. 機材マスターのステータスを「貸出中」に更新
    UPDATE equipment_master
    SET status = '貸出中'
    WHERE equipment_id = p_equipment_id;

    -- 3. 処理の確定
    COMMIT;
END;
/

-- 1. テスト実行
BEGIN
    rent_equipment('E001', 'U001');
END;
/

-- 2. 機材マスターの確認
SELECT * FROM equipment_master;

-- 3. 貸出履歴の確認
SELECT * FROM lending_history;
