﻿using BSAspExam.Models.Domain;
using BSAspExam.Repo.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Services.Impl
{
    public class AdvertisementService : IAdvertisementService
    {
        public IUnitOfWork _unitOfWork;
        public AdvertisementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddAdvertisement(Advertisement ad)
        {
            _unitOfWork.AdvertisementRepository.Add(ad);

            await _unitOfWork.CommitAsync();
        }

        public async Task<Advertisement> Get(int id)
        {
            return await _unitOfWork.AdvertisementRepository.GetAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Advertisement>> GetAll()
            => await _unitOfWork.AdvertisementRepository.GetAllAsync();
    }
}