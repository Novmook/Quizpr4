using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Quizpr4
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Desktop\КНИТУ\4 курс\Моделирование систем\Quizpr4\BD\QuizDB.mdf;Integrated Security=True;Connect Timeout=30");

        public Login()
        {
            InitializeComponent();
        }

        public Boolean isUserExists()
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM LoginUser WHERE Username='" + txtUsername.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    System.Windows.MessageBox.Show("Такой логин уже существует", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }

                else
                    return false;
            }
        }

            private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            
                //SqlConnection conn = new SqlConnection(connectionString);
                //conn.Open();
                //

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    string query = "SELECT * FROM LoginUser WHERE Username='" + txtUsername.Text.Trim() + "'AND Password = '" + txtPassword.Password.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    if (dtbl.Rows.Count == 1)
                    {
                        MainWindow fmMain = new MainWindow();
                        sqlCon.Close();
                        this.Hide();
                        fmMain.Show();
                    }
                else
                {
                    System.Windows.MessageBox.Show("Неверный логин или пароль", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
            }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Password == "")
                System.Windows.MessageBox.Show("Пожалуйста, заполните поля", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            //
            //
            else
            {
                if (isUserExists())
                    return;

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("AddUser", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password.Trim());

                    if (sqlCmd.ExecuteNonQuery() == 1)
                        System.Windows.MessageBox.Show("Аккаунт был создан", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        System.Windows.MessageBox.Show("Аккаунт не был создан", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                Clear();
                void Clear()
                {
                    txtUsername.Text = txtPassword.Password = "";

                }
            }
        }
    }
}
