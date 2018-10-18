using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon.Models.PaymentTypeViewModels
{
    public class PaymentTypeDeleteViewModel
    {
        public PaymentType PaymentType { get; set; }

        public PaymentTypeDeleteViewModel(PaymentType paymentType)
        {
            PaymentType = paymentType;
        }
    }
}
