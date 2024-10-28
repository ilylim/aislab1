using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;

namespace DataAccessLayer.Dapper
{
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject, new()
    {
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Сергей\\source\\repos\\aislab1\\WinFormsApp\\Database1.mdf;Integrated Security=True";
        IDbConnection db = new SqlConnection(connectionString);

        /// <summary>
        /// Метод добавления объекта в БД (Dapper)
        /// </summary>
        /// <param name="obj">добавляемый объект</param>
        public void Create(T obj)
        {
            var sqlQuery = string.Empty;
            if (obj is Student)
            {
                sqlQuery = $"INSERT INTO Students (Name, [Group], Speciality) VALUES(@Name, @Group, @Speciality); SELECT CAST(SCOPE_IDENTITY() as int)";
                int studentId = db.Query<int>(sqlQuery, obj).FirstOrDefault();
                obj.Id = studentId;
            }
        }

        /// <summary>
        /// Метод удаления объекта из БД (Dapper)
        /// </summary>
        /// <param name="obj">удаляемый объект</param>
        public void Delete(T obj)
        {
            var sqlQuery = "DELETE FROM Students WHERE Id = @Id";
            db.Query<T>(sqlQuery, obj);
        }

        /// <summary>
        /// Метод сбора информации из БД (Dapper)
        /// </summary>
        /// <returns>коллекция со всеми объектами опр. таблицы БД</returns>
        public IEnumerable<T> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<T>("SELECT * FROM Students").ToList();
            }
        }

        /// <summary>
        /// Метод обновления информации в БД (Dapper)
        /// </summary>
        /// <param name="obj">измененный объект</param>
        public void Update(T obj)
        {
            var sqlQuery = string.Empty;
            if (obj is Student)
            {
                Student student = obj as Student;
                sqlQuery = $"UPDATE Students SET Name = @Name, [Group] = @Group, " +
                $"Speciality = @Speciality WHERE Id = @Id";
                db.Query<T>(sqlQuery, obj);
            }  
        }
    }
}
