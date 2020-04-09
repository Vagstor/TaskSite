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
        [RegularExpression(@"^[A-ZА-Я][a-zа-я]+\s[A-ZА-Я][a-zа-я]+\s[A-ZА-Я][a-zа-я]+$", ErrorMessage = "Поле не должно содержать цифры и состоять из трех слов")]
        public string Credentials { get; set; }
        [RegularExpression(@"^[0-9][0-9]$", ErrorMessage = "Поле должно сожержать арабские цифры от 0 до 99")]
        public string Age { get; set; }

        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Поле не должно содержать цифры")]
        public string FavFood { get; set; }

        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Поле не должно содержать цифры")]
        public string Pet { get; set; }
    }
}
