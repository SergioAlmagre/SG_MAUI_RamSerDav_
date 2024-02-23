using System.Linq.Expressions;

namespace SG_MAUI_RamSerDav_.MVVM.Abstractions
{
    /// <summary>
    /// Interfaz que define las operaciones básicas de un repositorio genérico.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad que se manejará en el repositorio.</typeparam>
    public interface IBaseRepository<T> : IDisposable
    where T : TableData, new()
    {
        void SaveItem(T item);
        void SaveItemCascade(T item, bool recursive=false);
        T GetItem(int id);
        T GetItem(Expression<Func<T, bool>> predicate);
        List<T> GetItems();
        List<T> GetItemsCascade();
        List<T> GetItems(Expression<Func<T, bool>> predicate);
        void DeleteItem(T item);
        void DeleteItemCascade(T item);
    }
}
