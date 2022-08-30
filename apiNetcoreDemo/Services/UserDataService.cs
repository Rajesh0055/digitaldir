using apiNetcoreDemo.Data.Entity;
using apiNetcoreDemo.Interface;
using Microsoft.AspNetCore.Identity;

namespace apiNetcoreDemo.Services
{
    public class UserDataService : IUserManager
    {

        private readonly MyDbContext myDbContext;

        public UserDataService(MyDbContext dbContext)
        {
            myDbContext = dbContext;
        }

        public Task AddLoginAsync(Task user, UserLoginInfo info)
        {
            throw new NotImplementedException();
        }

        public UserMaster AddNewUserPerofile(UserMaster userDetails)
        {
            try {
                var lastColumn = myDbContext.UserMaster.OrderBy(x => x.Id).LastOrDefault();
                if (lastColumn != null)
                {
                    userDetails.Id = lastColumn.Id + 1;
                }
                myDbContext.UserMaster.Add(userDetails);           // pass the table object 
                    myDbContext.SaveChanges();
                    return userDetails;
                
                }

            catch
               {
                throw ;
               }
           
        }

        public Task CreateAsync(Task user)
        {
            throw new NotImplementedException();
        }

        public string DeleteUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Task?> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public  UserMaster FindByLoginAsync(string loginProvider, string providerKey)
        {
            var userResponse= myDbContext.UserMaster.Where(log => log.ProviderKey== providerKey
                                       && log.loginProvider== loginProvider).FirstOrDefault();
            if (userResponse != null)
            {
                return userResponse;
            }
            else
            {
                return null;
            }
        }

        public UserMaster FindByUserIdAsync(string userName,string password)
        {
            var userResponse = myDbContext.UserMaster.Where(log => log.UserName == userName
                                       && log.Password == password
                                       && log.IsActive==true
                                       ).FirstOrDefault();
            if (userResponse != null)
            {
                return userResponse;
            }
            else
            {
                return null;
            }
        }

        public List<UserMaster> GetAllUserLists()
        {
            throw new NotImplementedException();
        }

        public UserMaster UpdateUserPerofile(int userId, UserMaster userDetails)
        {
            throw new NotImplementedException();
        }
    }
}
