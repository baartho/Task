using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskableChallenge.Model.Users
{
    public class Customer
    {
        private Customer() { }
        public Customer(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public bool BookClubMember { get; protected set; }
        public DateTime BookClubMemberUntil { get; protected set; }

        public void BecomeBookClubMember(int totalMonths)
        {
            if (totalMonths <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            BookClubMemberUntil = DateTime.UtcNow.AddMonths(totalMonths);
            BookClubMember = true;
        }
    }
}
