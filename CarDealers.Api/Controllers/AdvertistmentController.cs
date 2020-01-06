using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealers.DataManager.Interfaces;
using CarDealers.Models.DTOs;
using CarDealers.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealers.Api.Controllers
{
    //[Route("api/advertistment")]
    [ApiController]
    public class AdvertistmentController : ControllerBase
    {

        private IAdvertistmentRepository _advertistmentRepository;

        public AdvertistmentController(IAdvertistmentRepository advertistmentRepository)
        {
            this._advertistmentRepository = advertistmentRepository;
        }



        //[Route("api/advertistment/GetAllAdvertisment")]
        //[HttpGet]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<AdvertistmentsDto>))]
        //GET : api/advertistment
        //public IActionResult GetAllAdvertistment()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var lstAd = _advertistmentRepository.GetAdvertistments(2, null);

        //    return Ok(lstAd);
        //}

        [Route("api/advertistment/GetAllAdvertisment")]
        [HttpPost]
        public IActionResult GetAllAdvertistment([FromBody] FilteredDataDto filteredDataDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lstAd = _advertistmentRepository.GetAdvertistments(filteredDataDto.LocationId, filteredDataDto.CategoryId, filteredDataDto.MinPrice, filteredDataDto.MaxPrice);

            return Ok(lstAd);
        }


        //[Route("GetAD")]
        //[HttpGet("{id}")]

        //[Route("GetAdvertisment")]
        //[HttpGet("{adId}")]

        [Route("api/advertistment/GetAdvertisment/{id:int}")]
        [HttpGet]
        public IActionResult GetAdvertistment(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var advertistment = _advertistmentRepository.GetAdvertisment(id);

            return Ok(advertistment);
        }

        [Route("api/advertistment/DeleteAdvertisment/{id:int}")]
        [HttpGet]
        public IActionResult DeleteAdvertistment(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _advertistmentRepository.DeleteAdvertistment(id);

            return Ok("Recode Delete");
        }

        [Route("api/advertistment/AddAdvertisment")]
        [HttpPost]
        public IActionResult AddAdvertisment([FromBody]Advertistment advertistment)
        {
            int adId = _advertistmentRepository.SaveAdvertisement(advertistment);
            if (adId > 0)
            {
                var xx = Ok(new { id = adId });
                return xx;
            }

            return BadRequest();
        }

        [Route("api/advertistment/AddComment")]
        [HttpPost]
        public IActionResult AddComment(UserComments comment)
        {
            var res = _advertistmentRepository.SaveComment(comment);

            return Ok(res);
        }

        [Route("api/advertistment/GetComments/{adId:int}")]
        [HttpGet]
        public IActionResult GetComments(int adId)
        {
            var lstComments = _advertistmentRepository.GetComments(adId);

            return Ok(lstComments);
        }

        [Route("api/advertistment/GetAdvertistmentByUser")]
        [HttpPost]
        public IActionResult GetAdvertistmentByUser([FromBody] UserData userData)
        {
            return Ok(_advertistmentRepository.GetAdvertistmentsByUser(userData.UserId));
        }

        [Route("api/advertistment/ManageFavouriteAdvertisment")]
        [HttpPost]
        public IActionResult ManageFavouriteAdvertisment([FromBody] FavouriteAdvertistment favouriteAdvertistment)
        {
            return Ok(_advertistmentRepository.ManageFavourite(favouriteAdvertistment));
        }

        [Route("api/advertistment/IsUserAdvertisment")]
        [HttpGet]
        public IActionResult IsUserAdvertisment(string userId, int adId)
        {
            return Ok(_advertistmentRepository.IsUserFavouriteAd(userId, adId));
        }

        [Route("api/advertistment/GetAdvertismentByFavourite")]
        [HttpGet]
        public IActionResult GetAdvertismentByFavourite(string userId)
        {
            return Ok(_advertistmentRepository.GetAdvertistmentsByFavourite(userId));
        }

    }

    public class UserData
    {
        public string UserId { get; set; }
    }


}