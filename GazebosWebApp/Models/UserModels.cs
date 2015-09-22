﻿using System;

namespace GazebosWebApp.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}