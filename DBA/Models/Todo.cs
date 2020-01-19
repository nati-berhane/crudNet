using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBA.Models
{
    public class Todo
    {
        public int id { get; set; }
        public string todo { get; set; }
        public bool isCompleted { get; set; }
    }
}