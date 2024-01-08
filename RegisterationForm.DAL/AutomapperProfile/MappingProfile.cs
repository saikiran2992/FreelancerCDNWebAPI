using AutoMapper;
using RegisterationForm.Domain.Model;
using RegisterationForm.Domain.RequestDto;
using RegisterationForm.Domain.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterationForm.DAL.AutomapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserInfoResponseDto>().ForMember(c => c.SkillIds,d => d.MapFrom(map => map.UserSkillIds.Select(p => p.SkillId)));
            CreateMap<EditUserDto, User>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UserInfoResponseDto, User>();
            CreateMap<Skill, SkillDto>();

        }
    }
}
