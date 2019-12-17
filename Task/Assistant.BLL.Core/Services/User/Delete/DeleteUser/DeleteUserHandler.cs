using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Enums;
using Assistant.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.User.Delete.DeleteUser
{
    public sealed class DeleteUserQuery : IRequest<ResponseModel<object>>
    {
        public int UserId { get; }

        public DeleteUserQuery(int userId)
        {
            UserId = userId;
        }
    }

    public class DeleteUserHandler : BaseHandler, IRequestHandler<DeleteUserQuery, ResponseModel<object>>
    {
        public async Task<ResponseModel<object>> Handle(DeleteUserQuery request, CancellationToken cancellationToken)
        {
            using (var uow = UnitOfWork)
            {
                var user = await uow.UserRepository.Get(r => r.Id == request.UserId)
                                    .FirstOrDefaultAsync(cancellationToken);

                if (user == null)
                {
                    return GenerateNotFoundResult<object>(OperationType.Delete,
                            nameof(user),
                            request.UserId);
                }

                uow.UserRepository.Remove(user);

                try
                {
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return GenerateDatabaseErrorResult<object>(OperationType.Delete,
                            ex.Message);
                }
            }

            return GenerateSuccessResult<object>(OperationType.Delete);
        }
    }
