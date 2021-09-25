namespace Models.Interfaces
{
    public interface IAttachment
    {
        public int Id { get; set; }
        public byte[] Value { get; set; }
        public int Size { get; set; }
        public int MaxSize { get; set; } 
        public int MessageId { get; set; }
    }
}
