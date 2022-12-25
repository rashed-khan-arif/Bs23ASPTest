using BSAspExam.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Services
{
    public interface IAdvertisementService
    {
        public Task<Advertisement> Get(int id);
        public Task<IEnumerable<Advertisement>> GetAll();
        public Task<bool> AddAdvertisement(Advertisement ad);
    }
}
