using ExamPre5.Business.Service.Interfaces;
using ExamPre5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamPre5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeamService _teamService;

        public HomeController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        

        public async Task<IActionResult> Index()
        {
            var team = await _teamService.GetAllAsync();
            return View(team);
        }

       

        
    }
}