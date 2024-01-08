using RegisterationForm.DAL.DatabaseContext;
using RegisterationForm.Domain.Model;
using RegisterationForm.Infrastructure.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterationForm.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RegisterationFormDbContext _context;

        private IGenericRepository<User> _UserRepository;
        private IGenericRepository<Skill> _SkillsRepository;
        private IGenericRepository<UserSkills> _UserSkillsRepository;

        public UnitOfWork(RegisterationFormDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<User> UserRepository => _UserRepository ??= new GenericRepository<User>(_context);
        public IGenericRepository<Skill> SkillRepository => _SkillsRepository ??= new GenericRepository<Skill>(_context);
        public IGenericRepository<UserSkills> UserSkillRepository => _UserSkillsRepository ??= new GenericRepository<UserSkills>(_context);


        public void Dispose()
        {
            _context.Dispose();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
