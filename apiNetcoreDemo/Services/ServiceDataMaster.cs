using apiNetcoreDemo.Data.Entity;
using apiNetcoreDemo.Interface;

namespace apiNetcoreDemo.Services
{
    public class ServiceDataMaster : IServiceManager
    {
        private readonly MyDbContext myDbContext;

        public ServiceDataMaster(MyDbContext dbContext)
        {
            myDbContext = dbContext;
        }
        public ServiceMaster AddNewService(ServiceMaster serviceItem)
        {
            myDbContext.ServiceMaster.Add(serviceItem);  // pass the table object 
            myDbContext.SaveChanges();
            return serviceItem;

        }

        

        public string DeleteService(int serviceId)
        {
            throw new NotImplementedException();
        }

        public List<ServiceMaster> GetServiceLists()
        {
            throw new NotImplementedException();
        }

        public ServiceMaster UpdateService(int serviceId, Data.Entity.ServiceMaster serviceItem)
        {
            throw new NotImplementedException();
        }

        List<Data.Entity.ServiceMaster> IServiceManager.GetServiceLists()
        {
            var userResponse = myDbContext.ServiceMaster.ToList();
            if (userResponse != null)
            {
                return userResponse;
            }
            else
            {
                return null;
            }
        }

        Data.Entity.ServiceMaster IServiceManager.UpdateService(int serviceId, Data.Entity.ServiceMaster serviceItem)
        {
            throw new NotImplementedException();
        }
    }

}

