using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace EquipmentRentalSystem.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        // appsettings.json から接続情報を自動的に受け取る設定
        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleConnection") ?? "";
        }

        /// <summary>
        /// 貸出処理プロシージャを呼び出す
        /// </summary>
        public void RentEquipment(string equipmentId, string userId)
        {
            using (OracleConnection conn = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("rent_equipment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // プロシージャの引数（パラメータ）を設定
                    cmd.Parameters.Add("p_equipment_id", OracleDbType.Varchar2).Value = equipmentId;
                    cmd.Parameters.Add("p_user_id", OracleDbType.Varchar2).Value = userId;

                    conn.Open();
                    cmd.ExecuteNonQuery(); // 実行
                }
            }
        }

        /// <summary>
        /// 返却処理プロシージャを呼び出す
        /// </summary>
        public void ReturnEquipment(string equipmentId)
        {
            using (OracleConnection conn = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("return_equipment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // プロシージャの引数（パラメータ）を設定
                    cmd.Parameters.Add("p_equipment_id", OracleDbType.Varchar2).Value = equipmentId;

                    conn.Open();
                    cmd.ExecuteNonQuery(); // 実行
                }
            }
        }
    }
}