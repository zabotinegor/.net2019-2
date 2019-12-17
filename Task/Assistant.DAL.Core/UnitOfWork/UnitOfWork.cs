using Assistant.Common;
using Assistant.DAL.Core.Models;
using Assistant.DAL.Core.Repositories.EntityRepositories;
using Assistant.DAL.Core.Repositories.EntityRepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Assistant.DAL.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AssistantContext context;
        private IUserRepository userRepository;
        private IMoneyMovementRepository moneyMovementRepository;
        
        public AssistantContext Context => context;
        
        public IUserRepository UserRepository 
        {
            get => userRepository ?? new UserRepository(context); 
            set => userRepository = value; 
        }

        public IMoneyMovementRepository MoneyMovementRepository 
        {
            get => moneyMovementRepository ?? new MoneyMovementRepository(context);
            set => moneyMovementRepository = value;
        }

        public UnitOfWork()
        {
            //TODO : add options and create context
            //var options = new DbContextOptionsBuilder<AssistantContext>()
            //        .EnableSensitiveDataLogging()
            //        .UseSqlServer(Settings.ConnectionString).Options;

            //context = new AssistantContext(options);
        }

        public bool Disposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                context.Dispose();
            }

            Disposed = true;
        }

        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("Error at applying context changes", ex);
            };
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("Error at applying context changes", ex);
            }
        }
    }
}
