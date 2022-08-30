using System.ComponentModel.DataAnnotations;

namespace apiNetcoreDemo.Data.Entity
{
    public class UserMaster
    {
        [Key]
        public int Id { get; set; }
        public string ?  UserName { get; set; }
        public string ? Password { get; set; }
        public string ? EmailId { get; set; }
        public string ? Address { get; set; }
        public string ? MobileNo { get; set; }
        public bool? IsActive { get; set; }
        public int ? UserRole { get; set; }
        public string ? loginProvider { get; set; }
        public string? ProviderKey { get; set; }
        public DateTime CreatedDate { get; set; }

        

        

    }
}
