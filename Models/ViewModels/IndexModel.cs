using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diplom.DbData;
using Microsoft.EntityFrameworkCore;
using Diplom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Models.ViewModels
{
    public class IndexModel
    {
        public List<Category> AllCategories { get;}
        public IndexModel(List<Category> categories)
        {
                AllCategories = categories;
        }
    }
}
