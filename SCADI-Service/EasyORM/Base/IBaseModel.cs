namespace MySqlRepository
{
    public interface IBaseModel<T> where T:IBaseModel<T>
    {
        int Id { get; }
    }
}