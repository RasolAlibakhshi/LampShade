using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory:EntitiyBase
    {
        public Inventory()
        {
            
        }
        public long ProductID { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }
        public Inventory(long productId, double unitPrice)
        {
            ProductID = productId;
            UnitPrice = unitPrice;
            InStock=true;
            CreateDateTime=DateTime.Now;
            IsDeleted=false;
        }

        public void Edit(long productId, double unitPrice)
        {
            ProductID = productId;
            UnitPrice = unitPrice;
        }

        public long CalculateCurrentInventory()
        {
            var plus= Operations.Where(x=>x.OperationType==true).Sum(x=>x.Count);
            var minus= Operations.Where(x=>x.OperationType==false).Sum(x=>x.Count);
            
            return plus - minus;
        }


        public void InCrease(long count,long opereatorid,string description)
        {
            long currentcount = CalculateCurrentInventory() + count;
            InventoryOperation operation = new InventoryOperation(true, count, opereatorid, currentcount,
                description, 0, ID);
            this.Operations.Add(operation);
            InStock = currentcount>0;
        }

        public void Reduce(long count, long opereatorid, string description,long orderid)
        {
            long currentcount = CalculateCurrentInventory() - count;
            InventoryOperation operation = new InventoryOperation(false, count, opereatorid, currentcount,
                description, orderid, ID);
            this.Operations.Add(operation);
            InStock = currentcount>0;
        }
        
    }
}
