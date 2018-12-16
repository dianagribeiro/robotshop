using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RobotStoreDataLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Key]
        public string Username { get; set; }

        public string Password { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public int RoleId { get; set; }

    }
}
