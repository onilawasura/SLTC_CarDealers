using CarDealers.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CarDealers.DataManager.Interfaces
{
    public interface IMasterDataRepository
    {
        ICollection<Category> GetCategories();

        ICollection<Brand> GetBrands();

        ICollection<Modal> GetModels(int brandId);
    }
}
