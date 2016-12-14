
namespace Co.IService
{
    public interface IBaseService<T> where T : class
    {
        int Insert(T t);

        T GetById(int Id);
    }
}
