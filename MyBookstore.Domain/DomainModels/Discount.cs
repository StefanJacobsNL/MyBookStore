using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DomainModels
{
    public class Discount
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool CheckIfDateIsValid()
        {
            if (StartDate <= DateTime.Now && DateTime.Now <= EndDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
