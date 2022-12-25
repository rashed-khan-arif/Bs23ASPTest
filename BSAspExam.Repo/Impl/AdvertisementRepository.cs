using BSAspExam.Models.Domain;
using BSAspExam.Repo.Core;
using BSAspExam.Repo.Impl;
using BSAspExam.Repositories.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Repositories.Impl
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
