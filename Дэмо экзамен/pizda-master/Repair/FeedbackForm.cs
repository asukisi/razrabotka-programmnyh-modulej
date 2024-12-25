using Npgsql;

namespace Repair
{
    public partial class FeedbackForm : Form
    {
        string connectionString = "Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;";

        public FeedbackForm()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string email = textBoxEmail.Text;
            int rating = (int)numericUpDownRating.Value;
            string comment = textBoxComment.Text;

            string insertQuery = "INSERT INTO feedback (name, email, rating, comment) VALUES (@name, @email, @rating, @comment)";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@rating", rating);
                        command.Parameters.AddWithValue("@comment", comment);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Отзыв успешно отправлен.");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке отзыва: {ex.Message}");
            }
        }
    }

}
