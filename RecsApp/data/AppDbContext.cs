using System.Data.Entity;

namespace RecsApp
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public AppDbContext() : base("AppContext") { }
        /// <summary>
        /// Таблица заведений
        /// </summary>
        public DbSet<Establishment> Establishments { get; set; }
        /// <summary>
        /// Таблица категорий заведений
        /// </summary>
        public DbSet<EstCategory> Categories { get; set; }
        /// <summary>
        /// Таблица типов заведений
        /// </summary>
        public DbSet<EstType> Types { get; set; }
        /// <summary>
        /// Таблица пользователей
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Таблица анкет пользователей
        /// </summary>
        public DbSet<Questionnaire> Questionnaires { get; set; }
        /// <summary>
        /// Таблица кухонь заведений
        /// </summary>
        public DbSet<EstFood> Foods { get; set; }
        /// <summary>
        /// Таблица средних чеков заведений
        /// </summary>
        public DbSet<EstAverageCheck> AverageChecks { get; set; }
    }
}
