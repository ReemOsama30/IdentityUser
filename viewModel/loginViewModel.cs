using System.ComponentModel.DataAnnotations;

namespace user_Identity.viewModel
{
    public class loginViewModel
    {
        public string userName { get; set; }
        [DataType(DataType.Password)]
        public string  password { get; set; }
        public bool RememberMe { get; set; }

    }
}
