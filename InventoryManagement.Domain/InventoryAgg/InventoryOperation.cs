namespace InventoryManagement.Domain.InventoryAgg;

public class InventoryOperation
{
    public InventoryOperation()
    {
            
    }
    public long ID { get; private set; }
    public bool OperationType { get; private set; }
    public long Count { get; private set; }
    public long OperatorID { get; private set; }
    public DateTime OprationDateTime { get; private set; }
    public long CurrentCount { get; private set; }
    public string Description { get; private set; }
    public long OrderID { get; private set; }


    public long InventoryID { get; private set; }
    public Inventory Inventory { get; private set; }

    public InventoryOperation(bool operationType, long count, long operatorId, long currentCount, string description, long orderId, long inventoryId)
    {
        OperationType = operationType;
        Count = count;
        OperatorID = operatorId;
        CurrentCount = currentCount;
        Description = description;
        OrderID = orderId;
        InventoryID = inventoryId;
        OprationDateTime=DateTime.Now;
    }
}