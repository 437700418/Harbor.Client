using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Client.Group.Model
{
    /// <summary>
    /// DeleteRepositoryParam
    /// </summary>
    public class DeleteRepositoryParam
    {
        /// <summary>
        /// The name of the project
        /// </summary>

        [MarkNotQueryString]
        public string project_name { get; set; }

        /// <summary>
        /// The name of the repository. If it contains slash, encode it with URL encoding. e.g. a/b -> a%252Fb
        /// </summary>
        [MarkNotQueryString]
        public string repository_name { get; set; }

    }
}
