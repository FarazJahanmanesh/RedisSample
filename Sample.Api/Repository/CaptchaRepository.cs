using Microsoft.Extensions.Caching.Distributed;
using Sample.Api.Entities;

namespace Sample.Api.Repository;

public class CaptchaRepository: ICaptchaRepository
{
    private readonly IDistributedCache _cache;
    
    public async Task<string> GetCaptcha(Guid guid)
    {
        var captcha = await _cache.GetStringAsync(guid.ToString());

        if (captcha == null)
            return null;

        return captcha;
    }
    public async Task InsertCaptcha(Captcha captcha)
    {
        await _cache.SetStringAsync(captcha.CaptchaKey.ToString(), captcha.CaptchaValue);
    }
}

