using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CourseItem: BaseAuditableEntity
    {
        public string Name { get; set; }
        public int Duration { get; set; }
    }
}
