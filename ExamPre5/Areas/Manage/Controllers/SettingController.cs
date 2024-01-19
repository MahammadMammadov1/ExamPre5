using ExamPre5.Business.CustomExceptions.Setting;
using ExamPre5.Business.Service.Interfaces;
using ExamPre5.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ExamPre5.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]

    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _settingService.GetAllAsync());
        }

        public async Task<IActionResult> Update(int id) 
        {
            if (await _settingService.GetByIdAsync(id) == null) { return View("Error"); }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Setting setting) 
        {
            if (setting == null) { return View("Error"); }
            if(!ModelState.IsValid) return View();
            try
            {
                await _settingService.UpdateAsync(setting);
            }
            catch (SettingNullException)
            {

                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("index");
        }
    }
}
