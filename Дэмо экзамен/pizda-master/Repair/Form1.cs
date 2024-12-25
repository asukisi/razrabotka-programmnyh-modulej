using Npgsql;
using System.Data;
using System;
using QRCoder;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Repair
{
    public partial class Form1 : Form
    {
        private string userRole;

        public Form1(string role)
        {
            InitializeComponent();
            MinimumSize = new Size(900, 460);
            userRole = role;

            // Убедимся, что роль передаётся корректно
            MessageBox.Show($"Роль пользователя: {userRole}", "Отладка", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Настройка элементов в зависимости от роли
            if (userRole == "User")
            {
                button2.Enabled = false;
            }
            LoadUserNamesIntoComboBox();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text = selectedRow.Cells["name"].Value.ToString();
                textBox2.Text = selectedRow.Cells["id"].Value.ToString();
                comboBox1.Text = selectedRow.Cells["status"].Value.ToString();
                textBox3.Text = selectedRow.Cells["description"].Value.ToString();
                comboBox2.Text = selectedRow.Cells["priority"].Value.ToString();
                comboBoxUsers.Text = selectedRow.Cells["owner"].Value.ToString();
            }
        }


        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            string query = "SELECT * FROM public.\"user\"";
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Используем DataAdapter для получения данных
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Загружаем данные в DataTable

                        // Привязываем DataTable к DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
            }
        }

        public void LoadUserNamesIntoComboBox()
        {
            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            string query = "SELECT username FROM public.\"role\""; // Предполагается, что у вас есть колонка name

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string userName = row["username"].ToString();
                            comboBoxUsers.Items.Add(userName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            string newName = textBox1.Text;
            string newStatus = comboBox1.SelectedItem?.ToString();
            string newOwner = comboBoxUsers.SelectedItem?.ToString();
            string newPriority = comboBox2.SelectedItem?.ToString();
            string newDescription = textBox3.Text;
            if (!int.TryParse(textBox2.Text, out int id))
            {
                MessageBox.Show("Пожалуйста, введите корректный ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Пожалуйста, введите новое имя.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newStatus))
            {
                MessageBox.Show("Пожалуйста, выберите новый статус.");
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            string query = "UPDATE public.\"user\" SET name = @name, status = @status, priority = @priority, owner = @owner, description = @description WHERE id = @id";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", newName);
                        command.Parameters.AddWithValue("@status", newStatus);
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@priority", newPriority);
                        command.Parameters.AddWithValue("@owner", newOwner);
                        command.Parameters.AddWithValue("@description", newDescription);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Пользователь с ID {id} успешно обновлен: Имя - {newName}, Статус - {newStatus}!");
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show($"Пользователь с ID {id} не найден.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            string query = "DELETE FROM public.\"user\"";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (!int.TryParse(textBox2.Text, out int id))
            {
                MessageBox.Show("Введите корректный ID.");
                return;
            }
            string description = textBox3.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя.");
                return;
            }

            string status = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Пожалуйста, выберите статус.");
                return;
            }

            string priority = comboBox2.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Пожалуйста, выберите статус.");
                return;
            }

            string owner = comboBoxUsers.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Пожалуйста, выберите статус.");
                return;
            }

            DateTime currentTime = DateTime.Now;
            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            string query = "INSERT INTO public.\"user\" (id, name, status, created_at, priority, owner, description) VALUES (@id, @name, @status, @created_at, @priority, @owner, @description)";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@created_at", currentTime);
                        command.Parameters.AddWithValue("@priority", priority);
                        command.Parameters.AddWithValue("@owner", owner);
                        command.Parameters.AddWithValue("@description", description);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Данные успешно добавлены! ID: {id}, Имя: {name}, Статус: {status}, Время: {currentTime}");
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить данные.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out int id))
            {
                MessageBox.Show("Введите корректный ID.");
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            string query = "SELECT * FROM public.\"user\" WHERE id = @id";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@id", id);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким ID не найден.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void SearchByComboBox_Click(object sender, EventArgs e)
        {
            string selectedStatus = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedStatus))
            {
                MessageBox.Show("Пожалуйста, выберите значение из ComboBox.");
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            string query = "SELECT * FROM public.\"user\" WHERE status = @status";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@status", selectedStatus);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show($"Пользователи со статусом \"{selectedStatus}\" не найдены.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void GetCompletedTasks_Click(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=Cookie_1o1;";
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            string query = @"SELECT COUNT(*) AS completed_tasks
                             FROM public.task
                             WHERE completion_time BETWEEN @start_date AND @end_date 
                             AND status = 'completed'";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@start_date", startDate);
                        command.Parameters.AddWithValue("@end_date", endDate);

                        int completedTasks = Convert.ToInt32(command.ExecuteScalar());
                        MessageBox.Show($"Количество выполненных задач за указанный период: {completedTasks}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void GetAverageCompletionTime_Click(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            string query = @"SELECT AVG(EXTRACT(EPOCH FROM (completion_time - start_time))) AS average_time_seconds
                             FROM public.task
                             WHERE completion_time BETWEEN @start_date AND @end_date
                             AND status = 'completed'";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@start_date", startDate);
                        command.Parameters.AddWithValue("@end_date", endDate);

                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            double avgTimeSeconds = Convert.ToDouble(result);
                            TimeSpan averageTime = TimeSpan.FromSeconds(avgTimeSeconds);
                            MessageBox.Show($"Среднее время выполнения задачи: {averageTime}");
                        }
                        else
                        {
                            MessageBox.Show("Нет данных для расчета среднего времени.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void button4fd_Click(object sender, EventArgs e)
        {
            string url = "https://t.me/asukisi";


            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);


                Bitmap qrCodeImage = qrCode.GetGraphic(20);


                Bitmap resizedImage = new Bitmap(qrCodeImage, new Size(200, 200));


                pictureBox1.Image = resizedImage;
            }
        }

        private void SaveDataTableToPdf(DataTable dataTable, string filePath)
        {
            // ������� �������� PDF
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                try
                {
                    pdfDoc.Add(new Paragraph("������ �������������", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
                    pdfDoc.Add(new Paragraph("\n"));

                    PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count);

                    // ��������� ��������� ��������
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            BackgroundColor = BaseColor.LIGHT_GRAY
                        };
                        pdfTable.AddCell(cell);
                    }

                    // ��������� ������
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (var cellData in row.ItemArray)
                        {
                            pdfTable.AddCell(new Phrase(cellData.ToString()));
                        }
                    }

                    // ��������� ������� � ��������
                    pdfDoc.Add(pdfTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� �������� PDF: {ex.Message}");
                }
                finally
                {
                    // ��������� ��������
                    pdfDoc.Close();
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            {
                // Получение начальной и конечной дат с обработкой времени
                DateTime startDate = dateTimePickerStart.Value.Date; // Начало диапазона (без времени)
                DateTime endDate = dateTimePickerEnd.Value.Date.AddDays(1).AddTicks(-1); // Конец диапазона (включительно)

                // Строка подключения к базе данных
                string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";

                // SQL-запрос для фильтрации записей по временным меткам
                string query = "SELECT * FROM public.\"user\" WHERE created_at BETWEEN @start_date AND @end_date";
                try
                {
                    // Установка соединения с базой данных
                    using (var connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();

                        // Используем NpgsqlDataAdapter для выполнения запроса
                        using (var adapter = new NpgsqlDataAdapter(query, connection))
                        {
                            // Добавляем параметры для предотвращения SQL-инъекций
                            adapter.SelectCommand.Parameters.AddWithValue("@start_date", startDate);
                            adapter.SelectCommand.Parameters.AddWithValue("@end_date", endDate);

                            // Заполняем DataTable результатами запроса
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Проверяем, есть ли данные
                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dataTable; // Привязываем данные к DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Нет записей в указанный промежуток времени.",
                                                "Результат поиска",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                dataGridView1.DataSource = null; // Очищаем DataGridView
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок подключения или выполнения запроса
                    MessageBox.Show($"Ошибка: {ex.Message}",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

        }

        private void GetCompletedTasks_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            string query = @"SELECT COUNT(*) AS completed_tasks
                             FROM public.task
                             WHERE completion_time BETWEEN @start_date AND @end_date 
                             AND status = 'completed'";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@start_date", startDate);
                        command.Parameters.AddWithValue("@end_date", endDate);

                        int completedTasks = Convert.ToInt32(command.ExecuteScalar());
                        MessageBox.Show($"Количество выполненных задач за указанный период: {completedTasks}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int userId = Convert.ToInt32(selectedRow.Cells["id"].Value); // Предполагаем, что у вас есть колонка id
                string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
                string deleteQuery = "DELETE FROM public.\"user\" WHERE id = @id";

                try
                {
                    using (var connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();

                        using (var command = new NpgsqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@id", userId);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Строка успешно удалена.");
                            }
                            else
                            {
                                MessageBox.Show("Ошибка: строка не найдена.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении строки: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }


        }

        public void DeleteSelectedRow()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            string query = "DELETE FROM public.\"user\" WHERE id = @id";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Пользователь с ID {id} успешно удален.");
                            dataGridView1.Rows.Remove(selectedRow);
                        }
                        else
                        {
                            MessageBox.Show($"Пользователь с ID {id} не найден.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        public void InsertUser()
        {
            string name = textBox1.Text;
            if (!int.TryParse(textBox2.Text, out int id))
            {
                MessageBox.Show("Введите корректный ID.");
                return;
            }
            string description = textBox3.Text;
            string status = comboBox1.SelectedItem?.ToString();
            string priority = comboBox2.SelectedItem?.ToString();
            string owner = comboBoxUsers.SelectedItem?.ToString();
            DateTime currentTime = DateTime.Now;

            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            string query = "INSERT INTO public.\"user\" (id, name, status, created_at, priority, owner, description) VALUES (@id, @name, @status, @created_at, @priority, @owner, @description)";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@created_at", currentTime);
                        command.Parameters.AddWithValue("@priority", priority);
                        command.Parameters.AddWithValue("@owner", owner);
                        command.Parameters.AddWithValue("@description", description);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Данные успешно добавлены! ID: {id}, Имя: {name}, Статус: {status}, Время: {currentTime}");
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить данные.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добавление задачи:\r\n\r\n    Введите номер, описание, приоритет, проект, исполнителя и статус задачи, затем сохраните.\r\n\r\nРедактирование задачи:\r\n\r\n    Найдите задачу, измените параметры (приоритет, исполнитель, статус), сохраните изменения.\r\n\r\nОтслеживание задач:\r\n\r\n    Фильтруйте задачи по статусу, исполнителю или приоритету. Используйте поиск по номеру или ключевым словам.\r\n\r\nСтатистика:\r\n\r\n    Просматривайте статистику по выполненным задачам, времени выполнения и по проектам.\r\n\r\nДоступ:\r\n\r\n    Уровни доступа: администратор, сотрудник.", "Справка");
        }

        private void скачатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";
            string query = "SELECT * FROM public.\"user\"";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            Filter = "PDF files (*.pdf)|*.pdf",
                            Title = "��������� PDF ����",
                            FileName = "Users.pdf"
                        };

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = saveFileDialog.FileName;
                            SaveDataTableToPdf(dataTable, filePath);
                            MessageBox.Show($"PDF загружен: {filePath}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ошибка: {ex.Message}");
            }
        }

        private void получитьБонусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BonusForm bonusForm = new BonusForm();
            bonusForm.Show();
        }

        private void завершитьТекущуюСессиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void обратнаяСвязьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeedbackForm feedbackForm = new FeedbackForm();
            feedbackForm.ShowDialog();
        }
    }
}



