
using RegisterationForm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterationForm.Infrastructure.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Skill> SkillRepository { get; }
        IGenericRepository<UserSkills> UserSkillRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
