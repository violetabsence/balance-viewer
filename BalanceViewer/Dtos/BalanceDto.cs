namespace BalanceViewer.Dtos
{
    public class BalanceDto
    {
        public int AccountId { get; set; }
        public int Period { get; set; }
        public double InBalance { get; set; }
        public double Calculation { get; set; }
    }
}
