﻿using ColdSchedulesData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.ViewModels
{
    public partial class EmployeesViewModel
    {
        public int EmpId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }
        public string FirebaseUid { get; set; }


        //extend

        public string Token { get; set; }

        public string RoleName { get; set; }

        public List<SpecialtyViewModel> Specialty { get; set; }
    }
}
