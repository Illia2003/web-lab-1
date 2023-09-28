namespace Лабораторна.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string Person { get; set; }

        public string Address { get; set; }

        public int ProductId { get; set; }

        public DateTime Date {  get; set; }
    }
}
