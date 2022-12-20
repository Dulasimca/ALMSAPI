using ALMS_API.ManageSQL;
using Microsoft.AspNetCore.Http;
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
    public class updatebookmaster : Controller
    {
        [HttpPost("{id}")]
        public string Post(updatebookmasterEntity updatebookmaster)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.updatebookmaster(updatebookmaster);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
    }
        public class updatebookmasterEntity
        {
            public int bookid { get; set; }
            public int languageid { get; set; }
            public string bookname { get; set; }
            public string author { get; set; }
            public int bookcategoryid { get; set; }
            public int editionid { get; set; }
            public string publisheddate { get; set; }
            public int copies { get; set; }
            public string remarks { get; set; }
            public bool flag { get; set; }
        
    }
}