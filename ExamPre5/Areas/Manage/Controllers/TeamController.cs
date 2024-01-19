using ExamPre5.Business.CustomExceptions.Team;
using ExamPre5.Business.Service.Interfaces;
using ExamPre5.Core.Models;
using ExamPre5.Data.DAL;
using ExamPre5.PaginatedHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ExamPre5.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]

    public class TeamController : Controller
    {
        
        private readonly ITeamService _teamService;
        private readonly AppDbContext _appDb;

        public TeamController(ITeamService teamService,AppDbContext appDb)
        {
            _teamService = teamService;
            _appDb = appDb;
        }
        public async Task<IActionResult> Index(int page =1 )
        {
            
            var query = _appDb.Teams.AsQueryable();

            //var team = await _teamService.GetAllAsync();
            PaginatedList<Team> teams = new PaginatedList<Team>(query.Skip((page - 1) * 2).Take(2).ToList(),query.ToList().Count,page,2);
            if (teams.TotalCount  < page)
            {
                page = 1;
                teams = new PaginatedList<Team>(query.Skip((page - 1) * 2).Take(2).ToList(), query.ToList().Count, page, 2);
            }
            return View(teams);
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
            if (exist == null) return View("Error");
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
