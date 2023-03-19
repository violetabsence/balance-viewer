using System.ComponentModel.DataAnnotations;

namespace BalanceViewer.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public Guid PaymentGuid { get; set; }
    }
}
