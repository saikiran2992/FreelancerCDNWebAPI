using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegisterationForm.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ExceptionController : ControllerBase
    {
    }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public ApiResponse()
        {
            Success = true;
        }
    }
}
