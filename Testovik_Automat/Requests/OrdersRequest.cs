namespace Testovik_Automat.Requests
{
    public class OrdersRequest
    {
        public DateTime Date { get; set; }
        public int Sum { get; set; }
        public List<OrderItemRequest> Items { get; set; }
    }

    public class OrderItemRequest
    {
        public string NameTovar { get; set; }
        public int Count { get; set; }
    }
}
