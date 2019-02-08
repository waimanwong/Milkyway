using webservice2.Domain.Users;
using System.Threading.Tasks;

namespace webservice2.Infrastucture.Database 
{
    public class UserRepository : IUserRepository
    {

        private readonly IWebservice2DbContext _dbContext;
        public UserRepository(IWebservice2DbContext dbContext)
        {
            _dbContext  = dbContext;
        }

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
            _dbContext.Commit();
        }
    }
}