namespace BalanceViewer.Dtos
{
    public class BalanceSheetDto
    {
        public int AccountId { get; set; }
        public int Period { get; set; }
        public double InBalance { get; set; }
        public double OutBalance { get; set; }
        public double Calculation { get; set; }
        public double Paid { get; set; }
    }
}
