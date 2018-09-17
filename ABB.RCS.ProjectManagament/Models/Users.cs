using System;
using System.Collections.Generic;

namespace ABB.RCS.ProjectManagament.Models
{
    public partial class Users
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Lastlogindate { get; set; }
    }
}
