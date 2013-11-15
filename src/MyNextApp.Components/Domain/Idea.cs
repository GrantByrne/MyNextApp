using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNextApp.Components.Domain
{
    public class Idea : Entity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public string CreatedDate { get; set; }
        public int UserId { get; set; }
    }
}
