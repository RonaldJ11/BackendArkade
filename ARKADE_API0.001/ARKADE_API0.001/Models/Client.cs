using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArkadeBackendApi.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Names { get; set; }

        [Required]
        public string Phone_Number { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
        
        [Required]
        public int Associate_Id { get; set; }
    }
}
