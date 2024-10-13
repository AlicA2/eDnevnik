using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class KorisniciUpdateRequestLimited
    {
        public string? KorisnickoIme { get; set; } = null!;

        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? PasswordPotvrda { get; set; }
    }
}
