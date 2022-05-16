using Basket_Store_MS.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Services
{
    public interface IUserService
    {
        public Task<UserDto> Register(RegisterUser data, ModelStateDictionary modelState);
        public Task<UserDto> Authenticate(string username, string password);
        public Task<UserDto> ResetPassword(string email, string password);
    }
}
