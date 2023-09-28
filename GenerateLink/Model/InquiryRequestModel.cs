using System;
using System.Text.Json.Serialization;

namespace GenerateLink.Model
{
    public class InquiryV4RequestModel
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;
        [JsonPropertyName("customer_code")]
        public string CustomerCode { get; set; } = string.Empty;
        [JsonPropertyName("bill_code")]
        public string BillCode { get; set; } = string.Empty;
    }

    public class InquiryV4ResponseModel
    {
        [JsonPropertyName("supplier")]
        public Supplier Supplier { get; set; } = new();
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; } = new();
        [JsonPropertyName("balances")]
        public List<Balances> Balances { get; set; } = new List<Balances>();
    }

    public class InquiryV5RequestModel
    {
        [JsonPropertyName("identity_code")]
        public string IdentityCode { get; set; } = string.Empty;
        [JsonPropertyName("fee_channel")]
        public string FeeChannel { get; set; } = string.Empty;
    }
    

    public class Supplier
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("short_name")]
        public string ShortName { get; set; } = string.Empty;
        [JsonPropertyName("allow_exceed_payment")]
        public bool AllowExceedPayment { get; set; }
        [JsonPropertyName("allow_partial_payment")]
        public bool AllowPartialPayment { get; set; }
    }



    public class Customer
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("name_en")]
        public string NameEn { get; set; } = string.Empty;
    }

    public class Balances
    {
        [JsonPropertyName("bill_amount")]
        public decimal BillAmount { get; set; }
        [JsonPropertyName("fee_amount")]
        public decimal FeeAmount { get; set; }
        [JsonPropertyName("total_amount")]
        public decimal TotalAmount { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;
        [JsonPropertyName("fee_type")]
        public string FeeType { get; set; } = string.Empty;
        [JsonPropertyName("payment_token")]
        public string PaymentToken { get; set; } = string.Empty;
        [JsonPropertyName("balace")]
        public decimal Balance { get; set; }
        [JsonPropertyName("last_bill_date")]
        public string LastBillDate { get; set; } = string.Empty;
        [JsonPropertyName("last_due_date")]
        public string LastDueDate { get; set; } = string.Empty;
        [JsonPropertyName("last_pay_date")]
        public string LastPayDate { get; set; } = string.Empty;
        [JsonPropertyName("min_amount")]
        public int MinAmount { get; set; }
        [JsonPropertyName("max_amount")]
        public int MaxAmount { get; set; }
        [JsonPropertyName("customer_fee_percentage")]
        public decimal CustomerFeePercentage { get; set; }
        [JsonPropertyName("supplier_fee_percentage")]
        public decimal SupplierFeePercentage { get; set; }
        [JsonPropertyName("opening_balance")]
        public decimal OpeningBalance { get; set; }
        [JsonPropertyName("last_bills")]
        public List<LastBills> LastBills { get; set; } = new();
    }

    public class LastBills
    {
        [JsonPropertyName("bill_date")]
        public string BillDate { get; set; } = string.Empty;
        [JsonPropertyName("bill_amount")]
        public decimal BillAmount { get; set; }
        [JsonPropertyName("paid_amount")]
        public decimal PaidAmount { get; set; }
        [JsonPropertyName("total_amount")]
        public decimal TotalAmount { get; set; }
    }

    public class InquiryV5ResponseModel
    {
        [JsonPropertyName("merchant")]
        public MerchantV5 Merchant { get; set; } = new();
        [JsonPropertyName("customers")]
        public List<CustomerV5> Customers { get; set; } = new();
        [JsonPropertyName("transaction")]
        public Transaction Transaction { get; set; } = new();
        [JsonPropertyName("url")]
        public URL Url { get; set; } = new();

    }

    public class MerchantV5 : Supplier
    {

    }
    public class CustomerV5 : Customer
    {
        [JsonPropertyName("branch_code")]
        public string BranchCode { get; set; } = string.Empty;
        [JsonPropertyName("branch_name")]
        public string BranchName { get; set; } = string.Empty;
        [JsonPropertyName("bill_no")]
        public string BillNo { get; set; } = string.Empty;
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }
    public class Transaction
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("original_amount")]
        public decimal OriginalAmount { get; set; }
        [JsonPropertyName("convenience_fee_amount")]
        public decimal ConvinienceFeeAmount { get; set; }
        [JsonPropertyName("sponsor_fee_amount")]
        public decimal SponsorFeeAmount { get; set; }
        [JsonPropertyName("fee_channel")]
        public string FeeChannel { get; set; } = string.Empty;
        [JsonPropertyName("total_amount")]
        public decimal TotalAmount { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("min")]
        public decimal Min { get; set; }
        [JsonPropertyName("max")]
        public decimal Max { get; set; }
        [JsonPropertyName("payment_token")]
        public string PaymentToken { get; set; } = string.Empty;

    }
    public class URL
    {
        [JsonPropertyName("return_url")]
        public string ReturnUrl { get; set; } = string.Empty;
    }
}