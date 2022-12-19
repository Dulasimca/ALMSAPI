﻿using ALMS_API.ManageSQL;
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
    public class productmaster : ControllerBase
    {
        [HttpPost("{id}")]

        public string Productmaster(productmasterEntity productmasterEntity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                var result = manageSQL.insertproductmaster(productmasterEntity);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
        [HttpGet]
        public string Getproductmaster()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.Getproductmaster();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class productmasterEntity
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public bool flag { get; set; }


    }
}





