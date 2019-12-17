using Assistant.Common.Dto;
using Assistant.DAL.Core.Models;

namespace Assistant.BLL.Core.Helpers
{
    public static class UserHelper
    {
        public static User ToUser(this UserDto model)
        {
            return new User
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        public static UserDto ToUserDto(this User model)
        {
            return new UserDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        //TODO : add own implementation
        public static UserDto CheckChangeableProps(this UserDto model, User dbModel)
        {
            UserDto result = model;

            //result.Name ??= dbModel.Name;
            //result.Description ??= dbModel.Description;

            return result;
        }

        public static User CheckChangeableProps(this User model, UserDto modelDto)
        {
            User result = model;

            //result.Name ??= modelDto.Name;
            //result.Description ??= modelDto.Description;

            return result;
        }
    }
}
