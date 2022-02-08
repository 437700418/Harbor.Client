using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Client.ResponseModel
{
    public class Repositories
    {
        public DateTime update_time { get; set; }
        public int pull_count { get; set; }
        public DateTime creation_time { get; set; }
        public int artifact_count { get; set; }
        public int project_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
  
}
