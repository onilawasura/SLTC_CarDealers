using CarDealers.Models.DTOs;
using CarDealers.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealers.DataManager.Interfaces
{
    public interface IAdvertistmentRepository
    {
        ICollection<AdvertistmentsDto> GetAdvertistments();

        AdvertistmentDto GetAdvertisment(int id);
    }
}
