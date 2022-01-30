using Horbor.Client.Group.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Horbor.Client.Group
{
    public class Repository : IRepository
    {
        private readonly IHorborClient _horborClient;
        internal Repository(IHorborClient horborClient)
        {
            _horborClient = horborClient;
        }

        /// <summary>
        /// List repositories of the specified project
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<string> ListRepositoriesByProject(ListRepositoriesByProjectParam param)
        {
            string apiUrl = $"/api/v2.0/projects/{param.project_name}/repositories";
            return await _horborClient.GetAsync(apiUrl, param);
        }

        /// <summary>
        /// Get the repository specified by name
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<string> GetRepository(GetRepositoryParam param)
        {
            string apiUrl = $"/api/v2.0/projects/{param.project_name}/repositories/{param.repository_name}";
            return await _horborClient.GetAsync(apiUrl, param);
        }
    }
}
