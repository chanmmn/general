using System;

namespace PolymorphismDemo
{
    // ============================================
    // PART 1: WITHOUT POLYMORPHISM
    // ============================================
    
    class CreditCardPaymentWithoutPoly
    {
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        
        public void ProcessPayment()
        {
            Console.WriteLine($"Processing Credit Card payment of ${Amount:F2}");
            Console.WriteLine($"Card: **** **** **** {CardNumber.Substring(CardNumber.Length - 4)}");
            Console.WriteLine("Validating card... Charging account... Payment approved!");
        }
    }

    class PayPalPaymentWithoutPoly
    {
        public string Email { get; set; }
        public decimal Amount { get; set; }
        
        public void ProcessPayment()
        {
            Console.WriteLine($"Processing PayPal payment of ${Amount:F2}");
            Console.WriteLine($"PayPal Email: {Email}");
            Console.WriteLine("Redirecting to PayPal... Authorization received... Payment complete!");
        }
    }

    class CryptoPaymentWithoutPoly
    {
        public string WalletAddress { get; set; }
        public decimal Amount { get; set; }
        
        public void ProcessPayment()
        {
            Console.WriteLine($"Processing Cryptocurrency payment of ${Amount:F2}");
            Console.WriteLine($"Wallet: {WalletAddress.Substring(0, 10)}...{WalletAddress.Substring(WalletAddress.Length - 6)}");
            Console.WriteLine("Broadcasting transaction... Confirming blocks... Payment confirmed!");
        }
    }

    // ============================================
    // PART 2: WITH POLYMORPHISM
    // ============================================

    // Base class
    abstract class PaymentMethod
    {
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        
        // Abstract method that must be implemented by derived classes
        public abstract void ProcessPayment();
        
        // Common method available to all payment types
        public void GenerateReceipt()
        {
            Console.WriteLine($"Transaction ID: {TransactionId}");
            Console.WriteLine($"Amount: ${Amount:F2}");
            Console.WriteLine("Receipt generated successfully.\n");
        }
    }

    // Derived classes
    class CreditCardPayment : PaymentMethod
    {
        public string CardNumber { get; set; }
        
        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing Credit Card payment of ${Amount:F2}");
            Console.WriteLine($"Card: **** **** **** {CardNumber.Substring(CardNumber.Length - 4)}");
            Console.WriteLine("Validating card... Charging account... Payment approved!");
        }
    }

    class PayPalPayment : PaymentMethod
    {
        public string Email { get; set; }
        
        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing PayPal payment of ${Amount:F2}");
            Console.WriteLine($"PayPal Email: {Email}");
            Console.WriteLine("Redirecting to PayPal... Authorization received... Payment complete!");
        }
    }

    class CryptoPayment : PaymentMethod
    {
        public string WalletAddress { get; set; }
        
        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing Cryptocurrency payment of ${Amount:F2}");
            Console.WriteLine($"Wallet: {WalletAddress.Substring(0, 10)}...{WalletAddress.Substring(WalletAddress.Length - 6)}");
            Console.WriteLine("Broadcasting transaction... Confirming blocks... Payment confirmed!");
        }
    }

    // ============================================
    // MAIN PROGRAM - E-COMMERCE CHECKOUT SYSTEM
    // ============================================

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║   E-COMMERCE PAYMENT PROCESSING DEMO   ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n");

            Console.WriteLine("========================================");
            Console.WriteLine("SCENARIO 1: WITHOUT POLYMORPHISM");
            Console.WriteLine("========================================\n");
            
            DemoWithoutPolymorphism();

            Console.WriteLine("\n========================================");
            Console.WriteLine("SCENARIO 2: WITH POLYMORPHISM");
            Console.WriteLine("========================================\n");
            
            DemoWithPolymorphism();

            Console.WriteLine("\n========================================");
            Console.WriteLine("BUSINESS BENEFITS OF POLYMORPHISM:");
            Console.WriteLine("========================================");
            Console.WriteLine("✓ Easy integration of new payment gateways");
            Console.WriteLine("✓ Unified checkout process for all payment types");
            Console.WriteLine("✓ Simplified maintenance and testing");
            Console.WriteLine("✓ Reduced code duplication and errors");
            Console.WriteLine("✓ Scalable architecture for business growth");
        }

        static void DemoWithoutPolymorphism()
        {
            Console.WriteLine("Customer cart total: $450.00\n");
            
            // Without polymorphism: Need separate handling for each payment type
            Console.WriteLine("Payment Type: Credit Card");
            CreditCardPaymentWithoutPoly ccPayment = new CreditCardPaymentWithoutPoly 
            { 
                CardNumber = "4532123456789012", 
                Amount = 150.00m 
            };
            ccPayment.ProcessPayment();
            
            Console.WriteLine("\n---");
            Console.WriteLine("Payment Type: PayPal");
            PayPalPaymentWithoutPoly paypalPayment = new PayPalPaymentWithoutPoly 
            { 
                Email = "customer@example.com", 
                Amount = 150.00m 
            };
            paypalPayment.ProcessPayment();
            
            Console.WriteLine("\n---");
            Console.WriteLine("Payment Type: Cryptocurrency");
            CryptoPaymentWithoutPoly cryptoPayment = new CryptoPaymentWithoutPoly 
            { 
                WalletAddress = "1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa", 
                Amount = 150.00m 
            };
            cryptoPayment.ProcessPayment();

            Console.WriteLine("\n⚠️  PROBLEMS:");
            Console.WriteLine("   • Cannot process mixed payment types in a loop");
            Console.WriteLine("   • Each payment type needs separate code path");
            Console.WriteLine("   • Adding new payment methods requires extensive changes");
            Console.WriteLine("   • Difficult to maintain and test");
        }

        static void DemoWithPolymorphism()
        {
            Console.WriteLine("Customer cart total: $450.00");
            Console.WriteLine("Processing multiple orders with different payment methods...\n");
            
            // With polymorphism: All payments treated uniformly
            PaymentMethod[] payments = new PaymentMethod[]
            {
                new CreditCardPayment 
                { 
                    CardNumber = "4532123456789012", 
                    Amount = 150.00m,
                    TransactionId = "TXN-CC-001"
                },
                new PayPalPayment 
                { 
                    Email = "customer@example.com", 
                    Amount = 150.00m,
                    TransactionId = "TXN-PP-002"
                },
                new CryptoPayment 
                { 
                    WalletAddress = "1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa", 
                    Amount = 150.00m,
                    TransactionId = "TXN-BTC-003"
                }
            };

            // Clean, unified payment processing loop
            decimal totalProcessed = 0;
            for (int i = 0; i < payments.Length; i++)
            {
                Console.WriteLine($"Order #{i + 1}:");
                payments[i].ProcessPayment();  // Polymorphic call - each type processes differently
                payments[i].GenerateReceipt(); // Shared behavior from base class
                totalProcessed += payments[i].Amount;
                
                if (i < payments.Length - 1) Console.WriteLine("---\n");
            }

            Console.WriteLine($"Total Revenue Processed: ${totalProcessed:F2}");
            Console.WriteLine("\n✅ ADVANTAGES:");
            Console.WriteLine("   • Single loop handles all payment types");
            Console.WriteLine("   • Easy to add Apple Pay, Google Pay, etc.");
            Console.WriteLine("   • Consistent interface for all payment gateways");
            Console.WriteLine("   • Simplified business logic and error handling");
        }
    }
}