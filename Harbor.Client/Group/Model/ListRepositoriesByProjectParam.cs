using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Client.Group.Model
{
    public class ListRepositoriesByProjectParam
    {
        /// <summary>
        /// The page number
        /// </summary>
        public int page { get; set; } = 1;

        /// <summary>
        /// The size of per page
        /// </summary>
        public int page_size { get; set; } = 10;

        /// <summary>
        /// The name of the project
        /// </summary>
        public string project_name { get; set; }

        /// <summary>
        /// Sort the resource list in ascending or descending order. e.g. sort by field1 in ascending orderr and field2 in descending order with "sort=field1,-field2"
        /// </summary>
        public string sort { get; set; }

        /// <summary>
        /// Query string to query resources. Supported query patterns are "exact match(k=v)", "fuzzy match(k=~v)", "range(k=[min~max])", "list with union releationship(k={v1 v2 v3})" and "list with intersetion relationship(k=(v1 v2 v3))". The value of range and list can be string(enclosed by " or '), integer or time(in format "2020-04-09 02:36:00"). All of these query patterns should be put in the query string "q=xxx" and splitted by ",". e.g. q=k1=v1,k2=~v2,k3=[min~max]
        /// </summary>
        public string q { get; set; }
    }
}
