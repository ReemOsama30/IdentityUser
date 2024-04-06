using System.ComponentModel.DataAnnotations;

namespace user_Identity.viewModel
{
    public class RegisterUserViewModel
    {
        public string userName { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
            public string address { get; set; }
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirmPassword { get; set; }
    }
}
