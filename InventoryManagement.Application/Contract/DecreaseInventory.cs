﻿namespace InventoryManagement.Application.Contract;

public class DecreaseInventory
{
    public long InventoryId { get; set; }
    public long Count { get; set; }
    public string Description { get; set; }
    public long ProductID { get; set; }
    public long OrderID { get; set; }
}