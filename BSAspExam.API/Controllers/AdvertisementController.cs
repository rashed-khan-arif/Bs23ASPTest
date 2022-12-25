using BSAspExam.API.Core;
using BSAspExam.Models.Common;
using BSAspExam.Models.Domain;
using BSAspExam.Models.Identity;
using BSAspExam.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BSAspExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : BaseController
    {
        private readonly IAdvertisementService _service;

        public AdvertisementController(IAdvertisementService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var ad = await _service.Get(id);

            return Ok(ad);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdvertisementRequest model)
        {

            var advertisement = new Advertisement
            {
                Images = model.Images,
                Price = model.Price,
                Status = AdStatus.UnPublished,
                Active = true,
                CreatedBy = CurrentUserId,
                Description = model.Description,
                LocationId = model.LocationId,
                Product = model.Product,
                Slug = model.Slug
            };

            await _service.AddAdvertisement(advertisement);

            return Ok(new AppResponse { Status = "OK", Message = "Success" });
        }
    }
}
