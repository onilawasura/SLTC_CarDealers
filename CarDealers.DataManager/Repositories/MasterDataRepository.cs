using CarDealers.DataManager.Context;
using CarDealers.DataManager.Interfaces;
using CarDealers.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealers.DataManager.Repositories
{
    public class MasterDataRepository : IMasterDataRepository
    {

        CarDealerDbContext _carDealerDbContext;
        public MasterDataRepository(CarDealerDbContext carDealerDbContext)
        {
            this._carDealerDbContext = carDealerDbContext;
        }

        public ICollection<Brand> GetBrands()
        {
            var brands = _carDealerDbContext.Brand.ToList();
            return brands;
        }

        public ICollection<Category> GetCategories()
        {
            var cat = _carDealerDbContext.Category.ToList();
            return cat;
        }

        public ICollection<Modal> GetModels(int brandId)
        {
            var models = _carDealerDbContext.Modal.Where(x => x.FkBrandId == brandId).ToList();

            return models;
        }
    }
}
