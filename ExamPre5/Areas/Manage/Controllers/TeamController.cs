using ExamPre5.Business.CustomExceptions.Team;
using ExamPre5.Business.Service.Interfaces;
using ExamPre5.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamPre5.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        public async Task<IActionResult> Index()
        {
            var team = await _teamService.GetAllAsync();
            return View(team);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                await _teamService.CreateAsync(team);
            }
            catch (ContentTypeException ex)
            {

                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();
            }
            catch (FileLengthException ex)
            {

                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();
            }
            catch (ImageFileRequiredException ex)
            {

                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();
            }
            catch (TeamMemberNotFoundException )
            {
                return NotFound();
                
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var exist = await _teamService.GetByIdAsync(id);
            if (exist == null) return NotFound();
            return View(exist);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Team team)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                await _teamService.UpdateAsync(team);
            }
            catch (ContentTypeException ex)
            {

                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();
            }
            catch (FileLengthException ex)
            {

                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();
            }
            catch (ImageFileRequiredException ex)
            {

                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();
            }
            catch (TeamMemberNotFoundException)
            {
                return NotFound();

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
