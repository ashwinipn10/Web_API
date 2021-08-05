using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class RestDetails
    {
        [Key]
        public int n_RestID { get; set; }

        public string s_Name { get; set; }

        public string s_Address { get; set; }
        public string s_Contact { get; set; }


    }
}
