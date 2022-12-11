using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Interfaces
{
    public interface IDiscount
    {
        public decimal CalculateDiscount();
        public decimal CalculateDiscountedPrice();
    }
}
