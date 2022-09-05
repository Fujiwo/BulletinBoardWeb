// 【変更】 Upload.cshtml 用

using System.ComponentModel.DataAnnotations;

namespace BulletinBoardWeb.ViewModels
{
    public class ImageFileUploadViewModel
    {
        [Display(Name = "名前")]
        [Required(ErrorMessage = "{0} は必須")]
        [StringLength(25, ErrorMessage = "{0} は {1} 文字以内")]
        public string Name { get; set; } = "";

        [Display(Name = "説明")]
        [StringLength(250, ErrorMessage = "{0} は {1} 文字以内")]
        public string Description { get; set; } = "";

        [Display(Name = "ファイル")]
        [Required(ErrorMessage = "{0} は必須")]
        public IFormFile PostedFile { get; set; } = null!;
    }
}
