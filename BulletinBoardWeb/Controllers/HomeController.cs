// 【変更】 トップ ページのコントローラー

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulletinBoardWeb.Controllers
{
    using ViewModels;

    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}