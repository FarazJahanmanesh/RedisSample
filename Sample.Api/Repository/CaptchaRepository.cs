using Microsoft.Extensions.Caching.Distributed;
using Sample.Api.Entities;

namespace Sample.Api.Repository;

public class CaptchaRepository: ICaptchaRepository
{
    private readonly IDistributedCache _cache;
    public CaptchaRepository(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<string> GetCaptcha(string guid)
    {
        var captcha = await _cache.GetStringAsync(guid.ToString());

        if (captcha == null)
            return null;

        return captcha;
    }
    public async Task<string> InsertCaptcha(Captcha captcha)
    {
        await _cache.SetStringAsync(captcha.CaptchaKey.ToString(), captcha.CaptchaValue);
        return captcha.CaptchaKey.ToString();
    }
}

