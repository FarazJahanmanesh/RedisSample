using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Repository;

namespace Sample.Api.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ICaptchaRepository _repository;
    public UserController(ICaptchaRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> GetCaptcha()
    {
        var key = await _repository.InsertCaptcha(new Entities.Captcha { CaptchaKey = Guid.NewGuid() ,CaptchaValue ="ffff"});
        var captcha = await _repository.GetCaptcha(key);
        return Ok(captcha);
    }
}
