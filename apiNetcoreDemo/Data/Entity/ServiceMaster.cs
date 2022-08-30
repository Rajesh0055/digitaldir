using System.ComponentModel.DataAnnotations;

namespace apiNetcoreDemo.Data.Entity
{
    public class ServiceMaster
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Category { get; set; }
        public string? ServiceName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? AboutService { get; set; }

        public string? ServiceAddress { get; set; }
        public bool IsDeleted { get; set; }

    }
}
