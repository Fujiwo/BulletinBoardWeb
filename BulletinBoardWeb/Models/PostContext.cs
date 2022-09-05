// 最初にコマンドラインで下記を実行
// dotnet ef migrations add InitialCreate
// dotnet ef database update

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BulletinBoardWeb.Models
{
    public class ImageFile
    {
        public int Id { get; set; }

        [Display(Name = "名前")]
        [Required]
        [StringLength(25)]
        public string Name { get; set; } = "";

        [Display(Name = "説明")]
        [StringLength(250)]
        public string Description { get; set; } = "";

        [Display(Name = "画像")]
        [Required]
        public byte[] Image { get; set; } = null!;
    }
    
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

    public class PostContext : DbContext
    {
        public PostContext()
        { }

        public PostContext(DbContextOptions<PostContext> options) : base(options)
        {}

        public virtual DbSet<ImageFile> ImageFiles { get; set; } = null!;
    }
}
