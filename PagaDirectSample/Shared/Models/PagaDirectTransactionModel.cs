namespace PagaDirect.Shared.Models
{
    public class PagaDirectTransactionModel
    {
        // https://secure.pagadirect.com/api-docs#tag/Payments/operation/payments.show

        public bool success { get; set; }
        public string transaction_id { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
        public decimal amount { get; set; }
        public string currency { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string reference{ get; set; } = string.Empty;

    }
}