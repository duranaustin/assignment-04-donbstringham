using System.Collections.Generic;
using BlabberApp.Domain;

namespace BlabberApp.DataStore
{
    public class InMemory : IDomainDataStore, IDomainServices
    {
        private List<IDomain> MyBuffer;

        public InMemory()
        {
            MyBuffer = new List<IDomain>();
        }

        public InMemory(IDomain[] myBuffer)
        {
            MyBuffer = new List<IDomain>();
            MyBuffer.AddRange(myBuffer);
        }

        public void Add(IDomain obj)
        {
            Create(obj);
        }

        public int Count()
        {
            return MyBuffer.Count;
        }
        public void Create(IDomain IDomain)
        {
            MyBuffer.Add(IDomain);
        }

        public void Delete(string username)
        {
            MyBuffer.RemoveAt(FindIndex(username));
        }

        public IDomain Find(string ID)
        {
            return Read(ID);
        }

        public IDomain Read(string ID)
        {
            return MyBuffer[FindIndex(ID)];
        }

        public void Remove(string ID)
        {
            Delete(ID);
        }

        public void Update(IDomain obj)
        {
            MyBuffer[FindIndex(obj.GetId())] = obj;
        }

        private int FindIndex(string ID)
        {
            return MyBuffer.FindIndex((IDomain o) => ID.Equals(o.GetId()) == true);
        }
    }
}
