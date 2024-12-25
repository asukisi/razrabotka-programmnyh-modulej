using Npgsql; // Подключите библиотеку Npgsql через NuGet   

namespace Repair
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            MinimumSize = new Size(900, 460);
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            // Получение данных из формы
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Хеширование пароля (опционально)
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // SQL-запрос для вставки данных
            string query = "INSERT INTO role (username, password, role_type) VALUES (@username, @password, @role_type)";

            try
            {
                using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;"))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", hashedPassword);
                        command.Parameters.AddWithValue("@role_type", role);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Пользователь успешно создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Очистка полей
                        txtUsername.Clear();
                        txtPassword.Clear();
                        cmbRole.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Получение данных из формы
            string username = txtLoginUsername.Text.Trim();
            string password = txtLoginPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите имя пользователя и пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL-запрос для проверки пользователя
            string query = "SELECT password, role_type FROM role WHERE username = @username";

            try
            {
                using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;"))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Получаем хешированный пароль и роль из БД
                                string storedPassword = reader.GetString(0);
                                string role = reader.GetString(1);

                                // Проверяем пароль
                                if (BCrypt.Net.BCrypt.Verify(password, storedPassword))
                                {
                                    // Переход на Form1 с передачей роли
                                    Form1 form1 = new Form1(role);
                                    form1.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пользователь не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при входе: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
