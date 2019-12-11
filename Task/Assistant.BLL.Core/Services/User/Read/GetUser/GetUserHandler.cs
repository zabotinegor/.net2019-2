using Assistant.BLL.Core.Helpers;
using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.User.Read.GetUser
{
    public sealed class GetUserQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }

        public GetUserQuery(int userId)
        {
            this.UserId = userId;
        }
    }

    public class GetUserHandler : BaseHandler, IRequestHandler<GetUserQuery, UserDto>
    {
        public Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            using(var uow = UnitOfWork)
            {
                //TODO: Change to aswync/await implementation
                var result = Task.Run(() => uow.UserRepository.Get(u => u.Id == request.UserId).FirstOrDefault()?.ToUserDto());
                return result;
            }
        }
    }
}
