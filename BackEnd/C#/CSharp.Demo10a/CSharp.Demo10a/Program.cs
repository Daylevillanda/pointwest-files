using System;

namespace CSharp.Demo10a
{
    // Good Design (Functional) vs Best Design
    // Refactoring - changing the code without changing the observable behavior
    // - renaming

    interface Payment
    {
        public string ReferenceCode { get; set; }
        public decimal Amount { get; set; }
    }

    class BillingPayment : Payment
    {
        public string ReferenceCode { get; set; }
        public decimal Amount { get; set; }
    }


    class TuitionFeePayment: Payment
    {
        public string ReferenceCode { get; set; }
        public decimal Amount { get; set; }
    }

    interface IPaymentFactory
    {
        Payment GetPayment(PaymentType type);
    }

    enum PaymentType
    {
        TUITION_FEE,
        BILLING
    }

    class PaymentFactory : IPaymentFactory
    {
        private static PaymentFactory INSTANCE;

        private PaymentFactory()
        {
        }

        public static PaymentFactory GetInstance()
        {
            if(INSTANCE == null)
            {
                INSTANCE = new PaymentFactory();
            }
            return INSTANCE;
        }

        public Payment GetPayment(PaymentType type)
        {
            Payment payment;
            if(type == PaymentType.TUITION_FEE)
            {
                payment = new TuitionFeePayment();
                return payment;
            }

            if(type == PaymentType.BILLING)
            {
                payment = new BillingPayment();
                return payment;
            }

            throw new ArgumentException("Invalid payment type");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IPaymentFactory paymentFactory = PaymentFactory.GetInstance();
            Payment electricBillPayemnt = paymentFactory.GetPayment(PaymentType.BILLING);
            Payment collegeTuitionFeePayment = paymentFactory.GetPayment(PaymentType.TUITION_FEE);
        }
    }
}

