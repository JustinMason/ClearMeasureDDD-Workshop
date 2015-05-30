using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.AccessControl;
using System.Web;
using DDD_Sample.Infrastructure;

namespace DDD_Sample.Domain.AccountProcessingDept
{
    public class ApplicationAggregate : IAggregate
    {
        private readonly Application _application;

        public ApplicationAggregate(Application application )
        {
            _application = application;
        }

        public object GetState()
        {
            return _application;
        }
    }

    public class Application
    {
        public string Name { get; set; }
        public string SSN { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateProcessed { get; set; }
        //Properties to Application, Like application Fields
    
    }

}