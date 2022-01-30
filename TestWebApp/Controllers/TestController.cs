using Horbor.Client;
using Horbor.Client.Group.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly HorborClientConfiguratio _horborClientConfiguratio;
        private readonly HorborClient _horborClient;
        public TestController()
        {
            _horborClientConfiguratio = new HorborClientConfiguratio(new HarborConfig("admin", "Harbor12345", "192.168.189.99:8088"));
            _horborClient = _horborClientConfiguratio.CreatHorborClient();
        }

        [HttpGet,Route("ListRepositoriesByProject")]
        public async Task<string> ListRepositoriesByProject()
        {
            var result = await _horborClient.Repository.ListRepositoriesByProject(new Horbor.Client.Group.Model.ListRepositoriesByProjectParam()
            {
                project_name = "myprpject"
            }); ;
            return result;
        }

        [HttpGet, Route("GetRepository")]
        public async Task<string> GetRepository()
        {
            var result = await _horborClient.Repository.GetRepository(new Horbor.Client.Group.Model.GetRepositoryParam()
            {
                project_name= "myprpject",
                repository_name = "ysdszt"
            }); 
            return result;
        }
    }
}
