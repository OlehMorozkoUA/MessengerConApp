using Models.Interfaces;

namespace Models.Classes
{
    public class Attachment : IAttachment
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int Size { get; set; }
        public int MessageId { get; set; }
    }
}
