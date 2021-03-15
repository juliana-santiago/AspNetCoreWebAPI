using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Helpers
{
    public class PageParams
    {
        public int? Registration { get; set; } = null;
        public string Name { get; set; } = string.Empty;
        public int? Active { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public const int MaxPageSize = 50;

        private int pageSize = 15;
    }
}
