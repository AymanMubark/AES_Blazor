using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AES_Blazor.Client.Shared
{
    public class CardModel
    {
        [Required, Display(Name = "Amount")]
        public double Amount { get; set; }
        [Required, Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }

        [Required, CreditCard, Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Required, Display(Name = "Expiration Month"), Range(0, 12)]
        public long? CardExpiryMonth { get; set; }

        [Required, Display(Name = "Expiration Year"), Range(2020, 2100)]
        public long? CardExpiryYear { get; set; }

        [Required, Display(Name = "CVC Security Code")]
        public string CardCvc { get; set; }
    }
}
