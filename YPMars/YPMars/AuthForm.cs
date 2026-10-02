using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YPMarsLib;

namespace YPMars
{
    public partial class AuthForm: Form
    {
        private UserPgRepository loader_;
        private User currentUser_;
        public AuthForm()
        {
            InitializeComponent();
            loader_ = new UserPgRepository();
        }

        private void Imput_Click(object sender, EventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Text.Trim();

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Предупреждение",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Вызываем метод проверки логина и пароля из репозитория
            bool isAuthSuccess = loader_.AuthenticateUser(login, password);

            if (!isAuthSuccess)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbPassword.Clear();
                tbPassword.Focus();
                return;
            }

            // 3. Если авторизация успешна, получаем данные пользователя
            currentUser_ = loader_.GetUserByLogin(login);

            MessageBox.Show($"Добро пожаловать, {currentUser_.FullName ?? currentUser_.Login}!",
                            "Успешный вход", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 4. Открываем главную форму
            MainForm mainForm = new MainForm(loader_, currentUser_);
            mainForm.Show();

            this.Hide(); // Скрываем форму входа
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToggleButton_Click(object sender, EventArgs e)
        {
            // Если символы скрыты (true), то показываем их (false)
            if (tbPassword.UseSystemPasswordChar)
            {
                tbPassword.UseSystemPasswordChar = false;                              
            }
            // Иначе скрываем обратно
            else
            {
                tbPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
