using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RegisterationForm.BL.Business;
using RegisterationForm.Domain.ResponseDto;
using System.Collections.Generic;

namespace RegisterationForm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly SkillBusiness _skillBusiness;
        public SkillController(SkillBusiness skillBusiness)
        {
            _skillBusiness = skillBusiness;
        }

        [HttpGet]
        public IEnumerable<SkillDto> GetAllSkills()
        {
            return _skillBusiness.GetAllSkills();
        }

        //Exception Handling
        //A route of /error-development in the Development environment.
        //A route of /error in non-Development environments.
        //[Route("/error-development")]
        //public IActionResult HandleErrorDevelopment(
        //            [FromServices] IHostEnvironment hostEnvironment)
        //{
        //    if (!hostEnvironment.IsDevelopment())
        //    {
        //        return NotFound();
        //    }

        //    var exceptionHandlerFeature =
        //        HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        //    return Problem(
        //        detail: exceptionHandlerFeature.Error.StackTrace,
        //        title: exceptionHandlerFeature.Error.Message);
        //}

        //[Route("/error")]
        //public IActionResult HandleError() =>
        //    Problem();
    }


}
