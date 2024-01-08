using RegisterationForm.Domain.Enum;
using RegisterationForm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterationForm.Domain.ResponseDto
{
    public class UserInfoResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Hobby { get; set; }
        public string Skills { get; set; }
        public List<int> SkillIds { get; set; }
    }
}
