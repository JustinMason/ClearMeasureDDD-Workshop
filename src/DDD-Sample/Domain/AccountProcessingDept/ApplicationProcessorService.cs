using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDD_Sample.Domain.MembershipServicesDept;
using DDD_Sample.Infrastructure;
using NHibernate.Event;

namespace DDD_Sample.Domain.AccountProcessingDept
{
    public class ApplicationProcessorService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMembershipService _membershipService;

        public ApplicationProcessorService(IApplicationRepository applicationRepository, IMembershipService membershipService)
        {
            _applicationRepository = applicationRepository;
            _membershipService = membershipService;
        }

        public void CaptureApplication(ApplicationAggregate application)
        {
            _applicationRepository.Save(application);   
        }

        public void EvaluateApplication(Application application)
        {
            //Check to see if applicant has an application
            //
            IEnumerable<Application> applications = _applicationRepository.GetApplicationBySsnAndNameAndBirthdate(application.SSN, application.Name,
                application.BirthDate);

            if (!applications.Any())
            {
                _membershipService.IssueCard(application.SSN, application.BirthDate, application.Name);
            }
        }
    }


    public interface IApplicationRepository :IRepository
    {
        IEnumerable<Application> GetApplicationBySsnAndNameAndBirthdate(string ssn, string name, DateTime birthDate);
    }
}