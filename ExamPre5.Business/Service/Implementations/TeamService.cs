using ExamPre5.Business.CustomExceptions.Team;
using ExamPre5.Business.Service.Interfaces;
using ExamPre5.Core.Models;
using ExamPre5.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Business.Service.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IWebHostEnvironment _env;

        public TeamService(ITeamRepository teamRepository,IWebHostEnvironment env)
        {
            _teamRepository = teamRepository;
            _env = env;
        }
        public async Task CreateAsync(Team team)
        {
            if(team.FormFile!= null)
            {
                if (team.FormFile.Length > 2097000)
                {
                    throw new FileLengthException("FormFile", "File must be less than 2 mb");
                }
                if(team.FormFile.ContentType != "image/jpeg" && team.FormFile.ContentType != "image/png")
                {
                    throw new ContentTypeException("FormFile", "File must be png or jpeg");
                }

                team.ImageUrl = Helper.SaveFile.SaveImage(_env.WebRootPath, "Uploads/Team", team.FormFile);


            }
            else
            {
                throw new ImageFileRequiredException("FormFile", "File required");
            }

            await _teamRepository.CreateAsync(team);
            team.CreateDate= DateTime.Now;
            team.UpdateDate= DateTime.Now;
            await _teamRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await _teamRepository.GetByIdAsync(x => x.Id == id);
            if (exist == null) throw new TeamMemberNotFoundException();
            _teamRepository.Delete(exist);
            await _teamRepository.CommitAsync();
        }

        public async Task<List<Team>> GetAllAsync()
        {
            return await _teamRepository.GetAllAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await _teamRepository.GetByIdAsync(x=>x.Id == id);
        }

        public async Task UpdateAsync(Team team)
        {
            var exist = await _teamRepository.GetByIdAsync(x=>x.Id == team.Id);
            if (exist == null) throw new TeamMemberNotFoundException();

            if (team.FormFile != null)
            {
                if (team.FormFile.Length > 2097000)
                {
                    throw new FileLengthException("FormFile", "File must be less than 2 mb");
                }
                if (team.FormFile.ContentType != "image/jpeg" && team.FormFile.ContentType != "image/png")
                {
                    throw new ContentTypeException("FormFile", "File must be png or jpeg");
                }

                string oldPath = Path.Combine(_env.WebRootPath, "Uploads/Team") + exist.ImageUrl;

                if (!File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }


                exist.ImageUrl = Helper.SaveFile.SaveImage(_env.WebRootPath, "Uploads/Team", team.FormFile);


            }
            

            exist.Profession = team.Profession;
            exist.Name= team.Name;
            exist.CreateDate = team.CreateDate;
            exist.UpdateDate = DateTime.Now;
            await _teamRepository.CommitAsync();
        }
    }
}
