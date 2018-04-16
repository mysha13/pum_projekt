using System;
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

namespace boxitem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            //var bb = new BoxesEntities();
            InitializeComponent();
            //Register r = new Register();
            //r.Show();
           //View. Boxes b = new View.Boxes();
            //b.Show();
            //Items i = new Items();
            //i.Show();
            //RemindPassword rp = new RemindPassword();
            //rp.Show();
            //FindItem fi = new FindItem();
            //fi.Show();
            //BoxesList bl = new BoxesList();
            //bl.Show();
            //AddPhoto ap = new AddPhoto();
            //ap.Show();
            //AddItem ai = new AddItem();
            //ai.Show();
            //AddBox ab = new AddBox();
            //ab.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void checkPreviewPasswordLogin_Checked(object sender, RoutedEventArgs e)
        {
            pbPasswordLogin.Visibility = System.Windows.Visibility.Collapsed;
            tbPasswordLogin.Visibility = System.Windows.Visibility.Visible;

            tbPasswordLogin.Focus();
        }

        private void checkPreviewPasswordLogin_Unchecked(object sender, RoutedEventArgs e)
        {
            pbPasswordLogin.Visibility = System.Windows.Visibility.Visible;
            tbPasswordLogin.Visibility = System.Windows.Visibility.Collapsed;

            pbPasswordLogin.Focus();
        }

        private void btnLoginLogin_Click(object sender, RoutedEventArgs e)
        {
            
            CurrentInfo currentuser = new CurrentInfo();


            using (var bb = new BoxesEntities())
            {
                //var users = bb.Users
                //    .ToList()
                //    .Select(x => x.Login.ToString() && x.Password.ToString())
                //    .ToList();

                try
                {

                    //var users = bb.Users
                    //        .ToList()
                    //        .Select(x => x.UserId)
                    //        .Select(x => ViewModel.UserViewModel.Create(x.Login, x.Password, x.UserId))
                    //        .Where(x => x.Login == tbLoginLogin.Text && x.Password == pbPasswordLogin.Text)
                    //        .ToList();

                    //rekord z tabeli users 
                    IQueryable<Users> us =
                        from u in bb.Users
                        where u.Login == tbLoginLogin.Text
                        select u;

                    int zmienna = 0;
                    foreach (var i in us)
                    {
                        //string haslo = i.Password.Trim();
                        //string haslo1 = tbPasswordLogin.Text;//pbPasswordLogin.SecurePassword.ToString();
                        //MessageBox.Show(haslo);
                        //MessageBox.Show(haslo1);
                        if (tbPasswordLogin.Text == i.Password.Trim() )
                        {
                            zmienna = i.UserId;
                        }

                    }
                    if (zmienna==0)
                    {
                        MessageBox.Show("Błędne dane logowania \n Użytkownik nie istnieje");
                    }
                    else
                    {
                        currentuser.UserId = zmienna;//int.Parse(uid.ToString())
                        MessageBox.Show(currentuser.UserId.ToString());
                        this.Hide();
                        View.Boxes boxes = new View.Boxes(currentuser.UserId);
                        boxes.ShowDialog();
                        this.Close();
                    }

                    //var zm = (from u in us
                    //          where u.Password == pbPasswordLogin.ToString()
                    //          select u.UserId);     

                    //var uid = (from u in bb.Users
                    //           where u.Login == tbLoginLogin.Text 
                    //           select u.UserId).First();

                    //var uid = (from u in bb.Users
                    //           where u.Login == tbLoginLogin.Text && u.Password == pbPasswordLogin.ToString()
                    //           select u.UserId).First();
                    //var uid = (from u in bb.Users
                    //           where u.Login == tbLoginLogin.Text && u.Password == tbPasswordLogin.Text
                    //           select u.UserId).First();

                    //if (int.Parse(zm.ToString()) != 0)
                    //{                        
                    //    currentuser.UserId = int.Parse(zm.ToString());//int.Parse(uid.ToString())

                    //    this.Hide();
                    //    View.Boxes boxes = new View.Boxes();
                    //    boxes.ShowDialog();
                    //    this.Close();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Błędne dane logowania \n Użytkownik nie istnieje");
                    //    tbLoginLogin.Clear();
                    //    tbPasswordLogin.Clear();
                    //}
                }
                catch
                {
                    MessageBox.Show("Błędne dane logowania \n Użytkownik nie istnieje");
                }
                //currentuser.UserId = zmienna;


                //var users = bb.Users
                //    .ToList()
                //    .Select(x => x.UserId == Id)
                //    .Where(x => tbLoginLogin.Text==ViewModel.UserViewModel.Check(x.login,x.password))
                //    .ToList();
            }

           

        }

        private void btnRemindPasswordLogin_Click(object sender, RoutedEventArgs e)
        {
            RemindPassword remindpassword = new RemindPassword();
            remindpassword.Show(); 
        }

        private void btnRegisterLogin_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
        }
    }
}
