using Assistant.Common.Enums;
using Assistant.Common.Models;
using Assistant.DAL.Core.UnitOfWork;
using System.Collections.Generic;

namespace Assistant.BLL.Core.Infrastructure
{
    public abstract class BaseHandler
    {
        private IUnitOfWork work;

        protected IUnitOfWork UnitOfWork
        {
            get => work == null || work.Disposed ? (work = new UnitOfWork()) : work;
            set => work = value;
        }

        protected ResponseModel<T> GenerateSuccessResult<T>(OperationType operationType, T result = default)
        {
            return EqualityComparer<T>.Default.Equals(result, default)
                    ? new ResponseModel<T>(operationType)
                    : new ResponseModel<T>(operationType, result);
        }

        protected ResponseModel<T> GenerateIsNullResult<T>(OperationType operationType, string name)
                => new ResponseModel<T>(operationType,
                        RequestResults.ValueIsNull,
                        GenerateIsNullString(name));

        protected ResponseModel<T> GenerateDatabaseErrorResult<T>(OperationType operationType, string message)
                => new ResponseModel<T>(operationType,
                                        RequestResults.DatabaseError,
                                        message);

        protected ResponseModel<T> GenerateNotFoundResult<T>(OperationType operationType, string name, int id)
                => new ResponseModel<T>(operationType,
                        RequestResults.DatabaseError,
                        GenerateNotFoundString(name, id));
        
        private string GenerateNotFoundString(string name, int id)
        {
            return $"{name} with id = {id} doesn't exist";
        }

        private string GenerateIsNullString(string name)
        {
            return $"Model {name} that you pass is null";
        }
    }
}
