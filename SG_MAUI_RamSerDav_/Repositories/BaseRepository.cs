
using SG_MAUI_RamSerDav_.MVVM.Abstractions;
using SG_MAUI_RamSerDav_.MVVM.Constants;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Linq.Expressions;

namespace SG_MAUI_RamSerDav_.Repositories
{
    /// <summary>
    /// Clase base para hacer  repositorio generico que realiza operaciones CRUD en una bbdd SQLite.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad para el repositorio.</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        SQLiteConnection connection;

        /// <summary>
        /// Mensaje de estado Para Informar.
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public BaseRepository()
        {
            // Inicializa la conexión a la base de datos SQLite y crea la tabla correspondiente para el tipo de entidad T
            connection = new SQLiteConnection(Constantes.DatabasePath, Constantes.Flags);
            connection.CreateTable<T>();
        }

        /// <summary>
        /// Libera los recursos utilizados por la conexión a la base de datos.
        /// </summary>
        public void Dispose()
        {
            connection.Close();
        }

        // Metodo para obtener un elemento por su ID
        public T GetItem(int id)
        {
            try
            {
                return connection.Table<T>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        // Metodo para obtener un elemento que cumple con un predicado
        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return connection.Table<T>().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        // Metodo para obtener todos los elementos
        public List<T> GetItems()
        {
            try
            {
                return connection.Table<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        // Metodo para obtener todos los elementos que cumplen con un predicado
        public List<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return connection.Table<T>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        // Metodo para obtener todos los elementos con relaciones anidadas
        public List<T> GetItemsCascade()
        {
            try
            {
                return connection.GetAllWithChildren<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        // Metodo para guardar un elemento en la base de datos
        public void SaveItem(T item)
        {
            int result = 0;
            try
            {
                if (item.Id != 0)
                {
                    result = connection.Update(item);
                    StatusMessage = $"{result} row(s) updated";
                }
                else
                {
                    result = connection.Insert(item);
                    StatusMessage = $"{result} row(s) added";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        // Metodo para guardar un elemento con relaciones anidadas
        public void SaveItemCascade(T item, bool recursive = false)
        {
            try
            {
                if (item.Id != 0)
                {
                    connection.UpdateWithChildren(item);
                }
                else
                {
                    connection.InsertWithChildren(item);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        // Metodo para eliminar un elemento de la base de datos
        public void DeleteItem(T item)
        {
            try
            {
                connection.Delete(item);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        // Metodo para eliminar un elemento con relaciones anidadas
        public void DeleteItemCascade(T item)
        {
            try
            {
                connection.Delete(item, true);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}

