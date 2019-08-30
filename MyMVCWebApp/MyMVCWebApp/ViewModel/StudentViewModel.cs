using MyMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCWebApp.ViewModel
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public List<Section> SectionList { get; set; }
        public bool IsCreate { get; set; }
    }
}