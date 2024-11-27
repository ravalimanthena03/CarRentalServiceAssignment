using CarRentalServiceAssignment.Models;
using CarRentalServiceAssignment.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CarRentalServiceAssignment.Helper;
namespace CarRentalServiceAssignment.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly JwtHelper _jwtHelper;
        public UserService(UserRepository userRepository, IConfiguration configuration,JwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _jwtHelper = jwtHelper;
        }

        public async Task RegisterUser(User user) => await _userRepository.AddUser(user);

        public async Task<string> AuthenticateUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null || user.Password != password)
                return null;

            return _jwtHelper.GenerateToken(user);
        }
    }
}
