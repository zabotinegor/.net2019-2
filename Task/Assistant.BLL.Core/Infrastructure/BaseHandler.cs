using Assistant.DAL.Core.UnitOfWork;

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
    }
}
