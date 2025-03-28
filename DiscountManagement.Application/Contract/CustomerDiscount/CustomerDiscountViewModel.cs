﻿namespace DiscountManagement.Application.Contract.CustomerDiscount;

public class CustomerDiscountViewModel
{
    public long ProductID { get; set; }
    public string ProductName { get; set; }
    public int DiscountRate { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Reason { get; set; }
}