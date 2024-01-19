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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update(int id) 
        {
            return View();
        }

        public async Task<IActionResult> Update(Setting setting) 
        {
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
