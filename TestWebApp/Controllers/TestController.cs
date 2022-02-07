using Harbor.Client;
using Harbor.Client.Group.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TestWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly HarborClientConfiguration _HarborClientConfiguratio;
        public TestController()
        {
            _HarborClientConfiguratio = new HarborClientConfiguration(new HarborConfig("admin", "Harbor12345", "192.168.189.99:8088"));
        }

        [HttpGet, Route("ListRepositoriesByProject")]
        public async Task<string> ListRepositoriesByProject(string projectname)
        {
            using (HarborClient _HarborClient = _HarborClientConfiguratio.CreatHarborClient())
            {
                var result = await _HarborClient.Repository.ListRepositoriesByProject(new Harbor.Client.Group.Model.ListRepositoriesByProjectParam()
                {
                    project_name = projectname
                });
                return JsonConvert.SerializeObject(result);
            }
        }

        [HttpGet, Route("GetRepository")]
        public async Task<string> GetRepository(string projectname, string repositoryname)
        {
            using (HarborClient _HarborClient = _HarborClientConfiguratio.CreatHarborClient())
            {
                var result = await _HarborClient.Repository.GetRepository(new Harbor.Client.Group.Model.GetRepositoryParam()
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
            using (HarborClient _HarborClient = _HarborClientConfiguratio.CreatHarborClient())
            {
                var result = await _HarborClient.Repository.DeleteRepository(new DeleteRepositoryParam()
                {
                    project_name = "myprpject",
                    repository_name = "ysdszt",
                });
                return JsonConvert.SerializeObject(result);
            }
        }
    }
}
