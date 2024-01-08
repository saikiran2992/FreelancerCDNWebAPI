using RegisterationForm.Domain.Model;
using RegisterationForm.Infrastructure.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterationForm.BL.Business
{
    public class UserSkillsBusiness
    {
        private IUnitOfWork _unitOfWork;

        public UserSkillsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<UserSkills> GetByUserId(int userId)
        {
            return _unitOfWork.UserSkillRepository.GetAll(expression: c => c.UserId == userId)?.ToList();
        }
        public void DeleteRange(int userId)
        {
            var userSkills = GetByUserId(userId);
            if (userSkills.Count > 0)
            {
                _unitOfWork.UserSkillRepository.DeleteRange(userSkills);
                _unitOfWork.Save();
            }
        }
        public void InsertRange(int userId, List<int> skillsIds)
        {
            if (skillsIds.Count < 1) return;

            foreach (var skillid in skillsIds)
            {
                _unitOfWork.UserSkillRepository.Insert(new UserSkills()
                                                               {
                                                                   UserId = userId,
                                                                   SkillId = skillid
                });
                _unitOfWork.Save();
            }
        }
    }
}
