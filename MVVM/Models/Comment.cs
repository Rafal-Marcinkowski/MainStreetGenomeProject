using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainStreetGenomeProject.MVVM.Models
{
    internal class Comment
    {
        public int ID { get; set; }
        public int ThreadID { get; set; }
        public string CommentText { get; set; }
        public byte IPAddress { get; set; }
        public DateTime DateTime { get; set; }
        public string Author { get; set; }

    }
}
