using RegisterationForm.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterationForm.Domain.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public string Hobby { get; set; }

        public List<UserSkills> UserSkillIds { get; set; }
    }
}
