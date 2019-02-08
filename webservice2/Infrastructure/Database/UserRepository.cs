using webservice2.Domain.Users;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            await _dbContext.Save();
        }

        public async Task<User> GetById(long id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if(user == null)
            {
                throw new UserNotFoundException(id);
            }

            return user;
        }
    }
}