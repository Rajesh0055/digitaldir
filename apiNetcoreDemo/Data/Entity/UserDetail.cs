namespace apiNetcoreDemo.Data.Entity
{
    public class UserDetail
    {
        public string Email { get; set; }
        public string UserName { get; set; }

        public static implicit operator Task(UserDetail v)
        {
            throw new NotImplementedException();
        }
    }
}
