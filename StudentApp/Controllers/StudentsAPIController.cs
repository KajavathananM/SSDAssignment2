using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace StudentApp.Controllers
{
    public class StudentsAPIController : ApiController
    {
        Student[] students = new Student[] {
            new Student { Id=1,Name="Saman Kumar",School="Royal College",GuardianName="Sampath Kumara"},
            new Student { Id=2,Name="Sumith Ekenakaya",School="Nalanda College",GuardianName="Viraj Ekenayake"},
            new Student { Id=3,Name="Viraj De Silva",School="Thomas College",GuardianName="Sunil De Silva"},
            new Student { Id=4,Name="Saptha Wijesinghe",School="Gateway College",GuardianName="Dulith Perera"},
            new Student { Id=5,Name="Viraj De Silva",School="Thomas College",GuardianName="Sunil De Silva"},
            new Student { Id=6,Name="Viraj De Silva",School="Thomas College",GuardianName="Sunil De Silva"},
        };
        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            return students;
        }
        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault((s) => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
       }
    
}
