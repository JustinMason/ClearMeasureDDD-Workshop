using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Configuration;

namespace DDD_Sample.Domain.MembershipServicesDept
{
    public class CardAccount
    {
        public Guid InternalAccountNumber { get; set; }

        public string Name { get; set; }
        public string SSN { get; set; }
        public DateTime BirthDate { get; set; }
        private IEnumerable<Card> Cards { get; set; }

        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }

        public decimal CreditLimit { get; set; }
        public double AnnualPercentageRate { get; set; }

        public void AddCard(Card card)
        {
            
        }

        public void DeactivateCard(Card card)
        {
            
        }
    }

    public class Card
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ActiveDate { get; set; }
        public DateTime DeactiveDate { get; set; }
        //Card Properties like CCV 
    }

    
}