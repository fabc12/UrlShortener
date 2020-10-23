using Application.ViewModels;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}/{action}")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult AddUser(AddUserViewModel.Request request)
        {
            return Json(new AddUserViewModel.Response
            {
                IsSuccessful = _userService.AddUser(request.Email, request.Password)
            });
        }

        public IActionResult GetShortUrl(GetShortUrlViewModel.Request request)
        {
            return Json(new GetShortUrlViewModel.Response
            {
                ShortUrl = _userService.GetShortUrl(request.Email, request.OriginalUrl)
            });
        }

        public IActionResult GetOriginalUrl(GetOriginalUrlViewModel.Request request)
        {
            return Json(new GetOriginalUrlViewModel.Response
            {
                OriginalUrl = _userService.GetOriginalUrl(request.Email, request.ShortUrl)
            });
        }

        public IActionResult GetShortUrls(GetShortUrlsViewModel.Request request)
        {
            return Json(new GetShortUrlsViewModel.Response
            {
                GetShortUrlsDto = _userService.GetShortUrls(request.Email, request.Password)
            });
        }
    }
}