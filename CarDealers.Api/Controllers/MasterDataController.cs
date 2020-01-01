using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealers.DataManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealers.Api.Controllers
{
    [Route("api/masterdata")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {

        IMasterDataRepository _masterDataRepository;

        public MasterDataController(IMasterDataRepository masterDataRepository)
        {
            this._masterDataRepository = masterDataRepository;
        }

        [Route("GetAllCategories")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _masterDataRepository.GetCategories();
            return Ok(categories);
        }

        [Route("GetAllBrands")]
        [HttpGet]
        public IActionResult GetBrands()
        {
            var brands = _masterDataRepository.GetBrands();
            return Ok(brands);
        }


        [Route("GetAllModels/{brandId:int}")]
        [HttpGet]
        public IActionResult GetModels(int brandId)
        {
            var models = _masterDataRepository.GetModels(brandId);
            return Ok(models);
        }

        [Route("GetAllLocations")]
        [HttpGet]
        public IActionResult GetLocations()
        {
            var locations = _masterDataRepository.GetLocations();
            return Ok(locations);
        }
    }
}