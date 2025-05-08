using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace RecsApp
{
    public static class AddFromExcel
    {
        /// <summary>
        /// Метод загружает типы заведений из Excel файла
        /// </summary>
        public static void AddTypesToDB()
        {
            string path = $"{Directory.GetCurrentDirectory()}..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору");
                return;
            }

            var wb = new XLWorkbook(path);
            var ws = wb.Worksheet("Типы").RowsUsed();

            using (var db = new AppDbContext())
            {
                foreach (var row in ws)
                {
                    if (row.RowNumber() == 1)
                    {
                        continue;
                    }
                    if (Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidType) && db.Types.Find(guidType) == null)
                    {
                        db.Types.Add(new EstType() { Id = guidType, Title = row.Cell(1).Value.ToString() });
                    }
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод загружает категории заведений из Excel файла
        /// </summary>
        public static void AddCategoryesToDB()
        {
            string path = $"{Directory.GetCurrentDirectory()}..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору");
                return;
            }

            var wb = new XLWorkbook(path);
            var ws = wb.Worksheet("Категории").RowsUsed();

            using (var db = new AppDbContext())
            {
                foreach (var row in ws)
                {
                    if (Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidCat) && db.Categories.Find(guidCat) == null)
                    {
                        db.Categories.Add(new EstCategory() { Id = guidCat, Title = row.Cell(1).Value.ToString() });
                    }

                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод загружает кухни заведений из Excel файла
        /// </summary>
        public static void AddFoodToDB()
        {
            string path = $"{Directory.GetCurrentDirectory()}..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору");
                return;
            }

            var wb = new XLWorkbook(path);
            var ws = wb.Worksheet("Кухня").RowsUsed();

            using (var db = new AppDbContext())
            {
                foreach (var row in ws)
                {
                    if (Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidFood) && db.Foods.Find(guidFood) == null)
                    {
                        db.Foods.Add(new EstFood() { Id = guidFood, Title = row.Cell(1).Value.ToString() });
                    }
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод загружает средние чеки заведений из Excel файла
        /// </summary>
        public static void AddAveragesToDB()
        {
            string path = $"{Directory.GetCurrentDirectory()}..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору");
                return;
            }

            var wb = new XLWorkbook(path);
            var ws = wb.Worksheet("Средний чек").RowsUsed();

            using (var db = new AppDbContext())
            {
                foreach (var row in ws)
                {
                    if (Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidAv) && db.AverageChecks.Find(guidAv) == null)
                    {
                        db.AverageChecks.Add(new EstAverageCheck() { Id = guidAv, Title = row.Cell(1).Value.ToString() });
                    }
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод загружает заведения из Excel файла
        /// </summary>
        public static void AddEstablishmentsToDB()
        {
            string path = $"{Directory.GetCurrentDirectory()}..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору");
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
                bool IsEmpty = false;
                foreach (var row in ws)
                {
                    if (row.RowNumber() == 1)
                    {
                        continue;
                    }
                    string name = row.Cell(1).Value.ToString();
                    string description = row.Cell(2).Value.ToString();
                    Guid type = GetTypeFromTable(wb, row.Cell(3).Value.ToString());
                    List<Guid> Categories = GetSmthFromTable(wb, "Категории", row.Cell(4).Value.ToString());
                    string address = row.Cell(5).Value.ToString();
                    double rating = double.TryParse(row.Cell(6).Value.ToString().Replace('.', ','), out double rat) ? rat : 0;
                    if (rating > 5)
                    {
                        rating = 5;
                    }
                    else if (rating < 0)
                    {
                        rating = 0;
                    }
                    string link = row.Cell(7).Value.ToString();
                    string pathsToPhoto = row.Cell(8).Value.ToString();
                    List<Guid> Food = GetSmthFromTable(wb, "Кухня", row.Cell(9).Value.ToString());
                    List<Guid> Averages = GetSmthFromTable(wb, "Средний чек", row.Cell(10).Value.ToString());
                    string stringSimilar = row.Cell(11).Value.ToString();                   


                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(description) ||
                        type == Guid.Empty || Categories.Count == 0 || Categories.Any(x => x == Guid.Empty) || string.IsNullOrEmpty(address))
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

                    var e = new Establishment()
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

                    foreach (var c in Categories)
                    {
                        e.Categories.Add(db.Categories.Find(c));
                    }
                    foreach (var f in Food)
                    {
                        e.Foods.Add(db.Foods.Find(f));
                    }
                    foreach (var a in Averages)
                    {
                        e.Averages.Add(db.AverageChecks.Find(a));
                    }
                    db.Establishments.Add(e);

                }
                if (IsEmpty)
                {
                    MessageBox.Show("Часть данных утеряна, обратитесь к администратору");
                }
                db.SaveChanges();
            }
        }
        private static Guid GetTypeFromTable(IXLWorkbook wb, string type)
        {
            foreach (var row in wb.Worksheet("Типы").RowsUsed())
            {
                if (row.RowNumber() == 1)
                {
                    continue;
                }
                if (row.Cell(1).Value.ToString() == type && new AppDbContext().Types.Find(GetGuidFromString(row.Cell(2).Value.ToString())) != null)
                {
                    return GetGuidFromString(row.Cell(2).Value.ToString());
                }
            }

            return Guid.Empty;
        }
        private static List<Guid> GetSmthFromTable(IXLWorkbook wb, string tableName, string str)
        {
            List<Guid> ret = new List<Guid>();

            string[] spl = str.Split(';');
            var dict = FillDict(wb, tableName);
            foreach (string smth in spl)
            {
                if (dict.TryGetValue(smth, out Guid g))
                {
                    ret.Add(g);
                }
            }

            return ret;
        }
        private static Dictionary<string, Guid> FillDict(IXLWorkbook wb, string tableName)
        {
            Dictionary<string, Guid> guids = new Dictionary<string, Guid>();
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
        public static Guid GetGuidFromString(string strGuid)
        {
            if (Guid.TryParse(strGuid, out Guid guid))
            {
                return guid;
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}
