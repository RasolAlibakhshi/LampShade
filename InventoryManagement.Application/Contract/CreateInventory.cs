namespace InventoryManagement.Application.Contract;

public class CreateInventory
{
    public long ProductID { get;  set; }
    public double UnitPrice { get;  set; }
    public List<ProductView> Products { get; set; }
}