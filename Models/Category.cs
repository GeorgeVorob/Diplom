using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Diplom.DbData;

namespace Diplom.Models
{
    public class Category
    {
        static Context _context;
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
    }
}
