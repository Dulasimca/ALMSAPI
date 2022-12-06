using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using ALMS_API.ManageSQL;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Book : Controller
    { 
   [HttpPost(nameof(Addbook))]

        public string Addbook(BookEntity BookEntity)
    {
        try
        {
            ManageSQLConnection manageSQL = new ManageSQLConnection();
            var result = manageSQL.insertbook(BookEntity);
            return JsonConvert.SerializeObject(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return "false";
    }
    [HttpGet(nameof(GetBook))]
    public string GetBook()
    {
        {
            ManageSQLConnection manageSQL = new ManageSQLConnection();

            var result = manageSQL.GetBook();
            return JsonConvert.SerializeObject(result);
        }
    }
}
public class BookEntity
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

