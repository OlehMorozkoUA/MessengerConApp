using Models.Interfaces;

namespace Models.Classes
{
    public class Attachment : IAttachment
    {
        public int Id { get; set; }
        public byte[] Value { get; set; }
        public int Size { get; set; }
        public int MaxSize { get; set; } = 20;
        public int MessageId { get; set; }
    }
}
