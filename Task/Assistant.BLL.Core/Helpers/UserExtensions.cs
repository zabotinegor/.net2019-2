using Assistant.Common.Models;
using Assistant.DAL.Core.Models;

namespace Assistant.BLL.Core.Helpers
{
    internal static class UserExtensions
    {
        internal static User ToUser(this UserDto model)
        {
            return new User
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        internal static UserDto ToUserDto(this User model)
        {
            return new UserDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }
    }
}
