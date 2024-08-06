using Sample.Api.Entities;

namespace Sample.Api.Repository;

public interface ICaptchaRepository
{
    Task<string> InsertCaptcha(Captcha captcha);
    Task<string> GetCaptcha(string guid);
}