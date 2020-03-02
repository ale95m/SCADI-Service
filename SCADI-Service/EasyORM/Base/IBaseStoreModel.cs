namespace MySqlRepository
{
    public interface IBaseStoreModel<T>:IBaseModel<T> where T:IBaseStoreModel<T>
    {
        bool Save();
    }
}