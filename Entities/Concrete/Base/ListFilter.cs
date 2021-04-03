using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.Base
{
    public class ListFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ListFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public ListFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 50 ? 50 : pageSize;
        }
    }
}
