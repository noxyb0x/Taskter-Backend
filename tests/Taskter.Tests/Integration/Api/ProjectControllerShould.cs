﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Taskter.Api;
using Taskter.Tests.Helpers.Factories;
using Microsoft.Extensions.DependencyInjection;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;
using Taskter.Infrastructure.Data;
using Taskter.Infrastructure.UserContext;
using Taskter.Tests.Helpers.Extensions;
using Microsoft.AspNetCore.TestHost;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectControllerShould
    {
        private HttpClient _client;
        private ICurrentUserContext _currentUserContext;
        private TaskterDbContext _dbContext;

        [Test]
        public async Task GetProjectsForCurrentUser_AssignedTwoProjects_ReturnsAListOfTwoAssignedProjects()
        {
            //refaktor u helper extenziju
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var serviceDesc = services.FirstOrDefault(desc => desc.ServiceType == typeof(ICurrentUserContext));
                    services.Remove(serviceDesc);
                    _currentUserContext = new CurrentUserContext() { UserId = 3 };
                    services.AddTransient<ICurrentUserContext>(x => _currentUserContext);
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();
            //
            //seed user
            _dbContext.Users.Add(new User("test1", "test 1", "test lastName", "admin", "http://google.com")
            { Id = _currentUserContext.UserId });
            //seed client
            var clientSeed = new Client("testClient") { Id = 20 };
            _dbContext.Clients.Add(clientSeed);
            //seed projects
            var seedProjectsList = new List<Project>()
            {
                new Project("test project 1", 20, null) {Id = 10, Client = clientSeed},
                new Project("test project 2", 20, null) {Id = 11, Client = clientSeed}
            };

            var seedProjectsTaskList = new List<ProjectTask>()
            {
                new ProjectTask("testTask1",10,false) {Id = 20},
                new ProjectTask("testTask2",10,false) {Id = 21},
                new ProjectTask("testTask1",11,false) {Id = 22},
                new ProjectTask("testTask2",11,false) {Id = 23}
            };
            _dbContext.Projects.AddRange(seedProjectsList);
            _dbContext.ProjectTasks.AddRange(seedProjectsTaskList);
            //seed userProjects
            _dbContext.UsersProjects.Add(new UserProject(3, 10));
            _dbContext.UsersProjects.Add(new UserProject(3, 11));
            _dbContext.SaveChanges();
            //test
            var result = await _client.GetProjectsForCurrentUser();
            var seedsDto = seedProjectsList.ToDTOList();
            result.Should().BeEquivalentTo(seedsDto);
        }
    }
}
