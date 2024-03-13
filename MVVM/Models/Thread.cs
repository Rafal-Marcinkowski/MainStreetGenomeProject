using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainStreetGenomeProject.MVVM.Models
{
    internal class Thread
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string ThreadName { get; set; }
        public DateTime DateTime { get; set; }
        public int CommentsAmount { get; set; }
        public byte IPAddress { get; set; }
        public string Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
