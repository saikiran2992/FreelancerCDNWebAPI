using RegisterationForm.Domain.ResponseDto;
using RegisterationForm.Infrastructure.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RegisterationForm.Domain.RequestDto;
using RegisterationForm.Domain.Model;

namespace RegisterationForm.BL.Business
{
    public class UserBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SkillBusiness _skillBusiness;
        private readonly UserSkillsBusiness _userSkillsBusiness;
        public UserBusiness(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              SkillBusiness skillsBusiness,
                              UserSkillsBusiness userSkillsBusiness)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _skillBusiness = skillsBusiness;
            _userSkillsBusiness = userSkillsBusiness;
        }

        public IEnumerable<UserInfoResponseDto> GetAllUserInfo()
        {
            var allUserInfo = _unitOfWork.UserRepository.GetAll(include: c => c.Include(d => d.UserSkillIds));

            var allUserInfoDto = _mapper.Map<List<UserInfoResponseDto>>(allUserInfo);

            foreach (var user in allUserInfoDto)
            {
                user.Skills = _skillBusiness.GetSkillsTitle(user.SkillIds);
            }

            return allUserInfoDto;
        }

        public UserInfoResponseDto GetUserById(int id)
        {
            var user = _unitOfWork.UserRepository.GetAll(include: c => c.Include(d => d.UserSkillIds)).Where(c => c.Id == id).FirstOrDefault();
            //var user = _unitOfWork.UserRepository.Get(c => c.Id == id);
            var userDto = _mapper.Map<UserInfoResponseDto>(user);

            userDto.Skills = _skillBusiness.GetSkillsTitle(userDto.SkillIds);

            return userDto;
        }

        public User InsertUser(CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();

            _userSkillsBusiness.InsertRange(user.Id, userDto.SkillIds);

            return user;
        }

        public bool UpdateUser(EditUserDto user)
        {
            try
            {
                var newUser = _mapper.Map<User>(user);
                _unitOfWork.UserRepository.Update(newUser);
                _unitOfWork.Save();

                _userSkillsBusiness.DeleteRange(user.Id);
                _userSkillsBusiness.InsertRange(user.Id, user.SkillIds);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _userSkillsBusiness.DeleteRange(user.Id);
                _unitOfWork.UserRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
