using Assistant.BLL.Core.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.User.Delete.DeleteUser
{
    public sealed class DeleteUserQuery : IRequest<int>
    {
        public int UserId { get; }

        public DeleteUserQuery(int userId)
        {
            UserId = userId;
        }
    }

    public class DeleteUserHandler : BaseHandler, IRequestHandler<DeleteUserQuery, int>
    {
        public Task<int> Handle(DeleteUserQuery request, CancellationToken cancellationToken)
        {
            //TODO : add own implemention
            throw new System.NotImplementedException();
        }
    }
}
