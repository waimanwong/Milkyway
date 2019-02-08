using System.Threading.Tasks;
using webservice2.Domain;

namespace webservice2.Domain.Users 
{
    public class UserNotFoundException : DomainException
    {
        public UserNotFoundException(long id) : base($"User {id.ToString()} not found") 
        { }
    }

    public class UserRegistrationForm
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public class User
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public interface IUserService 
    {
        Task RegisterUser(UserRegistrationForm user);

        Task<User> GetUserById(long id);
    }

    public interface IUserRepository
    {
        Task Add(User user);

        Task<User> GetById(long id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public Task RegisterUser(UserRegistrationForm userRegistrationForm)
        {

            //TODO Validate the form

            //Ok let's register the user
            var user = new User 
            {
                Firstname = userRegistrationForm.Firstname,
                Lastname = userRegistrationForm.Lastname
            };
            return _userRepository.Add(user);
        }

        public Task<User> GetUserById(long id)
        {
            return _userRepository.GetById(id);
        }
    }
}