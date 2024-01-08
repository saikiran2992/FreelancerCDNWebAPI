using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RegisterationForm.BL.Business;
using RegisterationForm.Domain.RequestDto;
using RegisterationForm.Domain.ResponseDto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterationForm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;
        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public IEnumerable<UserInfoResponseDto> GetAllUserInfo()
        {
            return _userBusiness.GetAllUserInfo();
        }

        [HttpGet("{id}",Name ="GetUser")]
        public ActionResult<UserInfoResponseDto> GetUser(int id)
        {
            if (id == 0)
                return BadRequest();

            return _userBusiness.GetUserById(id);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, EditUserDto user)
        {
            if (id == 0 || id != user.Id)
                return BadRequest();

            _userBusiness.UpdateUser(user);

            return NoContent();
        }

        [HttpPost]
        public IActionResult PostUser(CreateUserDto user)
        {
            var result = _userBusiness.InsertUser(user);

            return CreatedAtAction("GetUser", new { id=result.Id},null);
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            if (id == 0)
                return BadRequest();

            _userBusiness.DeleteUser(id);

            return NoContent();
        }
        //Exception Handling
        //A route of /error-development in the Development environment.
        //A route of /error in non-Development environments.
        
        //[Route("/error-development")]
        //public IActionResult HandleErrorDevelopment(
        //        [FromServices] IHostEnvironment hostEnvironment)
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
