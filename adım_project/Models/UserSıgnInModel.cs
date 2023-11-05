using System.ComponentModel.DataAnnotations;

namespace adım_project.Models
{
    public class UserSıgnInModel
    {
        [Required(ErrorMessage = "Lüften email giriniz")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Lüften Şifrenizi giriniz")]
        public string password { get; set; }
    }
}
