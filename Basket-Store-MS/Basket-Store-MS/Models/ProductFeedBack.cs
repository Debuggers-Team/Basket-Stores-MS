using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models
{
    public class ProductFeedBack
    {
        public Products Products  { get; set; }
        public int ProductId { get; set; }

        public FeedBack FeedBack  { get; set; }

        public int FeedBackId { get; set; }

    }
}
