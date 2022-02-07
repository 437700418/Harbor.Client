using System;
using System.Collections.Generic;
using System.Text;

namespace Horbor.Client.ResponseModel
{
    public class ListRepositoriesResponseModel: BaseResponse
    {

   
    }

    public class Repositories
    {
        public int update_time { get; set; }
        public int description { get; set; }
        public int pull_count { get; set; }
        public int creation_time { get; set; }
        public int artifact_count { get; set; }
        public int project_id { get; set; }
        public int id { get; set; }
        public int name { get; set; }
    }
}
