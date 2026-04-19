using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Payements.Core.Entities
{
    public class Payement
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
        //public string Currency { get; set; }
        public DateTime PaymentDate { get; set; }
        //public string PayementMethod { get; set; } //Credit Card, PayPal, etc.
    }
}
