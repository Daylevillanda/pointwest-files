using System;

namespace CSharp.Demo7a
{
    enum PaymentMethod
    {
        CREDIT_CARD,
        DEBIT_CARD,
        PAYPAL
    }

    abstract class Payment
    {
        private string id;
        private PaymentMethod paymentMethod;
        private decimal amount;

        public Payment(): this("", PaymentMethod.CREDIT_CARD, 0)
        {

        }

        public Payment(string id, PaymentMethod paymentMethod, decimal amount)
        {
            this.id = id;
            this.paymentMethod = paymentMethod;
            this.amount = amount;
        }
    }

    class DiscountedPayment: Payment
    {
        private decimal discountPercentage;

        public DiscountedPayment(string id, PaymentMethod paymentMethod, decimal amount, decimal discountPercentage): base(id, paymentMethod, amount)
        {
            this.discountPercentage = discountPercentage;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}

