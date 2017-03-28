﻿using ArtyGeek.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.DataModel.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public Guid ImageId { get; set; }
        public Role Role { get; set; }

        public List<UserModel> Friends { get; set; }
    }
}
