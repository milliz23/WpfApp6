using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            CbGenderReg.ItemsSource = BaseClass.Base.Gender.ToList();
            CbGenderReg.SelectedValuePath = "idGender";
            CbGenderReg.DisplayMemberPath = "Gender1";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int c = 0;
            Regex r = new Regex("^.*(?=.*[0-9]{2}).*$");
            if (r.IsMatch(TbPasReg.Password.ToString()) == false)
            {
                MessageBox.Show("Слабый пароль! Менее 2-ух чисел.", "Регистрация");
            }
            else { c += 1; }
            r = new Regex("^.*(?=.*[A-Z]).*$");
            if (r.IsMatch(TbPasReg.Password.ToString()) == false)
            {
                MessageBox.Show("Слабый пароль! Менее 1-го заглавного символа латинского алфавита.", "Регистрация");
            }
            else { c += 1; }
            r = new Regex("^.*(?=.*[a-z]{3}).*$");
            if (r.IsMatch(TbPasReg.Password.ToString()) == false)
            {
                MessageBox.Show("Слабый пароль! Менее 3-ёх символов латинского алфавита", "Регистрация");
            }
            else { c += 1; }
            r = new Regex("^.*(?=.*[!@#$%^&*()?+=]).*$");
            if (r.IsMatch(TbPasReg.Password.ToString()) == false)
            {
                MessageBox.Show("Слабый пароль! Менее 1-го специального символа.", "Регистрация");
            }
            else { c += 1; }
            r = new Regex("^.*(?=.{8,}).*$");
            if (r.IsMatch(TbPasReg.Password.ToString()) == false)
            {
                MessageBox.Show("Слабый пароль! Менее 8-ми символов.", "Регистрация");
            }
            else { c += 1; }
            if (c == 5)
            {
        int pasGegCode = TbPasReg.Password.GetHashCode();
            User UserRez = new User() { Name = TbNameReg.Text, Lastname = TbSurnameReg.Text, Login = TbLoginReg.Text, Password = pasGegCode, idGender = CbGenderReg.SelectedIndex +1, idRole = 2 };
            BaseClass.Base.User.Add(UserRez);
            BaseClass.Base.SaveChanges();
            MessageBox.Show("Вы зарегистрированы");
            }
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new MainWindow());
        }
    }
}
