using Harbor.Client.Group.Model;
using Harbor.Client.ResponseModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Harbor.Client.Group
{
    public class Repository : IRepository
    {
        private readonly IHarborClient _HarborClient;
        internal Repository(IHarborClient HarborClient)
        {
            _HarborClient = HarborClient;
        }

        /// <summary>
        /// List repositories of the specified project
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ApiResponse<List<Repositories>>> ListRepositoriesByProject(ListRepositoriesByProjectParam param)
        {
            string apiUrl = $"/api/v2.0/projects/{param.project_name}/repositories";
            return await _HarborClient.GetAsync<List<Repositories>>(apiUrl, param);
        }

        /// <summary>
        /// Get the repository specified by name
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ApiResponse<Repositories>> GetRepository(GetRepositoryParam param)
        {
            string apiUrl = $"/api/v2.0/projects/{param.project_name}/repositories/{param.repository_name}";
            return await _HarborClient.GetAsync<Repositories>(apiUrl, param);
        }
        /// <summary>
        /// Delete the repository specified by name
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ApiResponse<string>> DeleteRepository(DeleteRepositoryParam param)
        {
            string apiUrl = $"/api/v2.0/projects/{param.project_name}/repositories/{param.repository_name}";
            return await _HarborClient.DeleteAsync<string>(apiUrl, null);
        }
    }
}
