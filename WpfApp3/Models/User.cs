using System;
using System.Collections.Generic;

namespace WpfApp3.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Username { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }
    }
}
