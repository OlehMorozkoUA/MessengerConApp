﻿using Models.Interfaces;
using System;

namespace Models.Classes
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string ImagePath { get; set; }
        public Status Status { get; set; }
        public bool ActiveLogin { get; set; }
    }
}
