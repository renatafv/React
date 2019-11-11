using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormApi.Models
{
    public class ContactItem
    {
        public long Id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string reason { get; set; }
    }
}
