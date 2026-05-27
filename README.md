# 機材貸出管理システム (EquipmentRentalSystem)

C# (ASP.NET Core Razor Pages) と Oracle Database を連動させた、実務を想定した機材貸出・返却管理システムです。

## 💡 開発の背景・目的
工場や物流現場、IT資産管理における「誰が・何を・いつ借りたか」の管理をデジタル化し、効率的な在庫・資産運用を行うことを目的に開発しました。

## 🛠 使用技術・環境
* **言語・フレームワーク:** C# / ASP.NET Core 8.0 (Razor Pages)
* **データベース:** Oracle Database 21c (Express Edition)
* **開発環境:** Visual Studio 2022 / Oracle SQL Developer
* **接続技術:** Oracle.ManagedDataAccess.Core (Dapper風のクエリおよびストアドプロシージャ連携)

## ✨ 主な機能・特徴
1. **貸出出庫登録機能**
   * 機材IDとユーザーIDを入力することで、リアルタイムにデータベースのステータスを「貸出中」に更新します。
2. **返却入庫登録機能**
   * 機材IDのみの入力で、貸出履歴を照合し「保管中」へと安全にステータスを戻します。
3. **ストアドプロシージャ連携（PL/SQL）**
   * 複雑なデータ更新や整合性の担保は、Oracle DB側のストアドプロシージャ（`rent_equipment` 等）を呼び出す形で実装し、システムの堅牢性を高めています。
4. **徹底したセキュリティ対策（User Secrets）**
   * DB接続パスワードなどの機密情報は、.NETの環境変数機能（ユーザーシークレット）を活用してソースコードから完全に隠蔽し、GitHubへの漏洩を防止しています。

## ✨ 画面イメージ
1. **貸出出庫登録機能**

<img width="1915" height="914" alt="image" src="https://github.com/user-attachments/assets/e85ce7cb-3b75-414d-8e2b-261a0060399e" />


2. **返却入庫登録機能**

## 📁 データベース構成 (SQLフォルダ内)
* `Local_XE_SYS.sql`: プラガブルデータベース(XEPDB1)の設定、専用ユーザー作成、権限付与スクリプト
* `Local_XEPDB1_Portfolio.sql`: テーブル、制約、およびストアドプロシージャ（PL/SQL）の定義スクリプト
* `lending_system.sql`: 動作確認用の初期データ投入（INSERT）および検証クエリ
