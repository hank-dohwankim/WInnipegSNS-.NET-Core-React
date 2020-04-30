using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinnipegSNS.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
