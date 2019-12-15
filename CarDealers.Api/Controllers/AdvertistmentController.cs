﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealers.DataManager.Interfaces;
using CarDealers.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealers.Api.Controllers
{
    [Route("api/advertistment")]
    [ApiController]
    public class AdvertistmentController : ControllerBase
    {

        private IAdvertistmentRepository _advertistmentRepository;

        public AdvertistmentController(IAdvertistmentRepository advertistmentRepository)
        {
            this._advertistmentRepository = advertistmentRepository;
        }

        
        
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AdvertistmentsDto>))]
        public IActionResult GetAllAdvertistment()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lstAd = _advertistmentRepository.GetAdvertistments();

            return Ok(lstAd);
        }


    }
}