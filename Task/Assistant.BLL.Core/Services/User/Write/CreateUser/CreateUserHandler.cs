using Assistant.BLL.Core.Helpers;
using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Dto;
using Assistant.Common.Enums;
using Assistant.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.User.Write.CreateUser
{
    public sealed class CreateUserQuery : IRequest<ResponseModel<int>>
    {
        public UserDto UserDto { get; }

        public CreateUserQuery(UserDto userDto)
        {
            UserDto = userDto;
        }
    }

    public class CreateUserHandler : BaseHandler, IRequestHandler<CreateUserQuery, ResponseModel<int>>
    {
        public async Task<ResponseModel<int>> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            if (request.UserDto == null)
            {
                return GenerateIsNullResult<int>(OperationType.Post,
                        nameof(request.UserDto));
            }

            using (var uow = UnitOfWork)
            {
                var user = request.UserDto.ToUser();

                uow.UserRepository.Create(user);

                try
                {
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return GenerateDatabaseErrorResult<int>(OperationType.Post,
                            ex.Message);
                }

                return GenerateSuccessResult(OperationType.Post, user.Id);
            }
        }
    }
}
