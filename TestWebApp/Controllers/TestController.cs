using Horbor.Client;
using Horbor.Client.Group.Model;
using Horbor.Client.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        public TestController()
        {
            _horborClientConfiguratio = new HorborClientConfiguratio(new HarborConfig("admin", "Harbor12345", "192.168.189.99:8088"));
        }

        [HttpGet, Route("ListRepositoriesByProject")]
        public async Task<string> ListRepositoriesByProject(string projectname)
        {
            using (HorborClient _horborClient = _horborClientConfiguratio.CreatHorborClient())
            {
                var result = await _horborClient.Repository.ListRepositoriesByProject(new Horbor.Client.Group.Model.ListRepositoriesByProjectParam()
                {
                    project_name = projectname
                });
                return JsonConvert.SerializeObject(result);
            }
        }

        [HttpGet, Route("GetRepository")]
        public async Task<string> GetRepository(string projectname, string repositoryname)
        {
            using (HorborClient _horborClient = _horborClientConfiguratio.CreatHorborClient())
            {
                var result = await _horborClient.Repository.GetRepository(new Horbor.Client.Group.Model.GetRepositoryParam()
                {
                    project_name = projectname,
                    repository_name = repositoryname
                });
                return JsonConvert.SerializeObject(result);
            }
        }


        [HttpGet, Route("DeleteRepository")]
        public async Task<string> DeleteRepository()
        {
            using (HorborClient _horborClient = _horborClientConfiguratio.CreatHorborClient())
            {
                var result = await _horborClient.Repository.DeleteRepository(new DeleteRepositoryParam()
                {
                    project_name = "myprpject",
                    repository_name = "ysdszt",
                });
                return JsonConvert.SerializeObject(result);
            }
        }
    }
}
