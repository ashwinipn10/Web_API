using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class UserMaster
    {
        [Key]
        public int n_UserID { get; set; }

        public string s_UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string s_Email { get; set; }

        public string s_Password { get; set; }

    }
}
