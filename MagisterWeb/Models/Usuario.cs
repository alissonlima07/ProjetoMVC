﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterWeb.Models
{
    public class Usuario : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}