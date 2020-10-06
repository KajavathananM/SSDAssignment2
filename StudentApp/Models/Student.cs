using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public string Grade { get; set; }
        public string GuardianName { get; set; }
    }
}