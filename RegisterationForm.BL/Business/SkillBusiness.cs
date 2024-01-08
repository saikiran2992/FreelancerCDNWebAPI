using AutoMapper;
using RegisterationForm.Domain.ResponseDto;
using RegisterationForm.Infrastructure.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterationForm.BL.Business
{
    public class SkillBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillBusiness(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public string GetSkillsTitle(List<int> ids)
        {
            var titleList= _unitOfWork.SkillRepository.GetAll(expression: c => ids.Contains(c.Id))?
                                                            .Select(c => c.Title)?
                                                            .ToList();
            return string.Join(", ", titleList);
        }

        public IEnumerable<SkillDto> GetAllSkills()
        {
            var allSkill = _unitOfWork.SkillRepository.GetAll();
            var allSkillDto = _mapper.Map<List<SkillDto>>(allSkill);
            return allSkillDto;
        }
    }
}
