using System;
using System.Collections.Generic;

namespace WpfApp3.Models
{
    public partial class Contact
    {
        public int IdContact { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Username { get; set; }
        public string? Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Photo { get; set; }
    }
}
