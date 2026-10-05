using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizMgmt.Models
{
    public class User
    {
        public int user_id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string user_name { get; set; }
        [EmailAddress(ErrorMessage ="Write Mail Address in correct foprmate")]
        public string email { get; set; }

        [Required(ErrorMessage ="password is required")]        
        [DataType(DataType.Password)]
        public string user_password { get; set; }
    }
}