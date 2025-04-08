using Fubon_T.Services;
using Fubon_T.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fubon_T.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _service;

        public MemberController(IMemberService service) => _service = service;

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = _service.Register(model);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }

            return RedirectToAction("RegisterSuccess");
        }

        public IActionResult RegisterSuccess() => View();

    }
}
