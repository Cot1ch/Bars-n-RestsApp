﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using System.Resources;
using NLog;

namespace RecsApp
{
    /// <summary>
    /// Форма с отображением информации о заведении
    /// </summary>
    public partial class InfoForm : Form
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Заведение, информацию о котором отображает форма
        /// </summary>
        private Establishment establishment;
        /// <summary>
        /// Идентификатор отображаемого заведения
        /// </summary>
        private Guid estId;
        /// <summary>
        /// Счетчик индекса отображаемого изображения
        /// </summary>
        private int imageInd = 0;
        /// <summary>
        /// Коллекция путей к изображениям заведения
        /// </summary>
        private List<string> paths;
        /// <summary>
        /// Идентификатор аккаунта пользователя
        /// </summary>
        private Guid userId;
        /// <summary>
        /// Ссылка на главную форму
        /// </summary>
        private MainForm mainForm;
        /// <summary>
        /// Конструктор InfoForm
        /// </summary>
        /// <param name="EstId">Идентификатор заведения</param>
        /// <param name="UserId">Идентификатор пользователя</param>
        /// <param name="main">Главная форма</param>
        public InfoForm(Guid EstId, Guid UserId, MainForm main)
        {
            InitializeComponent();
            this.userId = UserId;
            mainForm = main;
            using (var db = new AppDbContext())
            {
                establishment = (
                    from establishment in db.Establishments
                    .Include(establishment => establishment.Type)
                    .Include(establishment => establishment.Categories)
                    .Include(establishment => establishment.Foods)
                    .Include(establishment => establishment.Average)
                    where establishment.Id == EstId
                    select establishment).First();
                logger.Trace($"Заведение {establishment.Name} получено из базы данных");
                estId = EstId;
                Visits();
            }
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            LoadInfoForm();
            logger.Trace("Форма загружена");
            ShowImage();
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
            {
                this.Text = res.GetString("InfoFormText");
                this.checkBoxStarred.Text = res.GetString("checkBoxStarredText");
                this.labelAddress.Text = res.GetString("labelAddressText");
                this.labelRating.Text = res.GetString("labelRatingText");
                this.labelType.Text = res.GetString("labelTypeText");
                this.labelName.Text = res.GetString("labelNameText");
                this.labelFood.Text = res.GetString("labelFoodText");
                this.labelLink.Text = res.GetString("labelLinkText");
                this.labelAverageCheck.Text = res.GetString("labelAverageCheckText");
                this.labelDescription.Text = res.GetString("labelDescriptionText");
                this.btnHide.Text = res.GetString("btnHideText");

                logger.Info("Локализация выполнена");
            }
        }
        /// <summary>
        /// Метод заполняет текстовые поля, поля ссылки и изображений заведения 
        /// для отображения информации о нём
        /// </summary>
        public void LoadInfoForm()
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
            using (var db = new AppDbContext())
            {
                this.textBoxEstName.Text = establishment.Name;
                this.textBoxEstDescription.Text = establishment.Description;
                this.textBoxFood.Text = string.Join("; ", establishment.Foods.Select(f => f.Title)
                    .ToList());
                this.textBoxEstType.Text = establishment.Type.Title;
                this.textBoxAverageCheck.Text = $"{establishment.Check:F0} " +
                    $"{res.GetString("Currency")}";
                this.textBoxEstRating.Text = $"{establishment.Rating:F1}";
                this.textBoxEstAddress.Text = establishment.Address.ToString();
                this.linkLabelToWebSite.Text = 
                    (establishment.Link != res.GetString("linkLabelToWebSiteText")) 
                    ? establishment.Link 
                    : res.GetString("linkLabelToWebSiteText");
                this.checkBoxStarred.Checked = db.Users.Include(user => user.Favourite)
                    .First(user => user.user_Id == userId).Favourite.Contains(this.establishment);

                paths = establishment.PathsToPhoto == string.Empty 
                    ? new List<string>() 
                    { 
                        "notfound.png" 
                    } 
                    : establishment.PathsToPhoto.Split(';').ToList();
                
                logger.Info("Все тексовые поля заполнены");
            }
        }
        private void linkLabelToWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(this.linkLabelToWebSite.Text);
                logger.Info($"запущен процесс по ссылке {this.linkLabelToWebSite.Text}");
            }
            catch
            {
                using (var res = new ResXResourceSet(
                    $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
                {
                    MessageBox.Show(res.GetString("WebSiteDoesntExists"),
                        res.GetString("linkLabelToWebSiteText"), 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Warn($"запущен процесс по ссылке {this.linkLabelToWebSite.Text}");
                }
            }
        }
        /// <summary>
        /// Метод передает в picturebox путь к изображению
        /// </summary>
        public void ShowImage()
        {
            if (paths != null)
            {
                if (File.Exists(
                    $"{Directory.GetCurrentDirectory()}" +
                    $"\\..\\..\\Resources\\Изображения заведений\\{paths[imageInd]}"))
                {
                    pictureBoxEstImage.ImageLocation = 
                        $"{Directory.GetCurrentDirectory()}" +
                        $"\\..\\..\\Resources\\Изображения заведений\\{paths[imageInd]}";
                }
                else
                {
                    pictureBoxEstImage.ImageLocation = 
                        $"{Directory.GetCurrentDirectory()}\\..\\..\\images\\notfound.png";
                }
                logger.Trace("Изображение загружено");
            }
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            PrevImage();
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            NextImage();
        }
        /// <summary>
        /// Метод для отображения следующего изображения
        /// </summary>
        private void NextImage()
        {
            imageInd = (imageInd + 1) % paths.Count;
            logger.Trace("следующее изображение");
            ShowImage();
        }
        /// <summary>
        /// Метод для отображения предыдущего изображения
        /// </summary>
        private void PrevImage()
        {
            imageInd = (imageInd - 1 + paths.Count) % paths.Count;
            logger.Trace("предыдущее изображение");
            ShowImage();
        }

        private void InfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                PrevImage();
            }
            if (e.KeyCode == Keys.Right)
            {
                NextImage();
            }
        }
        private void checkBoxStarred_CheckedChanged(object sender, EventArgs e)
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
            using (var db = new AppDbContext())
            {
                var user = (from us in db.Users
                            .Include(us => us.Favourite)
                            where us.user_Id == this.userId
                            select us).First();
                logger.Trace($"Пользователь {user.username} получен из базы данных");

                var establishment = (
                    from est in db.Establishments
                    .Include(est => est.Type).Include(est => est.Categories)
                    .Include(est => est.Foods).Include(est => est.Average)
                    where est.Id == this.estId
                    select est).ToList().First();
                logger.Trace($"Заведение {establishment.Name} получено из базы данных");

                if (this.checkBoxStarred.Checked)
                {
                    if (user != null)
                    {
                        if (!user.Favourite.Contains(establishment))
                        {
                            user.Favourite.Add(establishment);
                            MessageBox.Show(res.GetString("EstablishmentAdded"), 
                                res.GetString("Succsess"),
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            logger.Trace($"Заведение {establishment.Name} добавлено в избранное " +
                                $"пользователем {user.username}");
                        }
                        else
                        {
                            MessageBox.Show(res.GetString("EstablishmentAlreadyInFavorite"),
                                res.GetString("AlreadyAdd"), 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            logger.Warn($"Заведение {establishment.Name} уже в избранном " +
                                $"пользователя {user.username}, добавление невозможно");
                        }
                    }
                    else
                    {
                        MessageBox.Show(res.GetString("AccessDenied"), res.GetString("Error"), 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error("Доступ к аккаунту потерян");
                    }
                }
                else
                {
                    if (user != null)
                    {
                        if (user.Favourite.Contains(establishment))
                        {
                            user.Favourite.Remove(establishment);
                            MessageBox.Show(res.GetString("EstablishmentDeleted"),
                                res.GetString("Succsess"),
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            logger.Trace($"Заведение {establishment.Name} удалено из избранного " +
                                $"пользователем {user.username}");
                        }
                        else
                        {
                            MessageBox.Show(res.GetString("EstablishmentNotInFavourite"),
                                res.GetString("NotFound"), 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            logger.Warn($"Заведение {establishment.Name} не в избранном " +
                                $"пользователя {user.username}, удаление невозможно");
                        }
                    }
                    else
                    {
                        MessageBox.Show(res.GetString("AccessDenied"), res.GetString("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error("Доступ к аккаунту потерян");
                    }
                }
                db.Entry(user).State = EntityState.Modified;
                this.mainForm.LoadForm();
                db.SaveChanges();
            }
        }
        private void btnHide_Click(object sender, EventArgs e)
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
            {
                logger.Trace("Пользователь нажал на кнопку 'скрыть'");
                var result = MessageBox.Show(res.GetString("HideEstablishment"),
                    res.GetString("AreUSure"), 
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                logger.Trace("Пользователь нажал на кнопку 'ок'");

                if (result == DialogResult.OK)
                {
                    using (var db = new AppDbContext())
                    {
                        var establishment = (
                            from est in db.Establishments
                            .Include(est => est.Type).Include(est => est.Categories)
                            .Include(est => est.Foods).Include(est => est.Average)
                            where est.Id == this.estId
                            select est).ToList().First();
                        logger.Info("Заведение получено из базы данных");
                        var user = (from u in db.Users
                                    .Include(u => u.Hidden)
                                    .Include(u => u.Favourite)
                                    where u.user_Id == this.userId
                                    select u).First();
                        logger.Info("Пользователь получен из базы данных");
                        user.Hidden.Add(establishment);
                        db.Entry(user).State = EntityState.Modified;
                        logger.Info($"Заведение ({establishment.Name}) " +
                            $"помещено в скрытые пользователя ({user.username})");
                        db.SaveChanges();
                    }
                    mainForm.LoadForm();
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Метод избегает переполнения счетчика посещений
        /// </summary>
        private void Visits()
        {
            using (var db = new AppDbContext())
            {
                logger.Trace("Выполнена связь с контекстом");
                db.Establishments.Attach(this.establishment);
                if (this.establishment.CountVisits > long.MaxValue / 2)
                {

                    foreach (var e in db.Establishments)
                    {
                        e.CountVisits /= 10;
                    }
                    logger.Trace("Счетчики сброшены");
                    db.SaveChanges();
                }
                else
                {
                    establishment.CountVisits++;
                    logger.Trace("Счетчик обновлен");
                }
                db.SaveChanges();
            }
            this.mainForm.LoadForm();
        }
    }
}
