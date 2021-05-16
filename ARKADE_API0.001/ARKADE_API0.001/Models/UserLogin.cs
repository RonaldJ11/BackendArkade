using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArkadeBackendApi.Models
{
    public class UserLogin
    {

        [Key]
        public string NickName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
