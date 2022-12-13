using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using ALMS_API.ManageSQL;

namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Studentreg : Controller
    {
        [HttpPost(("{id}"))]

        public string Post(StudentregEntity StudentregEntity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                var result = manageSQL.insertstudentreg(StudentregEntity);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
        [HttpGet]
        public string Getstudentreg()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.Getstudentreg();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class StudentregEntity
    {
        public int sno { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int regno { get; set; }
        public int genderid { get; set; }
        public DateTime dob { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int pincode { get; set; }
        public int collegeid { get; set; }
        public int courseid { get; set; }
        public int department { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public bool flag { get; set; }

    }
}
