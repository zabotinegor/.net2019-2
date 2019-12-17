using Assistant.BLL.Core.Helpers;
using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Dto;
using Assistant.Common.Enums;
using Assistant.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.User.Write.UpdateUser
{
    public sealed class UpdateUserQuery : IRequest<ResponseModel<UserDto>>
    {
        public UserDto UserDto { get; }

        public UpdateUserQuery(UserDto userDto)
        {
            UserDto = userDto;
        }
    }

    public class UpdateUserHandler : BaseHandler, IRequestHandler<UpdateUserQuery, ResponseModel<UserDto>>
    {
        public async Task<ResponseModel<UserDto>> Handle(UpdateUserQuery request, CancellationToken cancellationToken)
        {
            using (var uow = UnitOfWork)
            {
                var user = await uow.UserRepository
                                 .Get(r => r.Id == request.UserDto.Id)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(cancellationToken);

                if (user == null)
                {
                    return GenerateNotFoundResult<UserDto>(OperationType.Put,
                            nameof(user),
                            request.UserDto.Id);
                }

                user = request.UserDto
                              .CheckChangeableProps(user)
                              .ToUser();

                uow.UserRepository.Update(user);

                try
                {
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return GenerateDatabaseErrorResult<UserDto>(OperationType.Put,
                            ex.Message);
                }

                return GenerateSuccessResult(OperationType.Put, user.ToUserDto());
            }
        }
    }
}
