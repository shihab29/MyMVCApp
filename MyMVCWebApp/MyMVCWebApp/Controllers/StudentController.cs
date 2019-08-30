using MyMVCWebApp.Models;
using MyMVCWebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCWebApp.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> studentList = new List<Student>();
        private List<Section> sectionList = new List<Section>()
        {
            new Section() { Text = "A", Value = "a" },
            new Section() { Text = "B", Value = "b" },
            new Section() { Text = "C", Value = "c" }
        };

        // GET: Student
        public ActionResult Index()
        {
            return View(studentList);
        }

        public ActionResult Create()
        {
            var studentViewModel = new StudentViewModel()
            {
                SectionList = sectionList,
                IsCreate = true
            };

            return View(studentViewModel);
        }

        public ActionResult Edit(int id)
        {
            var selectedStudent = studentList.Where(m => m.Id == id).FirstOrDefault();

            var studentViewModel = new StudentViewModel()
            {
                Student = selectedStudent,
                SectionList = sectionList,
                IsCreate = false
            };

            return View("Create", studentViewModel);
        }

        public ActionResult Delete(int id)
        {
            var selectedStudent = studentList.Where(m => m.Id == id).FirstOrDefault();

            studentList.Remove(selectedStudent);

            return View("Index", studentList);
        }

        [HttpPost]
        public ActionResult CreateStudent(StudentViewModel studentViewModel)
        {
            if (studentViewModel.IsCreate)
            {
                studentList.Add(studentViewModel.Student);
            }
            else
            {
                var selectedStudent = studentList.Where(m => m.Id == studentViewModel.Student.Id).FirstOrDefault();

                selectedStudent.Name = studentViewModel.Student.Name;
                selectedStudent.Id = studentViewModel.Student.Id;
                selectedStudent.Section = studentViewModel.Student.Section;
                selectedStudent.Gender = studentViewModel.Student.Gender;
                selectedStudent.IsAMemberOfAnyClub = studentViewModel.Student.IsAMemberOfAnyClub;
            }

            return RedirectToAction("Index", "Student");
        }
    }
}