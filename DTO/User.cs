using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? parentId { get; set; }
        public string Tz { get; set; }
        public int? NumberChildren { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public List<User> Children { get; set; }
    }

}
