using SOLIDHomework.Core.Model;

namespace SOLIDHomework.Core.Services
{
    public class UserService
    {
        // that is Database-based service 
        public AccountModel GetByUsername(string username)
        {
            return new AccountModel()
                {
                    Username = "TestUser",
                    Email =  "test@test.com"
                };
        }
    }
}