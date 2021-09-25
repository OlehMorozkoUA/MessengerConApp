using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
