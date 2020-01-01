using CarDealers.DataManager.Context;
using CarDealers.DataManager.Interfaces;
using CarDealers.Models.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarDealers.DataManager.Repositories
{
    public class FileUploadRepository : IFileUploadRepository
    {

        CarDealerDbContext _carDealerDbContext;

        public FileUploadRepository(CarDealerDbContext carDealerDbContext)
        {
            this._carDealerDbContext = carDealerDbContext;
        }

        public string UploadFiles(IFormCollection ifc, string hostPath, string rootPath, string uploadedFileName)
        {

            //Image img = new Image();
            int id = int.Parse(ifc.FirstOrDefault(x => x.Key == "adId").Value);

            string absolutepath = rootPath + "\\Content\\Images\\";

            string dir = absolutepath + "/Fol_" + id;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string dbFilepath = hostPath + "/Content/Images/" + "Fol_" + id;

            string path = dir + "\\";

            foreach (var formFile in ifc.Files.Select((value, index) => new { value, index }))
            {
                if (formFile.value.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(formFile.value.ContentDisposition).FileName.Trim('"');
                    string extension = Path.GetExtension(fileName);
                    string newFileName = id + "_" + formFile.index + extension;
                    string locationWithFileName = path + newFileName;


                    if (!System.IO.File.Exists(locationWithFileName))
                    {
                        using (var stream = new FileStream(locationWithFileName, FileMode.Create))
                        {
                            formFile.value.CopyTo(stream);
                        }

                        Image img = new Image();

                        img.Url = dbFilepath + "/" + newFileName;
                        img.FkAdvertistmentId = id;

                         _carDealerDbContext.Image.Add(img);
                         _carDealerDbContext.SaveChanges();

                    }
                }
            }
            return "Uploading SuccessFull";

        }
    }
}
