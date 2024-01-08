using RegisterationForm.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterationForm.Domain.RequestDto
{
    public class EditUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Hobby { get; set; }
        public List<int> SkillIds { get; set; }
    }
}
