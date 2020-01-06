using CarDealers.DataManager.Context;
using CarDealers.DataManager.Interfaces;
using CarDealers.Models.DTOs;
using CarDealers.Models.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealers.DataManager.Repositories
{
    public class AdvertistmentRepository : IAdvertistmentRepository
    {
        CarDealerDbContext _carDealerDbContext;
        //private UserManager<ApplicationUser> _userManager;

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
                Description = advertisment.Description,
                ModelType = _carDealerDbContext.Modal.FirstOrDefault(x => x.Id == advertisment.ModelId).Name,
                Latitude = advertisment.Latitude,
                Longitude = advertisment.Longitude,
                Date = advertisment.CreatedOn.ToString()
            };

            return adDto;

        }

        public ICollection<AdvertistmentsDto> GetAdvertistments(int? locationId, int? categoryId, float? minPrice, float? maxPrice)
        {
            //var lstAd = _carDealerDbContext.Advertistment.Where(x => x.RecordStatus == 1 && x.FkLocationId == locationId).ToList();
            var lstAd_one = (from x in _carDealerDbContext.Advertistment
                         where (string.IsNullOrEmpty(locationId.ToString())
                         || x.FkLocationId == locationId)
                         select x).ToList();

            var lstAd_two = (from x in lstAd_one
                         where (string.IsNullOrEmpty(categoryId.ToString()) || x.CategoryId == categoryId)
                         select x).ToList();

            var lstAd = (from x in lstAd_two
                         where ((string.IsNullOrEmpty(minPrice.ToString()) || string.IsNullOrEmpty(maxPrice.ToString())) || (x.Price >= minPrice && x.Price <= maxPrice))
                             select x).ToList();


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
                    Date = ad.CreatedOn.ToString()
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

        public bool SaveComment(UserComments comments)
        {
            _carDealerDbContext.UserComment.Add(comments);
            var addedComment = _carDealerDbContext.SaveChanges();

            return addedComment > 0 ? true : false;
        }

        public ICollection<UserCommentsDto> GetComments(int adId)
        {
            var lstUserComments = _carDealerDbContext.UserComment.Where(x => x.AdvertisementId == adId && x.RecordStatus == 1).ToList();

            List<UserCommentsDto> lstComments = new List<UserCommentsDto>();

            foreach(var comment in lstUserComments)
            {
                UserCommentsDto userCommentsDto = new UserCommentsDto();
                userCommentsDto.Comment = comment.Name;
                userCommentsDto.UserFullName = comment.UserId;
                userCommentsDto.Date = comment.CreatedOn.ToString();
                lstComments.Add(userCommentsDto);
            }

            return lstComments;
        }

        public ICollection<AdvertistmentsDto> GetAdvertistmentsByUser(string userId)
        {
            var lstAd = _carDealerDbContext.Advertistment.Where(x => x.FkUserId == userId && x.RecordStatus == 1).ToList();

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
                    Date = ad.CreatedOn.ToString()
                });
            }

            return lstAdDto;

        }

        public bool ManageFavourite(FavouriteAdvertistment favouriteAdvertistment)
        {
            
            if(IsUserFavouriteAd(favouriteAdvertistment.FkUserId, favouriteAdvertistment.FkAdvertistmentId))
            {
                _carDealerDbContext.FavouriteAdvertistment.Remove(favouriteAdvertistment);
                var isDeletedFavourite = _carDealerDbContext.SaveChanges();

                return isDeletedFavourite > 0 ? true : false;
            }
            else
            {
                _carDealerDbContext.FavouriteAdvertistment.Add(favouriteAdvertistment);
                var isAddedFavourite = _carDealerDbContext.SaveChanges();
                return isAddedFavourite > 0 ? true : false;
            }
        }

        public bool IsUserFavouriteAd(string userId, int? adId)
        {
            var isUserFav = _carDealerDbContext.FavouriteAdvertistment.Any(x => x.FkUserId == userId && x.FkAdvertistmentId == adId);

            return (isUserFav);
        }

        public ICollection<AdvertistmentsDto> GetAdvertistmentsByFavourite(string userId)
        {
            var lstAdId = _carDealerDbContext.FavouriteAdvertistment.Where(x => x.FkUserId == userId).Select(x => x.FkAdvertistmentId);

            // var lstAd = _carDealerDbContext.Advertistment.Where(x => x.FkUserId == userId && x.RecordStatus == 1).ToList();

            var lstAdDto = new List<AdvertistmentsDto>();

            foreach (var adId in lstAdId)
            {
                var advertistment = _carDealerDbContext.Advertistment.FirstOrDefault(x => x.Id == adId);

                AdvertistmentsDto advertistmentsDto = new AdvertistmentsDto();
                advertistmentsDto.AdId = advertistment.Id;
                advertistmentsDto.AdTitle = advertistment.AdTitle;
                advertistmentsDto.Url = _carDealerDbContext.Image.Where(x => x.FkAdvertistmentId == adId).FirstOrDefault().Url;
                advertistmentsDto.Destination = _carDealerDbContext.Location.Where(x => x.Id == advertistment.FkLocationId).FirstOrDefault().Name;
                advertistmentsDto.CategoryType = _carDealerDbContext.Category.Where(x => x.Id == advertistment.CategoryId).FirstOrDefault().Name;
                advertistmentsDto.Price = advertistment.Price;
                advertistmentsDto.Date = advertistment.CreatedOn.ToString();

                lstAdDto.Add(advertistmentsDto);
            }

            return lstAdDto;
        }
    }
}
