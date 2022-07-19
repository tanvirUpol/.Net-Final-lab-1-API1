using API1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API1.Controllers
{
    public class StudentController : ApiController
    {
        [Route("api/student/all")]
        [HttpGet]
        public HttpResponseMessage Students()
        {
            student_dbEntities db = new student_dbEntities();
            var students = db.Students.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        [Route("api/student/get/{id}")]
        [HttpGet]
        public HttpResponseMessage getSudent(int id)
        {
            student_dbEntities db = new student_dbEntities();
            var st = (from s in db.Students where s.Id == id select s).SingleOrDefault();

            return Request.CreateResponse(HttpStatusCode.OK, st);
        }
        [Route("api/student/create")]
        [HttpPost]
        public HttpResponseMessage createStudent(Student s)
        {
            student_dbEntities db = new student_dbEntities();
            var st = db.Students.Add(s);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }


        [Route("api/student/Delete/{id}")]
        [HttpGet]
        public HttpResponseMessage deleteStudent(int id)
        {
            student_dbEntities db = new student_dbEntities();
            var st = (from s in db.Students where s.Id == id select s).SingleOrDefault();
            db.Students.Remove(st);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }

        [Route("api/student/edit/{id}")]
        [HttpGet]
        public HttpResponseMessage editStudent(int id)
        {
            student_dbEntities db = new student_dbEntities();
            var st = (from s in db.Students where s.Id == id select s).SingleOrDefault();
            st.Dob = "2.4.1997";
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }
    }
}
