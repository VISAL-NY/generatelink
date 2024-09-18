
using System.Text.Json.Serialization;

namespace GenerateLink.Model
{
	public class ConfirmV2RequestModel
	{
		[JsonPropertyName("bill_code")]
		public string BillCode { get; set; } = string.Empty;
		[JsonPropertyName("customer_code")]
		public string CustomerCode { get; set; } = string.Empty;
		[JsonPropertyName("bill_amount")]
		public decimal BillAmount { get; set; }
		[JsonPropertyName("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonPropertyName("currency")]
		public string Currency { get; set; } = string.Empty;
		[JsonPropertyName("payment_token")]
		public string PaymentToken { get; set; } = string.Empty;
		[JsonPropertyName("payment_by")]
		public string PaymentBy { get; set; } = string.Empty;
		[JsonPropertyName("payment_account")]
		public string PaymentAccount { get; set; } = string.Empty;
		[JsonPropertyName("payment_type")]
		public string PaymentType { get; set; } = string.Empty;
		[JsonPropertyName("ref_no")]
		public string RefNo { get; set; } = string.Empty;
		[JsonPropertyName("note")]
		public string Note { get; set; } = string.Empty;
		[JsonPropertyName("payment_account_name")]
		public string PaymentAccountName { get; set; } = string.Empty;
		[JsonPropertyName("payment_account_phone_number")]
		public string PaymentAccountPhoneNumber { get; set; } = string.Empty;
		[JsonPropertyName("payment_fee")]
		public decimal PaymentFee { get; set; }
		[JsonPropertyName("payment_channel")]
		public string PaymentChannel { get; set; } = string.Empty;
		[JsonPropertyName("payment_fee_charge_by")]
		public string PaymentFeeChargeBy { get; set; } = string.Empty;

    }

	public class ConfirmV2ResponseModel
	{
		[JsonPropertyName("payment_account_name")]
		public string PaymentAccountName { get; set; } = string.Empty;
		[JsonPropertyName("payment_account_phone_number")]
		public string PaymentAccountPhoneNumber { get; set; } = string.Empty;
		[JsonPropertyName("payment_fee")]
		public decimal PaymentFee { get; set; }
		[JsonPropertyName("payment_channel")]
		public string PaymentChannel { get; set; } = string.Empty;
		[JsonPropertyName("payment_fee_charge_by")]
		public string PaymentFeeChargeBy { get; set; } = string.Empty;
		[JsonPropertyName("ref_data")]
		public string RefData { get; set; } = string.Empty;
		[JsonPropertyName("receipt_code")]
		public string ReceiptCode { get; set; } = string.Empty;
		[JsonPropertyName("customer_code")]
		public string CustomerCode { get; set; } = string.Empty;
		[JsonPropertyName("customer_name")]
		public string CustomerName { get; set; } = string.Empty;
		[JsonPropertyName("paid_to")]
		public string PaidTo { get; set; } = string.Empty;
		[JsonPropertyName("paid_date")]
		public string PaidDate { get; set; } = string.Empty;
		[JsonPropertyName("currency")]
		public string Currency { get; set; } = string.Empty;
		[JsonPropertyName("bill_amount")]
		public decimal BillAmount { get; set; }
		[JsonPropertyName("fee_amount")]
		public decimal FeeAmount { get; set; }
		[JsonPropertyName("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonPropertyName("payment_by")]
		public string PaymentBy { get; set; } = string.Empty;
		[JsonPropertyName("payment_account")]
		public string PaymentAccount { get; set; } = string.Empty;
		[JsonPropertyName("payment_type")]
		public string PaymentType { get; set; } = string.Empty;
		[JsonPropertyName("ref_no")]
		public string RefNo { get; set; } = string.Empty;
		[JsonPropertyName("note")]
		public string Note { get; set; } = string.Empty;
	}

public class ConfirmV3RequestModel
	{
		[JsonPropertyName("identity_code")]
		public string IdentityCode { get; set; } = string.Empty;
		[JsonPropertyName("fee_channel")]
		public string FeeChannel { get; set; } = string.Empty;
		[JsonPropertyName("bank_ref")]
		public string BankRef { get; set; } = string.Empty;
		[JsonPropertyName("bank_date")]
		public string BankDate { get; set; } = string.Empty;
		[JsonPropertyName("original_amount")]
		public decimal OriginalAmount { get; set; }
		[JsonPropertyName("convenience_fee_amount")]
		public decimal ConvenienceFeeAmount { get; set; }
		[JsonPropertyName("sponsor_fee_amount")]
		public decimal SponsorFeeAmount { get; set; }
		[JsonPropertyName("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonPropertyName("currency")]
		public string Currency { get; set; } = string.Empty;
		[JsonPropertyName("description")]
		public string Description { get; set; } = string.Empty;
		[JsonPropertyName("payment_token")]
		public string PaymentToken { get; set; } = string.Empty;
		[JsonPropertyName("payer_account_no")]
		public string PayerAccountNo { get; set; } = string.Empty;
		[JsonPropertyName("payer_account_name")]
		public string PayerAccountName { get; set; } = string.Empty;
		[JsonPropertyName("payer_phone")]
		public string PayerPhone { get; set; } = string.Empty;
	}
  
	public class ConfirmV3ResponseModel
	{
		[JsonPropertyName("merchant")]
		public MerchantResponeV3 Merchant { get; set; } = new();
		[JsonPropertyName("transaction")]
		public TransactionResponseV3 Transaction { get; set; } = new();
	}

	public class MerchantResponeV3
	{
		[JsonPropertyName("code")]
		public string Code { get; set; } = string.Empty;
		[JsonPropertyName("name")]
		public string Name { get; set; } = string.Empty;
	}
	public class TransactionResponseV3
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } = string.Empty;
		[JsonPropertyName("original_amount")]
		public decimal OriginamAmount { get; set; }
		[JsonPropertyName("convenience_fee_amount")]
		public decimal  ConvenienceFeeAmount{ get; set; }
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
		[JsonPropertyName("bank_ref")]
		public string BankRef { get; set; } = string.Empty;
	}

  
}

