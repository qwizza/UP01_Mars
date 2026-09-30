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
    public partial class RegistrForm : Form
    {
        private UserPgRepository loader_;
        private User currentUser_;
        public RegistrForm(UserPgRepository loader, User currentUser)
        {
            InitializeComponent();
            loader_ = loader;
            currentUser_ = currentUser;

           
            RegPasswordTb.UseSystemPasswordChar = true;
            RegConfirmPasswordTb.UseSystemPasswordChar = true;

            // Заполняем выпадающий список ролями
            RegRoleCb.Items.Clear();
            foreach (User.UserRole role in Enum.GetValues(typeof(User.UserRole)))
            {
                RegRoleCb.Items.Add(role.ToString());
            }
        }

        private void RegImputButten_Click(object sender, EventArgs e)
        {
            // Считываем значения из текстовых полей, удаляя лишние пробелы по краям
            string login = RegLoginTb.Text.Trim();
            string password = RegPasswordTb.Text.Trim();
            string confirmPassword = RegConfirmPasswordTb.Text.Trim();
            string fullName = RegFullNameTb.Text.Trim();
            string department = RegDepartmentTb.Text.Trim();

            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) ||
                string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RegPasswordTb.Clear();
                RegConfirmPasswordTb.Clear();
                RegPasswordTb.Focus(); // Возвращаем курсор в поле ввода пароля
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Пароль должен содержать не менее 8 символов", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (RegRoleCb.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите роль пользователя", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем выбранный индекс ComboBox в элемент enum UserRole
            User.UserRole role = (User.UserRole)RegRoleCb.SelectedIndex;

            var existingUser = loader_.GetUserByLogin(login);
            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                RegLoginTb.Clear();
                RegLoginTb.Focus(); 
                return;
            }

            // Хешируем пароль алгоритмом SHA256 перед сохранением
            string hashedPassword = UserPgRepository.HashPassword(password);

            // Создаем новый объект пользователя
            User newUser = new User(login, hashedPassword, role, fullName, department);

            // Сохраняем нового пользователя в базу
            bool success = loader_.AddUser(newUser);

            if (success)
            {
                MessageBox.Show($"Пользователь '{login}' успешно зарегистрирован", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Ошибка при регистрации пользователя", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик клика по кнопке видимости пароля 
        private void ToggleButton_Click(object sender, EventArgs e)
        {
            bool showPassword = !RegPasswordTb.UseSystemPasswordChar;
            RegPasswordTb.UseSystemPasswordChar = showPassword;
            RegConfirmPasswordTb.UseSystemPasswordChar = showPassword;
            ToggleButton.Text = showPassword ? "Скрыть пароль" : "Показать пароль";
            if (showPassword)
                RegConfirmPasswordTb.Focus();
            else
                RegPasswordTb.Focus();
        }

        private void RegCancelButten_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
