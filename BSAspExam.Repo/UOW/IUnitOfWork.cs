using BSAspExam.Repositories.Impl;
using BSAspExam.Repositories.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Repo.UOW
{
    public interface IUnitOfWork
    {
        IAdvertisementRepository AdvertisementRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
