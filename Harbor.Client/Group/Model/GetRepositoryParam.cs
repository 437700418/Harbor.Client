using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Client.Group.Model
{
    public class GetRepositoryParam
    {
        /// <summary>
        /// The name of the project
        /// </summary>
        
        [MarkNotQueryStringAttribute]
        public string project_name { get; set; }

        /// <summary>
        /// The name of the repository. If it contains slash, encode it with URL encoding. e.g. a/b -> a%252Fb
        /// </summary>
        [MarkNotQueryStringAttribute]
        public string repository_name { get; set; }
        
    }
}
