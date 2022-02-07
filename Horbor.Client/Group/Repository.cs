using Horbor.Client.Group.Model;
using Horbor.Client.ResponseModel;
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
        public async Task<ApiResponse<List<Repositories>>> ListRepositoriesByProject(ListRepositoriesByProjectParam param)
        {
            string apiUrl = $"/api/v2.0/projects/{param.project_name}/repositories";
            return await _horborClient.GetAsync<List<Repositories>>(apiUrl, param);
        }

        /// <summary>
        /// Get the repository specified by name
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ApiResponse<Repositories>> GetRepository(GetRepositoryParam param)
        {
            string apiUrl = $"/api/v2.0/projects/{param.project_name}/repositories/{param.repository_name}";
            return await _horborClient.GetAsync<Repositories>(apiUrl, param);
        }
        /// <summary>
        /// Delete the repository specified by name
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ApiResponse<string>> DeleteRepository(DeleteRepositoryParam param)
        {
            string apiUrl = $"/api/v2.0/projects/{param.project_name}/repositories/{param.repository_name}";
            return await _horborClient.DeleteAsync<string>(apiUrl, null);
        }
    }
}
