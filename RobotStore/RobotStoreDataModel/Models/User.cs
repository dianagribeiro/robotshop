using System;
using System.Collections.Generic;
using System.Text;

namespace RobotStoreDataLayer.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
