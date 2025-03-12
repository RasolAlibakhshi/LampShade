namespace ShopeManegement.Application.Contract.Product
{
    public class ProductViewModel
    {
        public string CategoryName { get; set; }
        public string Code { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public long CategoryId { get; set; }
        public string CreationDate { get; set; }
        public string Picture { get; set; }
    }
}