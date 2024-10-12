﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entity.Security
{
    public class ApplicationUser:IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
