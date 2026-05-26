using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EquipmentRentalSystem.Services;

namespace EquipmentRentalSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseService _dbService;

        public IndexModel(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        // 画面の入力項目と自動連動（バインド）するプロパティ
        [BindProperty]
        public string EquipmentId { get; set; } = "";

        [BindProperty]
        public string UserId { get; set; } = "";

        // 完了メッセージを画面に渡すための変数
        public string Message { get; set; } = "";

        public void OnGet()
        {
            // 初期表示時は何もしない
        }

        /* 貸出ボタンが押された時の処理 */
        public void OnPostRent()
        {
            try
            {
                if (string.IsNullOrEmpty(EquipmentId) || string.IsNullOrEmpty(UserId))
                {
                    Message = "❌ 機材IDとユーザーIDを入力してください。";
                    return;
                }

                _dbService.RentEquipment(EquipmentId, UserId);
                Message = $"✅ 機材 {EquipmentId} の貸出処理が完了しました！";
            }
            catch (Exception ex)
            {
                Message = $"❌ エラーが発生しました: {ex.Message}";
            }
        }

        /* 返却ボタンが押された時の処理 */
        public void OnPostReturn()
        {
            try
            {
                if (string.IsNullOrEmpty(EquipmentId))
                {
                    Message = "❌ 機材IDを入力してください。";
                    return;
                }

                _dbService.ReturnEquipment(EquipmentId);
                Message = $"✅ 機材 {EquipmentId} の返却処理が完了しました！";
            }
            catch (Exception ex)
            {
                Message = $"❌ エラーが発生しました: {ex.Message}";
            }
        }
    }
}