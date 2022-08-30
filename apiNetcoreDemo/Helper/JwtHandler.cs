using apiNetcoreDemo.Data.Entity;
using apiNetcoreDemo.Interface;
using Google.Apis.Auth;

namespace apiNetcoreDemo.Helper
{
    public class JwtHandler:IJwtHandler
    {

        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        private readonly IConfigurationSection _goolgeSettings;
        private readonly IUserManager _userManager;
        public JwtHandler(IConfiguration configuration, IUserManager userManager)
        {
            _userManager = userManager;
            _configuration = configuration;
           // _jwtSettings = _configuration.GetSection("JwtSettings");
            _goolgeSettings = _configuration.GetSection("GoogleAuthSettings");
        }


        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _goolgeSettings.GetSection("clientId").Value }
                };
                var payload= await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken);
                //var payload= await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
                return payload;
            }
            catch (Exception ex)
            {
                //log an exception
                return null;
            }
        }
    }
}
