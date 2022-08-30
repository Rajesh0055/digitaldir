using apiNetcoreDemo.Data.Entity;

namespace apiNetcoreDemo.Interface
{/// <summary>
/// Service Manager which all business service related stuff take place 
/// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// to get all avaible service form DB
        /// </summary>
        /// <returns>list of service</returns>
        public List<ServiceMaster> GetServiceLists();

        /// <summary>
        /// to add new service 
        /// </summary>
        /// <param name="serviceItem">details of new service </param>
        /// <returns>response as ok </returns>
        public ServiceMaster AddNewService(ServiceMaster serviceItem);

        /// <summary>
        /// to update exsit 
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="serviceItem"></param>
        /// <returns>update status </returns>
        public ServiceMaster UpdateService(int serviceId, ServiceMaster serviceItem);


        /// <summary>
        /// to delete exsit service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public string DeleteService(int serviceId);
    }
}
