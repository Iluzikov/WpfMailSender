﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfMailSenderViewModel model { get; set; } = new WpfMailSenderViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;
            dgEmails.ItemsSource = DataBaseClass.DBEmails;
            cbSmtp.ItemsSource = DataBaseClass.DBSmtp;
        }

        /// <summary>
        /// Кнопка меню "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    if (model.IsFillError())
        //    {
        //        sendEndWindow = new SendEndWindow(model.Status);
        //        sendEndWindow.Owner = this;
        //        sendEndWindow.ShowDialog();
        //    }
        //    else
        //    {
        //        authWindow = new AuthorizationWindow();
        //        authWindow.Owner = this;
        //        if (authWindow.ShowDialog() == true)
        //        {

        //            sendEndWindow = new SendEndWindow(model.SendMessage(authWindow.model.selectedSmtpServer, authWindow.model.authSettings));
        //            sendEndWindow.Owner = this;
        //            sendEndWindow.ShowDialog();
        //        }
        //    }
        //}

        /// <summary>
        /// Перейти в планировщик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tabCtrl.SelectedItem = tabItemPlanner;
        }

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {
            model.SendMessage((IQueryable<Emails>)dgEmails.ItemsSource, (Smtp)cbSmtp.SelectedItem);
        }

        private void btnSendLater_Click(object sender, RoutedEventArgs e)
        {
            var selectedDate = cldSchedulDate.SelectedDate ?? DateTime.Today;
            model.SendMessageLater((IQueryable<Emails>)dgEmails.ItemsSource, (Smtp)cbSmtp.SelectedItem, selectedDate, tPicker.Text);

        }

        private void MyTabSwitcher_btnNextClick(object sender, RoutedEventArgs e)
        {
            tabCtrl.SelectedIndex++;
        }

        private void MyTabSwitcher_btnPreviousClick(object sender, RoutedEventArgs e)
        {
            tabCtrl.SelectedIndex--;
        }
    }
}
