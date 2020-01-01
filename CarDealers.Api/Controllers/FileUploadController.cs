using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CarDealers.DataManager.Context;
using CarDealers.DataManager.Interfaces;
using CarDealers.Models.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealers.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        

        IWebHostEnvironment _env;
        IFileUploadRepository _fileUploadRepository;
        CarDealerDbContext _carDealerDbContext;
        public FileUploadController(IWebHostEnvironment env, IFileUploadRepository fileUploadRepository, CarDealerDbContext carDealerDbContext)
        {
            this._env = env;
            this._fileUploadRepository = fileUploadRepository;
            this._carDealerDbContext = carDealerDbContext;
        }

        [Route("api/fileupload")]
        [HttpPost]
        public IActionResult UploadFiles()
        {

            //var files = Request.Form.Files;
            
            IFormCollection ifc = Request.Form;
            int id = int.Parse(ifc.FirstOrDefault(x => x.Key == "adId").Value);

            string absolutepath = _env.ContentRootPath + "\\Content\\Images\\";

            string dir = absolutepath + "/Fol_" + id;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string dbFilepath = Request.HttpContext.Request.Scheme + "://" + Request.HttpContext.Request.Host + "/Content/Images/" + "Fol_" + id;

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

                    if(formFile.index > 3)
                    {
                        return Ok(new { message = "Upload Successfull" });
                    }
                }
            }

            return Ok(new { message = "Upload Not Successfull" });
        }


        //[Route("api/fileupload")]
        //[HttpPost]
        //public IActionResult UploadFiles()
        //{

        //    Image img = new Image();
        //    IFormCollection ifc = Request.Form;
        //    string hostPath = Request.HttpContext.Request.Scheme + "://" + Request.HttpContext.Request.Host;
        //    string rootPath = _env.ContentRootPath;
        //    string uploadedFileName = "";

        //    var xx = _fileUploadRepository.UploadFiles(ifc, hostPath, rootPath, uploadedFileName);
        //    if (xx != null)
        //    {
        //        return Ok(new { message = "Upload Successfull" });
        //    }

        //    return Ok(new { message = "Upload Not Successfull" });
        //}
    }
}