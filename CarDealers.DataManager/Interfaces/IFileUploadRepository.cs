using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealers.DataManager.Interfaces
{
    public interface IFileUploadRepository
    {
        string UploadFiles(IFormCollection ifc, string hostPath, string rootPath, string uploadedFileName);
    }
}
