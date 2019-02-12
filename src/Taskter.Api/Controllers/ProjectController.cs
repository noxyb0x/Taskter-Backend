﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskter.Api.Contracts;
using Taskter.Core.Interfaces;

namespace Taskter.Api.Controllers
{
    [ApiController]
    public class ProjectController: ApplicationControllerBase
    {
    
        private readonly IProjectRepository _repository;
        public ProjectController(IProjectRepository repository)
        {
            _repository = repository;
        }
        [Route("/api/users/current/projects")]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjectsForCurrentUser()
        {
            var projectsRepo = _repository.GetAllProjectsForUser(this.UserID);
            return Ok(projectsRepo.ToDTOList());
        }

        [Route("/api/project")]
        [HttpPost]
        public ActionResult postNewProject(ProjectInsertDTO project)
        {
            project.getClient();
            return Ok();
        }
    }
}
