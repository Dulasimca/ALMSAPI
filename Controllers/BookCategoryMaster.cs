using ALMS_API.ManageSQL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryMaster : Controller
    {

        [HttpGet(nameof(GetBookCategoryMaster))]
        public string GetBookCategoryMaster()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.GetBookCategoryMaster();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class BookCategoryMasterEntity
    {
        public int bookcategoryid { get; set; }
        public string bookcategoryname { get; set; }
        public bool flag { get; set; }

    }
}
