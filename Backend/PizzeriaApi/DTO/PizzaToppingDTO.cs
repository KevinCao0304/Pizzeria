namespace PizzeriaApi.DTO
{
    public class PizzaToppingDTO
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public int Qty { get; set; }
    }
}
