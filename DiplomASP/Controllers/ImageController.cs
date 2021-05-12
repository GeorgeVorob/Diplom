using DiplomASP.Models;
using DiplomASP.Models.ViewModels;
using DiplomCore.Models;
using DiplomCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace DiplomASP.Controllers
{
    public class ImageController : Controller
    {
        DataProviderService _data;
        public ImageController(DataProviderService data)
        {
            _data = data;
        }
        public ActionResult ReturnImage(int imgID)
        {
            return File(_data.GetImageById(imgID)?.ImageContent.content ?? System.IO.File.ReadAllBytes(@"wwwroot\NoImage.jpg"), "image/jpg");
        }
    }
}
