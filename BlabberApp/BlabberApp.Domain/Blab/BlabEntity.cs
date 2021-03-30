using System;

namespace BlabberApp.Domain
{
    public class BlabEntity : IDomain
    {
        // Attributes
        public string Msg { get; set; }
        public string ID { get; set; }

        public BlabEntity()
        {
            ID = NewGuid();
        }
        public BlabEntity(string message)
        {
            ID = NewGuid();
            Msg = message;
        }
        public string GetId()
        {
            return ID;
        }
        private string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}