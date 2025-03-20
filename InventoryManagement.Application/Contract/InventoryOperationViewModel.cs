using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract
{
    public class InventoryOperationViewModel
    {
        public long ID { get;  set; }
        public bool OperationType { get;  set; }
        public long Count { get;  set; }
        public long OperatorID { get;  set; }
        public string OperatorName { get; set; }
        public string OprationDateTime { get;  set; }
        public long CurrentCount { get;  set; }
        public string Description { get;  set; }
        public long OrderID { get;  set; }


        public long InventoryID { get;  set; }
    }
}
