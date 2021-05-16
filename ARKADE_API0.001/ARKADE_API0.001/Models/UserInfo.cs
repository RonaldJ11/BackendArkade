using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ARKADE_API0._001.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NickName { get; set; }

        [Required]
        public string UserIdentification { get; set; }


        [Required]
        public string FullNames { get; set; }


        [Required]
        public bool TypeAccount { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
