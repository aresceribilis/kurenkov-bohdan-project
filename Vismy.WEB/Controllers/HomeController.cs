using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Vismy.Application.Interfaces;
using Vismy.WEB.Models;
using Vismy.WEB.ViewModels;

namespace Vismy.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(
            ILogger<HomeController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        
        public async Task<IActionResult> UserPreviews(int pageNum = 1, string filter = null)
        {
            const int pageSize = 2;

            ViewData["Filter"] = filter;

            var userPreviews = await _userService.GetUserPreviewsAsync(pageSize, filter, pageNum - 1);
            var pageVm = new PageViewModel(await _userService.GetUsersCountAsync(filter), pageNum, pageSize);

            var model = new UserPreviewsVM() {PageViewModel = pageVm, Users = userPreviews};

            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
