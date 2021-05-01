using DataAccess.Entities.Roles;
using DTOs.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Crud
{
    public class RoleExtendDto : BaseRole
    {
    }

    public class RoleListFilterDto : ListFilter
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }

    public class RoleListItemDto
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
