using Models.Interfaces;
using System;

namespace Models.Classes
{
    public class Message : IMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
        public int FromUserId { get; set; }
        public int ToDestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}