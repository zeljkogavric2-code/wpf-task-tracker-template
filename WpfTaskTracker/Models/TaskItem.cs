using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTaskTracker.Models
{
   
        public class TaskItem
        {
            public string Title { get; set; }
            public DateTime Deadline { get; set; }
            public int Priority { get; set; }
        }
    
}
