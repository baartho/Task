using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskableChallenge.Model.Common;

namespace TaskableChallenge.Model.Products
{
    public class ProductType : ValueObject<ProductType>
    {
        private ProductType(string value, string text) { Value = value; Text = text; }

        public string Value { get; private set; }
        public string Text { get; private set; }

        public static ProductType Video { get { return new ProductType("Video", "Video"); } }
        public static ProductType Book { get { return new ProductType("Book", "Book"); } }
        public static ProductType BookClubMembership { get { return new ProductType("BookClubMembership", "Book Club Membership"); } }


        public static List<ProductType> GetAll()
        {
            var list = new List<ProductType>();
            list.Add(Video);
            list.Add(Book);
            list.Add(BookClubMembership);
            return list;
        }

        public static ProductType Get(string value)
        {
            var list = GetAll();
            return list.First(y => y.Value == value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}