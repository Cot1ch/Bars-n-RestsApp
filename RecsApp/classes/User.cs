using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RecsApp
{
    /// <summary>
    /// Класс пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        [Key]
        public Guid user_Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string password_hash { get; set; }
        /// <summary>
        /// Опросник для пользователя
        /// </summary>
        public Questionnaire Questionnaire { get; set; }
        /// <summary>
        /// Любимые заведения
        /// </summary>
        public ICollection<Establishment> Favourite { get; set; }
        /// <summary>
        /// Скрытые заведения
        /// </summary>
        public ICollection<Establishment> Hidden { get; set; }
        public User()
        {
            Favourite = new List<Establishment>();
            Hidden = new List<Establishment>();
        }
    }
}
