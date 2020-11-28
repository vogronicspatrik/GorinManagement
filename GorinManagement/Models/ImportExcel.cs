using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorinManagement.Models
{
    public class ImportExcel
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
