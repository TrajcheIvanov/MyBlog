﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class ManageUserModel
    {
        public int Id { get; set; }


        public string Username { get; set; }


        public bool IsAdministrator { get; set; }
    }
}
