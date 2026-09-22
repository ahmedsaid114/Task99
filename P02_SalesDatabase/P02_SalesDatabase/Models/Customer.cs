using System;
using System.Collections.Generic;
using System.Text;

namespace P02_SalesDatabase.Models
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CreditCardNumber { get; set; } = null!;
    }
}
