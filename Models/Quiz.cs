using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizMgmt.Models
{
    public class Quiz
    {
        public int quiz_id { get; set; }
        public string quiz_title { get; set; }
        public int cat_id { get; set; }
        public int total_marks { get; set; }
    }
}