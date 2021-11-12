﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int paswordCode = TbPasAvto.Password.GetHashCode();
            User User = BaseClass.Base.User.FirstOrDefault(z => z.Login == TbLoginAvto.Text && z.Password == paswordCode);
            if (User == null)
            {
                MessageBox.Show("Вы не зарегистрированы");
            }
            else
            {
                switch (User.idRole)
                {
                    case 1:
                        MessageBox.Show("Здравствуйте, администратор " + User.Name);
                        FrameClass.FrameMain.Navigate(new MenuAdminPage());
                        break;
                    case 2:
                        MessageBox.Show("Здравствуйте, пользователь " + User.Name);
                        break;
                }
            }
        }
    }
}
