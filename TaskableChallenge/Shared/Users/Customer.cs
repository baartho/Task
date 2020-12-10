using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskableChallenge.Model.Users
{
    public class Customer : IdentityUser
    {
        public bool BookClubMember { get; set; }
        public DateTime BookClubMemberUntil { get; set; }
    }
}
