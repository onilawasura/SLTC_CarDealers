﻿using CarDealers.Models.DTOs;
using CarDealers.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealers.DataManager.Interfaces
{
    public interface IAdvertistmentRepository
    {
        ICollection<AdvertistmentsDto> GetAdvertistments(int? locationId, int? categoryId, float? minPrice, float? maxPrice);

        AdvertistmentDto GetAdvertisment(int id);

        bool DeleteAdvertistment(int id);

        int SaveAdvertisement(Advertistment advertistment);

        bool SaveComment(UserComments comments);

        ICollection<UserCommentsDto> GetComments(int adId);

        ICollection<AdvertistmentsDto> GetAdvertistmentsByUser(string userId);

        bool ManageFavourite(FavouriteAdvertistment favouriteAdvertistment);

        bool IsUserFavouriteAd(string userId, int? adId);

        ICollection<AdvertistmentsDto> GetAdvertistmentsByFavourite(string userId);

        bool AddReportedAdvertisment(ReportedAdvertisment reportedAdvertisment);
    }
}
