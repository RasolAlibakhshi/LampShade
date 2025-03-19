namespace InventoryManagement.Application.Contract;

public class ViewModelInventory
{
    public long ID { set; get; }
    public string ProductName { get; set; }
    public long ProductID { get; set; }
    public double UnitPrice { get; set; }
    public bool InStock { get; set; }
    public long CurrentCount { get; set; }
}