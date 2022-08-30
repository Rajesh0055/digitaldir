using apiNetcoreDemo.Data.Entity;
using Google.Apis.Auth;

namespace apiNetcoreDemo.Interface
{
    public interface IJwtHandler
    {
        public Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth);
    }
}
