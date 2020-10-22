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

        public IActionResult GetShortLink(GetShortLinkViewModel.Request request)
        {
            return Json(new GetShortLinkViewModel.Response
            {
                ShortLink = _userService.GetShortLink(request.Email, request.OriginalLink)
            });
        }

        public IActionResult GetOriginalLink(GetOriginalLinkViewModel.Request request)
        {
            return Json(new GetOriginalLinkViewModel.Response
            {
                OriginalLink = _userService.GetOriginalLink(request.Email, request.ShortLink)
            });
        }

        public IActionResult GetLinks(GetLinksViewModel.Request request)
        {
            return Json(new GetLinksViewModel.Response
            {
                Links = _userService.GetLinks(request.Email, request.Password)
            });
        }
    }
}