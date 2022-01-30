﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horbor.Client.Group
{
    public interface IRepository
    {
        /// <summary>
        /// List repositories of the specified project
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<string> ListRepositoriesByProject(ListRepositoriesByProjectParam param);
    }
}
