namespace api_recomendation.HttpModels.V1.Admin{
    public class CheckoutRequest{
        public long Amount { get; set; }
        public string Currency { get; set; }
        
        public List<string> PaymentMethodTypes { get; set; }
    }
}