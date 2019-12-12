using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.User.Write.CreateUser
{
    public sealed class CreateUserQuery : IRequest<int>
    {
        public UserDto UserDto { get; }

        public CreateUserQuery (UserDto userDto)
        {
            this.UserDto = userDto;
        }
    }

    class CreateUserHandler : BaseHandler, IRequestHandler<CreateUserQuery, int>
    {
        public Task<int> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            //TODO : add my own implementation
            throw new System.NotImplementedException();
        }
    }
}
