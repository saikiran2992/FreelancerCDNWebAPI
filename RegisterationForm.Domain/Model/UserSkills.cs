﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterationForm.Domain.Model
{
    public class UserSkills
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
