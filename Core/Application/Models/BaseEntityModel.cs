using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class BaseEntityModel
    {
        public  int? id { get; set; }
        public DateTime? creationDateTime { get; set; }
        public DateTime? updateDate { get; set; }
        public bool? isActive { get; set; }
    }
}
