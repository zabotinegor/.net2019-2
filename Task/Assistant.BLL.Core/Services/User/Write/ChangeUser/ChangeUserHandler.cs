using Assistant.BLL.Core.Infrastructure;
using Assistant.BLL.Core.Services.User.Read.GetUser;
using Assistant.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.User.Write.ChangeUser
{
    public sealed class ChangeUserQuery : IRequest<UserDto>
    {
        public UserDto UserDto { get; }

        public ChangeUserQuery(UserDto userDto)
        {
            UserDto = userDto;
        }
    }

    public class ChangeUserHandler : BaseHandler, IRequestHandler<GetUserQuery, UserDto>
    {
        public Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            //TODO : add own implemention
            throw new System.NotImplementedException();
        }
    }
}
