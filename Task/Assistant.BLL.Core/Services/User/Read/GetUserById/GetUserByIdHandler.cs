using Assistant.BLL.Core.Helpers;
using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Dto;
using Assistant.Common.Enums;
using Assistant.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.User.Read.GetUserById
{
    public sealed class GetUserByIdQuery : IRequest<ResponseModel<UserDto>>
    {
        public int UserId { get; }

        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
    }

    public class GetUserByIdHandler : BaseHandler, IRequestHandler<GetUserByIdQuery, ResponseModel<UserDto>>
    {
        public async Task<ResponseModel<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            using (var uow = UnitOfWork)
            {
                var user = await uow.UserRepository
                                 .Get(r => r.Id == request.UserId)
                                 .FirstOrDefaultAsync(cancellationToken);

                return GenerateSuccessResult(OperationType.Get, user?.ToUserDto());
            }
        }
    }
}
