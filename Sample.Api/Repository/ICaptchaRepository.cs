using Sample.Api.Entities;

namespace Sample.Api.Repository;

public interface ICaptchaRepository
{
    Task InsertCaptcha(Captcha captcha);
    Task<string> GetCaptcha(Guid guid);
}