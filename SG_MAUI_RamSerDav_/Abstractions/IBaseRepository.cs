using SG_MAUI_RamSerDav_.MVVM.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SG_MAUI_RamSerDav_.MVVM.Abstractions
{
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
