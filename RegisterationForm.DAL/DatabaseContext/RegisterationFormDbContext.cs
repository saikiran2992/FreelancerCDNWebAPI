using Microsoft.EntityFrameworkCore;
using RegisterationForm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterationForm.DAL.DatabaseContext
{
    public class RegisterationFormDbContext:DbContext
    {
        public RegisterationFormDbContext(DbContextOptions<RegisterationFormDbContext> options):base(options)
        {

        }
      

        public DbSet<User> User { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }
    }
}
