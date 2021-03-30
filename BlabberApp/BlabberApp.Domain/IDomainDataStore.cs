namespace BlabberApp.Domain
{
    public interface IDomainDataStore
    {
        void Create(IDomain o);
        IDomain Read(string ID);
        void Update(IDomain o);
        void Delete(string ID);
    }
}