using apiNetcoreDemo.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace apiNetcoreDemo.Interface
{
    public interface IUserManager
    {
        /// <summary>
        /// to get all avaible service form DB
        /// </summary>
        /// <returns>list of service</returns>
        public List<UserMaster> GetAllUserLists();

        /// <summary>
        /// to add new service 
        /// </summary>
        /// <param name="serviceItem">details of new service </param>
        /// <returns>response as ok </returns>
        public UserMaster AddNewUserPerofile(UserMaster userDetails);

        /// <summary>
        /// to update exsit 
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="serviceItem"></param>
        /// <returns>update status </returns>
        public UserMaster UpdateUserPerofile(int userId, UserMaster userDetails);


        /// <summary>
        /// to delete exsit service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public string DeleteUserId(int userId);
        Task<Task?> FindByEmailAsync(string email);
        public UserMaster FindByLoginAsync(string loginProvider, string providerKey);
        public UserMaster FindByUserIdAsync(string userName, string password);
        Task CreateAsync(Task user);
        Task AddLoginAsync(Task user, UserLoginInfo info);
    }
}
