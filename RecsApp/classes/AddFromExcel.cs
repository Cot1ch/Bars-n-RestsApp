using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using ClosedXML.Excel;
using NLog;

namespace RecsApp
{
    /// <summary>
    /// Класс, записывающий данные о заведениях с Excel в базу данных
    /// </summary>
    public static class AddFromExcel
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Путь к загружаемому файлу
        /// </summary>
        public static string fileName { get; set; }
        /// <summary>
        /// Метод загружает типы, категории, кухни и чеки заведений из Excel файла в базу данных
        /// </summary>
        public static void AddTypesCatsFoodsChecksToDB()
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resource1.resx"))
            {
                var path = fileName;
;               logger.Info($"Имя файла с заведениями: {path}");
                if (!File.Exists(path))
                {
                    MessageBox.Show(res.GetString("ContactAdmin"),
                        res.GetString("FileDoesntExist"), 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(res.GetString("FileDoesntExist") + $"| path={path}");
                    
                    return;
                }

                var wb = new XLWorkbook(path);
                List<string> sheets = new List<string>() 
                {
                    "Типы",
                    "Категории",
                    "Кухня",
                    "Средний чек"
                };

                using (var db = new AppDbContext())
                {
                    foreach (var sheet in sheets)
                    {
                        if (!wb.TryGetWorksheet(sheet, out IXLWorksheet worksheet))
                        {
                            MessageBox.Show(res.GetString("UseDefFile"), 
                                res.GetString("FileDoesntExist"),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            fileName = $"{Directory.GetCurrentDirectory()}" +
                                $"..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
                            AddTypesCatsFoodsChecksToDB();
                            return;
                        }

                        var ws = worksheet.RowsUsed();

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
                                logger.Info($"Добавлен тип '{row.Cell(1).Value}'");
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
                                logger.Info($"Добавлена категория '{row.Cell(1).Value}'");
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
                                logger.Info($"Добавлена кухня '{row.Cell(1).Value}'");
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
                                logger.Info($"Добавлен средний чек '{row.Cell(1).Value}'");
                            }
                        }
                    }
                    db.SaveChanges();
                    logger.Info("Изменения сохранены");
                }
            }
        }
        /// <summary>
        /// Метод загружает информацию о заведениях из Excel файла
        /// </summary>
        public static void AddEstablishmentsToDB()
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resource1.resx"))
            {
                var path = fileName;
                logger.Info($"Имя файла с заведениями: {path}");

                if (!File.Exists(path))
                {
                    MessageBox.Show(res.GetString("ContactAdmin"),
                        res.GetString("FileDoesntExist"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(res.GetString("FileDoesntExist") + $"| path={path}");
                    return;
                }

                var wb = new XLWorkbook(path);

                if (!wb.TryGetWorksheet("Заведения", out IXLWorksheet works))
                {
                    MessageBox.Show(res.GetString("ContactAdmin"),
                        res.GetString("SheetDoesntFound") + "| name='Заведения'",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(res.GetString("SheetDoesntFound") + "| name='Заведения'");

                    fileName = $"{Directory.GetCurrentDirectory()}" +
                        $"..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
                    AddEstablishmentsToDB();
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
                        logger.Trace($" Поля заведения заполнены");
                        db.Establishments.Add(establishment);
                        logger.Info($"Добавлено заведение '{establishment.Name}'");
                    }
                    if (IsEmpty)
                    {
                        MessageBox.Show(res.GetString("DataDoesntFull") + "\n" +
                            res.GetString("ContactAdmin"), res.GetString("DataLost"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        logger.Warn(res.GetString("DataDoesntFull") + "\n" +
                            res.GetString("ContactAdmin"));
                    }
                    db.SaveChanges();
                }
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
                    logger.Info($"Получен тип '{row.Cell(1).Value}' = " +
                        $"{GetGuidFromString(row.Cell(2).Value.ToString())}");
                    return GetGuidFromString(row.Cell(2).Value.ToString());
                }
            }
            logger.Warn($"Тип {type} не найден");
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
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resource1.resx"))
            {
                var ret = new List<Guid>();
                var dict = FillDict(wb, tableName);
                if (tableName != "Средний чек")
                {
                    logger.Info($"Открыт лист {tableName}");
                    var spl = str.Split(';');
                    foreach (string smth in spl)
                    {
                        if (dict.TryGetValue(smth, out Guid g))
                        {
                            ret.Add(g);
                        }
                    }
                    logger.Info("Обработка закончена");
                }
                else
                {
                    var check = decimal.TryParse(str, out decimal ch) ? ch : 0m;
                    try
                    {
                        logger.Info("Открыт лист 'Средний чек'");
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
                            MessageBox.Show(res.GetString("DataLost") + 
                                $":\n{check.GetType().Name} : {check}",
                                res.GetString("DataLost"), 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            logger.Warn($"Чек не может быть отрицательным числом = {check}");                                
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, res.GetString("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error($"Ошибка: {exception.Message}");
                    }
                }
                logger.Info($"Возвращены значения " +
                    $"{string.Join("|", ret.Select(guid => guid.ToString()))}");
                return ret;
            }
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
                logger.Info($"Возвращено значение {guid.ToString()}");
                return guid;
            }
            logger.Warn("Значение не найдено");
            return Guid.Empty;            
        }
    }
}
