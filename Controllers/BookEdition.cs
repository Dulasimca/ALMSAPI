using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ALMS_API.ManageSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookEdition : Controller
    {

        [HttpGet]
        public string GetBookEditionMaster()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.GetBookEditionMaster();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class BookEditionMasterEntity
    {
        public int editionid { get; set; }
        public string editionname { get; set; }
        public bool flag { get; set; }

    }
}
