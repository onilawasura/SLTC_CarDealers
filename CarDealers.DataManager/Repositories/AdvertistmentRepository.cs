using CarDealers.DataManager.Context;
using CarDealers.DataManager.Interfaces;
using CarDealers.Models.DTOs;
using CarDealers.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealers.DataManager.Repositories
{
    public class AdvertistmentRepository : IAdvertistmentRepository
    {
        CarDealerDbContext _carDealerDbContext;

        public AdvertistmentRepository(CarDealerDbContext carDealerDbContext)
        {
            this._carDealerDbContext = carDealerDbContext;
        }

        public ICollection<AdvertistmentsDto> GetAdvertistments()
        {
            var lstAd = _carDealerDbContext.Advertistment.Where(x => x.RecordStatus == 1).ToList();

            var lstAdDto = new List<AdvertistmentsDto>();

            foreach(var ad in lstAd)
            {
                lstAdDto.Add(new AdvertistmentsDto
                {
                    AdTitle = ad.AdTitle,
                    Url = _carDealerDbContext.Image.Where(x => x.FkAdvertistmentId == ad.Id).FirstOrDefault().Url
                });
            }


            return lstAdDto;


        }
    }
}
