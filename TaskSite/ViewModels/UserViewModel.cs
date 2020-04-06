using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskSite.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}
