namespace PagaDirect.Shared.Models
{
    public class PagaDirectPaymentMethodsModel
    {
        // https://secure.pagadirect.com/api-docs#tag/Methods

        public bool success { get; set; }
        public Dictionary<string, string>? methods { get; set; }
    }
}