using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainStreetGenomeProject.MVVM.Models
{
    internal class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public int Ranking { get; set; }
        public List<Thread> Threads { get; set; }
    }
}
