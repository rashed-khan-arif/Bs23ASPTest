using BSAspExam.Repo.Core;
using BSAspExam.Repositories.Impl;
using BSAspExam.Repositories.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Repo.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;
        private AdvertisementRepository _advertisementRepository;


        public UnitOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAdvertisementRepository AdvertisementRepository
        {
            get { return _advertisementRepository = _advertisementRepository ?? new AdvertisementRepository(_dbContext); }
        }


        public void Commit()
            => _dbContext.SaveChanges();


        public async Task<int> CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
