using System;
using System.Text.Json.Serialization;

namespace GenerateLink.Model
{
	public class ConfirmRequestModel
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

	public class ConfirmResponseModel
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
   
}

