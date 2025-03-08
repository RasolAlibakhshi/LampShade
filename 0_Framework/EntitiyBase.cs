namespace _0_Framework
{
    public class EntitiyBase
    {
        public long ID { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime CreateDateTime { set; get; }

        public EntitiyBase()
        {
            CreateDateTime= DateTime.Now;
            IsDeleted= false;
        }
    }
}
