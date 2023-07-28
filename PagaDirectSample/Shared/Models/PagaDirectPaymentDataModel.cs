namespace PagaDirect.Shared.Models
{
    public class PagaDirectPaymentDataModel
    {
        public string PagaDirectEndpoint { get; set; } = string.Empty;
        public string PagaDirectApiKey { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Reference { get; set; } = string.Empty;
        public string ReturnUrl { get; set; } = string.Empty;

        // https://secure.pagadirect.com/api-docs#tag/Payments/operation/payments.store
        // Add postback URL
        // Add Forced Payment Methods
        // - Credit Card
        // - iDeal
    }
}