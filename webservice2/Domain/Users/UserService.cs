using System.Threading.Tasks;

namespace webservice2.Domain.Users 
{

    public class User
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public interface IUserService 
    {
        Task RegisterUser(User user);
    }

    public interface IUserRepository
    {
        Task Add(User user);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public Task RegisterUser(User user)
        {
            return _userRepository.Add(user);
        }
    }
}