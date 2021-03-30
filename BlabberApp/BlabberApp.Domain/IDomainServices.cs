namespace BlabberApp.Domain
{
    public interface IDomainServices
    {
        void Add(IDomain o);
        IDomain Find(string ID);
        void Remove(string ID);
        void Update(IDomain o);
    }
}