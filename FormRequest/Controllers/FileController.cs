using Microsoft.AspNetCore.Mvc;

namespace FormRequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        [HttpPost("UploadFile")]
        public string UploadFile(IFormFile file)
        {
            return file.Name;
        }
    }
}