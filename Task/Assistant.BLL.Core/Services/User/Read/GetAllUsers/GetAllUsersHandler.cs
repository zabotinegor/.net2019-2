using Assistant.BLL.Core.Helpers;
using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Dto;
using Assistant.Common.Enums;
using Assistant.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.User.Read.GetAllUsers
{
    public sealed class GetAllUsersQuery : IRequest<ResponseModel<IEnumerable<UserDto>>>
    {

    }

    public class GetAllUsersHandler : BaseHandler, IRequestHandler<GetAllUsersQuery, ResponseModel<IEnumerable<UserDto>>>
    {
        public async Task<ResponseModel<IEnumerable<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            using (var uow = UnitOfWork)
            {
                var result = await uow.UserRepository.Get().ToListAsync(cancellationToken);

                return GenerateSuccessResult(OperationType.Get, result?.Select(r => r.ToUserDto()));
            }
        }
    }
}
