using ALMS_API.ManageSQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class updatestudentreg : Controller
    {
        [HttpPost("{id}")]
        public string Post(updatestudentregEntity updatestudentreg)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.updatestudentreg(updatestudentreg);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
    }
    public class updatestudentregEntity
    {
        public int sno { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int regno { get; set; }
        public int genderid { get; set; }
        public string dob { get; set; }
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

