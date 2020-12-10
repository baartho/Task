using NUnit.Framework;
using System;
using TaskableChallenge.Model;
using TaskableChallenge.Model.Orders;
using TaskableChallenge.Model.Users;

namespace TaskableChallenge.UnitTests
{
    public class CustomerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(50)]
        public void CustomerBecomeBookClubMemberForXMonths(int totalMonths)
        {
            Customer customer = new Customer("Bartho");

            customer.BecomeBookClubMember(totalMonths);

            Assert.That(Math.Abs((customer.BookClubMemberUntil - DateTime.UtcNow.AddMonths(totalMonths)).TotalSeconds) < 1);
        }

        [Test]
        public void CustomerBecomeBookClubMemberForNegativeMonthsThrowsException()
        {
            Customer customer = new Customer("Bartho");

            var totalMonths = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => customer.BecomeBookClubMember(totalMonths));
        }
    }
}