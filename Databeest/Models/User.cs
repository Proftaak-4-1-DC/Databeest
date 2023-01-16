using System.ComponentModel.DataAnnotations;

namespace Databeest.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? Username { get; set; } // Text datatype?

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? PasswordConfirm { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public int? Score { get; set; } = 0; // Text datatype?

        public User()
        { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;

            Email = Username + "@databeast.nl";
        }
    }
}
