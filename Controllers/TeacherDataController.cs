using CumulativeProject.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CumulativeProject.Controllers
{
    public class TeacherDataController : ApiController
    {
        private ProjectDbContext project = new ProjectDbContext();



        [HttpGet]
        [Route("api/{TeacherData}/{ListTeacher}/{SerchKey?}")]
        public IEnumerable<Teacher> ListTeacher(string SerchKey = null)
        {
            MySqlConnection Conn = project.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from teachers where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower(@key)" +
                "or concat (teacherfname, ' ',teacherlname) like @key";

            cmd.Parameters.AddWithValue("@key", "%" + SerchKey + "%");

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Teacher> Teacher = new List<Teacher> { };

            while (reader.Read())
            {
                string TeacherFName = (string)reader["teacherfname"];
                string TeacherLname = (string)reader["teacherlname"];
                int TeacherId = (int)reader["teacherid"];
                string Employeenumber = (string)reader["employeenumber"];
                decimal salary = (decimal)reader["salary"];
                DateTime Hiredate = (DateTime)reader["hiredate"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFName = TeacherFName;
                NewTeacher.TeacherLName = TeacherLname;
                NewTeacher.hiredate = Hiredate;
                NewTeacher.Salary = salary;
                NewTeacher.EmployeeNumber = Employeenumber;

                Teacher.Add(NewTeacher);
            }

            Conn.Close();

            return Teacher;
        }

        [HttpGet]

        public Teacher FindTeacher(int id)
        {
            Teacher Teacher = new Teacher();

            MySqlConnection Conn = project.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "select * from teachers where teacherid =" +id;

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string TeacherFName = (string)reader["teacherfname"];
                string TeacherLname = (string)reader["teacherlname"];
                int TeacherId = (int)reader["teacherid"];
                string Employeenumber = (string)reader["employeenumber"];
                decimal salary = (decimal)reader["salary"];
                DateTime Hiredate = (DateTime)reader["hiredate"];

                Teacher NewTeacher = new Teacher();
                Teacher.TeacherId = TeacherId;
                Teacher.TeacherFName = TeacherFName;
                Teacher.TeacherLName = TeacherLname;
                Teacher.hiredate = Hiredate;
                Teacher.Salary = salary;
                Teacher.EmployeeNumber = Employeenumber;

            }

            return Teacher;

        }
    }
}
