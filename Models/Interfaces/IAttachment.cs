namespace Models.Interfaces
{
    public interface IAttachment
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int Size { get; set; }
        public int MessageId { get; set; }
    }
}
