using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDD_Sample.Infrastructure;

namespace DDD_Sample.Domain.MembershipServicesDept
{
    public interface IMembershipService
    {
        void IssueCard(string ssn, DateTime birthDate, string name);
    }

    public class MembershipService : IMembershipService
    {
        private readonly ICardAccountRepository _cardAccountRepository;

        public MembershipService(ICardAccountRepository cardAccountRepository)
        {
            _cardAccountRepository = cardAccountRepository;
        }


        public void IssueCard(string ssn, DateTime birthDate, string name)
        {
            var newCard = new CardAccount
            {
                SSN = ssn,
                BirthDate = birthDate,
                Name = name,
                AnnualPercentageRate = 29.99,
                CreditLimit = 5000
            };

            _cardAccountRepository.Save(newCard);
            
        }
    }

    public interface ICardAccountRepository
    {
        void Save(CardAccount cardAccount);
    }
}