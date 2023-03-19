namespace BalanceViewer.Dtos
{
    public class PaymentDto
    {
        public int AccountId { get; set; }
        public string Date { get; set; }
        public double Sum { get; set; }
        public Guid PaymentGuid { get; set; }
    }
}
