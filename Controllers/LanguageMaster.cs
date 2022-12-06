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
    public class LanguageMaster : Controller
    {

        [HttpGet(nameof(GetLanguageMaster))]
        public string GetLanguageMaster()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.GetLanguageMaster();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class LanguageMasterEntity
    {
        public int languageid { get; set; }
        public string languagename { get; set; }
        public bool flag { get; set; }

    }
}
