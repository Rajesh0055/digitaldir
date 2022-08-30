using apiNetcoreDemo.Data.Entity;
using apiNetcoreDemo.Helper;
using apiNetcoreDemo.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace apiNetcoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private ILogger _logger;
        private IUserManager _userManager;
        private IJwtHandler _jwtHandler;
        public UserController(ILogger<ServicesController> logger, IUserManager userManager, IJwtHandler jwtHandler)
        {
            _logger = logger;
            _userManager = userManager;
            _jwtHandler=jwtHandler;

        }


        /// <summary>
        /// to add new user 
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [HttpPost("add-user")]
        public ActionResult<UserMaster> AddNewUser(UserMaster userData)
        {
            try
            {
                _userManager.AddNewUserPerofile(userData);
                return userData;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }



        /// <summary>
        /// login with username  & password 
        /// </summary>
        /// <param name="loginAuth"> login object which cantain username and password </param>
        /// <returns> user details as response if user  found</returns>

        [HttpPost("Login")]
        public async Task<IActionResult> LoginWithUserNamePassword([FromBody] LoginDto loginAuth)
        {
            try
            {
                var user = _userManager.FindByUserIdAsync(loginAuth.userName, loginAuth.password);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// login functionlity with google auth
        /// </summary>
        /// <param name="externalAuth">google required param which used for login</param>
        /// <returns>user details if user found</returns>
        [HttpPost("ExternalLogin")]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDto externalAuth)
        {
            try
            {
                var responseObject = new AuthResponseDto();
                var payload = await _jwtHandler.VerifyGoogleToken(externalAuth);
                if (payload == null)
                    return BadRequest("Invalid External Authentication.");

                var info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);

                var user = _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
               
                if (user == null)
                {
                    var userData = new UserMaster
                    {
                        UserName = payload.Name,
                        UserRole = 0,
                        Address = null,
                        IsActive = true,
                        EmailId = payload.Email,
                        CreatedDate = DateTime.Now,
                        loginProvider = info.LoginProvider,
                        Password = null,
                        ProviderKey = info.ProviderKey,
                        MobileNo = null


                    };
                    var finalRes = _userManager.AddNewUserPerofile(userData);

                    responseObject.Token = payload.JwtId;
                    responseObject.IsAuthSuccessful = true;
                    responseObject.UserMasterDetails = finalRes;

                }
                else
                {
                    return Ok(user);
                }

                return Ok(responseObject);
            }
            catch
            {
                throw ;
            }

        }




    }
}
