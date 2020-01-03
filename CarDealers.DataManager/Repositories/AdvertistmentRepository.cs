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

        public AdvertistmentDto GetAdvertisment(int id)
        {
            var advertisment = _carDealerDbContext.Advertistment.Where(x => x.Id == id && x.RecordStatus == 1).FirstOrDefault();

            var adDto = new AdvertistmentDto
            {
                adId = advertisment.Id,
                BrandType = _carDealerDbContext.Brand.FirstOrDefault(x => x.Id == advertisment.FkBrandId).Name,
                Urls = _carDealerDbContext.Image.Where(x => x.FkAdvertistmentId == advertisment.Id).Select(x => x.Url).ToList(),
                CategoryType = _carDealerDbContext.Category.Where(x => x.Id == advertisment.CategoryId).FirstOrDefault().Name,
                Destination = _carDealerDbContext.Location.FirstOrDefault(x => x.Id == advertisment.FkLocationId).Name,
                //ModelType = _carDealerDbContext.Modal.Where(x => x.Id == advertisment.)
                BodyType = advertisment.BodyType,
                Capacity = advertisment.Capacity,
                Condition = advertisment.Condition,
                Contactno = advertisment.Contactno,
                Edition = advertisment.Edition,
                Email = advertisment.Email,
                FkUserId = advertisment.FkUserId,
                FuelType = advertisment.FuelType,
                Grade = advertisment.Grade,
                Milage = advertisment.Millage,
                ModelYear = advertisment.ModelYear,
                Name = advertisment.Name,
                Negotiable = advertisment.Negotiable,
                Price = advertisment.Price,
                Transmission = advertisment.Transmission,
            };

            return adDto;

        }

        public ICollection<AdvertistmentsDto> GetAdvertistments()
        {
            var lstAd = _carDealerDbContext.Advertistment.Where(x => x.RecordStatus == 1).ToList();

            var lstAdDto = new List<AdvertistmentsDto>();

            foreach(var ad in lstAd)
            {
                lstAdDto.Add(new AdvertistmentsDto
                {
                    AdId = ad.Id,
                    AdTitle = ad.AdTitle,
                    Url = _carDealerDbContext.Image.Where(x => x.FkAdvertistmentId == ad.Id).FirstOrDefault().Url,
                    Destination = _carDealerDbContext.Location.Where(x => x.Id == ad.FkLocationId).FirstOrDefault().Name,
                    CategoryType = _carDealerDbContext.Category.Where(x => x.Id == ad.CategoryId).FirstOrDefault().Name,
                    Price = ad.Price,
                }); 
            }


            return lstAdDto;

        }

        public bool DeleteAdvertistment(int id)
        {
            var lstAd = _carDealerDbContext.Advertistment.FirstOrDefault(x => x.RecordStatus == 1 && x.Id == id);

            lstAd.RecordStatus = 0;

            _carDealerDbContext.SaveChanges();

            return true;
        }

        public int SaveAdvertisement(Advertistment advertistment)
        {
             _carDealerDbContext.Advertistment.Add(advertistment);
            _carDealerDbContext.SaveChanges();
            return advertistment.Id;

        }
    }
}
