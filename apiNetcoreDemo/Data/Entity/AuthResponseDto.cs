namespace apiNetcoreDemo.Data.Entity
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public bool IsAuthSuccessful { get; set; }

        public UserMaster UserMasterDetails { get; set; }
    }
}
