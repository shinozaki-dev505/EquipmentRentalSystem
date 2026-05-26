-- 1. プラガブル・データベース（XEPDB1）に切り替える
ALTER SESSION SET CONTAINER = XEPDB1;

-- 2. パスワードを記号なしの半角英数字（Portfolio2026）にしてユーザーを作成
CREATE USER portfolio_user IDENTIFIED BY Portfolio2026 DEFAULT TABLESPACE USERS;

-- 3. 作成したユーザーに開発権限を与える
GRANT CONNECT, RESOURCE, CREATE VIEW, UNLIMITED TABLESPACE TO portfolio_user;