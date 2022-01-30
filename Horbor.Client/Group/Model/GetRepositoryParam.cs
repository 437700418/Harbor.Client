using System;
using System.Collections.Generic;
using System.Text;

namespace Horbor.Client.Group.Model
{
    public class GetRepositoryParam
    {
        /// <summary>
        /// The name of the project
        /// </summary>
        public string project_name { get; set; }

        /// <summary>
        /// The name of the repository. If it contains slash, encode it with URL encoding. e.g. a/b -> a%252Fb
        /// </summary>
        public string repository_name { get; set; }
        
    }
}
