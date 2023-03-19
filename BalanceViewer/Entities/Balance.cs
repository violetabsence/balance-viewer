using System.ComponentModel.DataAnnotations;

namespace BalanceViewer.Entities
{
    public class Balance
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double InBalance { get; set; }
        public double OutBalance { get; set; }
        public double Calculation { get; set; }
    }
}
