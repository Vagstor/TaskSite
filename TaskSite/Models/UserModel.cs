using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskSite.Models
{
    public class UserModel
    {
        //[Required]
        //public string Email { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        //[Required]
        //public string Login { get; set; }
        [MaxLength(50)]
        [Required]
        public string Credentials { get; set; }
        [Range(1, 100, ErrorMessage = "Укажите возраст от одного до ста")]
        public int? Age { get; set; }
        [Required]
        public string FavFood { get; set; }
        [Required]
        public string Pet { get; set; }
    }
}
