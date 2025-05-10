using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace RecsApp
{
    /// <summary>
    /// Класс, записывающий данные о заведениях с Excel в базу данных
    /// </summary>
    public static class AddFromExcel
    {
        /// <summary>
        /// Метод загружает типы, категории, кухни и чеки заведений из Excel файла в базу данных
        /// </summary>
        public static void AddTypesCatsFoodsChecksToDB()
        {
            var path = $"{Directory.GetCurrentDirectory()}..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору", 
                    "Файл не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var wb = new XLWorkbook(path);
            List<string> sheets = new List<string>() { 
                "Типы",
                "Категории", 
                "Кухня",
                "Средний чек"
            };

            using (var db = new AppDbContext())
            {
                foreach (var sheet in sheets) 
                {
                    var ws = wb.Worksheet(sheet).RowsUsed();

                    foreach (var row in ws)
                    {
                        if (row.RowNumber() == 1)
                        {
                            continue;
                        }
                        if (sheet == "Типы" 
                            && Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidType) 
                            && db.Types.Find(guidType) == null)
                        {
                            db.Types.Add(new EstType() 
                            { 
                                Id = guidType, 
                                Title = row.Cell(1).Value.ToString() 
                            });
                        }
                        else if (sheet == "Категории"
                            && Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidCat) 
                            && db.Categories.Find(guidCat) == null)
                        {
                            db.Categories.Add(new EstCategory() 
                            { 
                                Id = guidCat, 
                                Title = row.Cell(1).Value.ToString() 
                            });
                        }
                        else if (sheet == "Кухня"
                            && Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidFood) 
                            && db.Foods.Find(guidFood) == null)
                        {
                            db.Foods.Add(new EstFood() 
                            { 
                                Id = guidFood, 
                                Title = row.Cell(1).Value.ToString() 
                            });
                        }
                        else if (sheet == "Средний чек"
                            && Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidAv) 
                            && db.AverageChecks.Find(guidAv) == null)
                        {
                            db.AverageChecks.Add(new EstAverageCheck() 
                            { 
                                Id = guidAv, 
                                Title = row.Cell(1).Value.ToString() 
                            });
                        }
                    }
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод загружает информацию о заведениях из Excel файла
        /// </summary>
        public static void AddEstablishmentsToDB()
        {
            var path = $"{Directory.GetCurrentDirectory()}" +
                $"..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору", 
                    "Файл не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var wb = new XLWorkbook(path);

            if (!wb.TryGetWorksheet("Заведения", out IXLWorksheet works))
            {
                MessageBox.Show("Лист 'Заведения' не найден!\nОбратитесь к администратору");
                return;
            }
            var ws = works.RowsUsed();

            using (var db = new AppDbContext())
            {
                var IsEmpty = false;
                foreach (var row in ws)
                {
                    if (row.RowNumber() == 1)
                    {
                        continue;
                    }
                    var name = row.Cell(1).Value.ToString();
                    var description = row.Cell(2).Value.ToString();
                    var type = GetTypeFromTable(wb, row.Cell(3).Value.ToString());
                    var categories = GetSmthFromTable(wb, "Категории", row.Cell(4).Value.ToString());
                    var address = row.Cell(5).Value.ToString();
                    var rating = double.TryParse(
                        row.Cell(6).Value.ToString().Replace('.', ','), 
                        out double rat) ? rat : 0;
                    if (rating > 5)
                    {
                        rating = 5;
                    }
                    else if (rating < 0)
                    {
                        rating = 0;
                    }
                    var link = row.Cell(7).Value.ToString();
                    var pathsToPhoto = row.Cell(8).Value.ToString();
                    var food = GetSmthFromTable(wb, "Кухня", row.Cell(9).Value.ToString());
                    var average = GetSmthFromTable(wb, "Средний чек", row.Cell(10).Value.ToString());
                    var stringSimilar = row.Cell(11).Value.ToString();                  


                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(description) ||
                        type == Guid.Empty || 
                        categories.Count == 0 || categories.Any(c => c == Guid.Empty)
                        || food.Count == 0 || food.Any(f => f == Guid.Empty)
                        || average.Count == 0 || average.Any(a => a == Guid.Empty)
                        || string.IsNullOrEmpty(address))
                    {
                        IsEmpty = true;
                    }

                    if ((from est in db.Establishments
                         where est.Name == name
                         select est).Count() != 0
                         &&
                        (from est in db.Establishments
                         where est.Address == address
                         select est).Count() != 0)
                    {
                        continue;
                    }

                    var establishment = new Establishment()
                    {
                        Name = name,
                        Description = description,
                        Type = db.Types.Find(type),
                        Address = address,
                        Rating = rating,
                        Link = link,
                        PathsToPhoto = pathsToPhoto,
                        Similar = stringSimilar
                    };

                    foreach (var c in categories)
                    {
                        establishment.Categories.Add(db.Categories.Find(c));
                    }
                    foreach (var f in food)
                    {
                        establishment.Foods.Add(db.Foods.Find(f));
                    }
                    establishment.Check = decimal.TryParse(row.Cell(10).Value.ToString(), 
                        out decimal ch) ? ch : 0m;
                    establishment.Average = db.AverageChecks.Find(average[0]);
                    
                    db.Establishments.Add(establishment);

                }
                if (IsEmpty)
                {
                    MessageBox.Show("Отображенные данные будут не полными!\n" +
                        "Обратитесь к администратору", "Часть данных утеряна", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод возвращает guid типа, считанный с файла
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Guid GetTypeFromTable(IXLWorkbook wb, string type)
        {
            foreach (var row in wb.Worksheet("Типы").RowsUsed())
            {
                if (row.RowNumber() == 1)
                {
                    continue;
                }
                if (row.Cell(1).Value.ToString() == type 
                    && new AppDbContext().Types.Find(
                        GetGuidFromString(row.Cell(2).Value.ToString())) != null)
                {
                    return GetGuidFromString(row.Cell(2).Value.ToString());
                }
            }

            return Guid.Empty;
        }
        /// <summary>
        /// Метод возвращает коллекцию guid = коллекция (категория/кухня/чек) заведения
        /// </summary>
        /// <param name="wb">Excel-книга</param>
        /// <param name="tableName">Названия рабочего листа</param>
        /// <param name="str">Строка (категория/кухня/чек) с разделителем (;)</param>
        /// <returns></returns>
        private static List<Guid> GetSmthFromTable(IXLWorkbook wb, string tableName, string str)
        {
            var ret = new List<Guid>();
            var dict = FillDict(wb, tableName);
            if (tableName != "Средний чек")
            {
                var spl = str.Split(';');
                foreach (string smth in spl)
                {
                    if (dict.TryGetValue(smth, out Guid g))
                    {
                        ret.Add(g);
                    }
                }
            }
            else
            {
                var check = decimal.TryParse(str, out decimal ch)? ch : 0m;
                try
                {
                    if (check > 0)
                    {
                        if (check <= 1000)
                        {
                            ret.Add(dict["до 1000 рублей"]);
                        }
                        else if (1000 < check && check <= 3000)
                        {
                            ret.Add(dict["от 1000 до 3000 рублей"]);
                        }
                        else
                        {
                            ret.Add(dict["от 3000 рублей"]);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Информация о чеке утеряна: {str}", 
                            "Информация утеряна", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ret;
        }
        /// <summary>
        /// Метод возвращает словарь со названиями (категория/кухня/чек) и их guid
        /// </summary>
        /// <param name="wb">Excel-книга</param>
        /// <param name="tableName">Названия рабочего листа</param>
        /// <returns></returns>
        private static Dictionary<string, Guid> FillDict(IXLWorkbook wb, string tableName)
        {
            var guids = new Dictionary<string, Guid>();
            foreach (var row in wb.Worksheet(tableName).RowsUsed())
            {
                if (row.RowNumber() == 1)
                {
                    continue;
                }
                guids[row.Cell(1).Value.ToString()] = GetGuidFromString(row.Cell(2).Value.ToString());                    
            }

            return guids;
        }
        /// <summary>
        /// Метод переводит string в Guid 
        /// </summary>
        private static Guid GetGuidFromString(string strGuid)
        {
            if (Guid.TryParse(strGuid, out Guid guid))
            {
                return guid;
            }
            return Guid.Empty;
            
        }
    }
}
