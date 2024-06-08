using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AgroServicesAPI.Controllers
{   
    public class AgroControllerBase : ControllerBase
    {
        private readonly IConfiguration configuration;

        public Agro.Utitlity.Configuration agroConfig { get; set; }

        public AgroControllerBase(IConfiguration config)
        {
            configuration = config;
            SetConfigurationValues();
        }

        private void SetConfigurationValues()
        {
            agroConfig = new Agro.Utitlity.Configuration()
            {
                ConnectionString = configuration["ConnectionString"]
            };
        }
    }
}
