namespace PagaDirect.Shared.Models
{
    public class PagaDirectPaymentResultModel
    {
        // https://secure.pagadirect.com/api-docs#tag/Payments/operation/payments.store
        public bool success { get; set; }
        public string transaction_id { get; set; } = string.Empty;
        public string redirect_url { get; set; } = string.Empty;
    }
}