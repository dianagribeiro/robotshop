﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RobotStoreDataLayer.Models
{
    public class UserRoleMapping
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("UserFK")]
        public User User { get; set; }

        //public Role Role { get; set; }

        
        public long UserFK { get; set; }

        //[ForeignKey("Role")]
        //public long RoleFK { get; set; }
    }
}
