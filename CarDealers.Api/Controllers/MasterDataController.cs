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


        [Route("GetAllModels")]
        [HttpGet("{brandId}")]
        public IActionResult GetModels(int brandId)
        {
            var brands = _masterDataRepository.GetModels(brandId);
            return Ok(brands);
        }
    }
}