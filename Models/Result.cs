using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizMgmt.Models
{
    public class Result
    {
        public int result_id {  get; set; }
        [DataType(DataType.Date)]
        public DateTime attempt_date { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public int quiz_id {  get; set; }
        public string quiz_title { get; set; }
        public int score { get; set; }
        public string remarks { get; set; }
    }
}