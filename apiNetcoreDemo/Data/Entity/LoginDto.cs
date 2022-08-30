namespace apiNetcoreDemo.Data.Entity
{
    public class LoginDto
    {
        public string userName { get; set; }
        public string password { get; set; }
        public bool IsActive { get; set; }
    }
}
