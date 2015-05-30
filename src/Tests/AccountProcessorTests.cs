using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD_Sample.Domain.AccountProcessingDept;
using DDD_Sample.Domain.MembershipServicesDept;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests
{
    [TestFixture]
    public class AccountProcessorTests
    {
        [Test]
        public void When_application_has_no_other_applications_card_is_issued()
        {
            var application = new Application();
            application.SSN = "123-123-1234";
            application.Name = "UnitTest";
            application.BirthDate = DateTime.Now;

            var applicationRepository = MockRepository.GenerateStub<IApplicationRepository>();
            var membershipService = MockRepository.GenerateStub<IMembershipService>();
            
            applicationRepository.Stub(x => x.GetApplicationBySsnAndNameAndBirthdate(null, null, DateTime.Now)).IgnoreArguments()
                .Return(new List<Application>());
            membershipService.Expect(x => x.IssueCard(application.SSN, application.BirthDate, application.Name));
            
            var service = new ApplicationProcessorService(applicationRepository,membershipService);
           
            service.EvaluateApplication(application);

            membershipService.VerifyAllExpectations();


        }
    }
}
