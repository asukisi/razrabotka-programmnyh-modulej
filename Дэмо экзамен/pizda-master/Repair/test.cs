using NUnit.Framework;
using Moq;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Repair.Tests
{
    [TestFixture]
    public class Form1Tests
    {
        private Mock<NpgsqlConnection> mockConnection;
        private Mock<NpgsqlCommand> mockCommand;
        private Mock<NpgsqlDataAdapter> mockAdapter;
        private Form1 form;

        [SetUp]
        public void Setup()
        {
            mockConnection = new Mock<NpgsqlConnection>("Host=localhost;Port=5432;Database=test2;Username=postgres;Password=3232;");
            mockCommand = new Mock<NpgsqlCommand>();
            mockAdapter = new Mock<NpgsqlDataAdapter>();
            form = new Form1("Admin");
        }

        [Test]
        public void TestLoadUserNamesIntoComboBox()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable.Columns.Add("username");
            dataTable.Rows.Add("testuser");

            mockAdapter.Setup(a => a.Fill(It.IsAny<DataTable>())).Callback<DataTable>(dt => dt.Merge(dataTable));

            // Act
            form.LoadUserNamesIntoComboBox();

        }

        [Test]
        public void TestInsertUser()
        {
            // Arrange
            mockCommand.Setup(c => c.ExecuteNonQuery()).Returns(1);

            // Act
            form.InsertUser();

            // Assert
            mockCommand.Verify(c => c.ExecuteNonQuery(), Times.Once);
        }

        [Test]
        public void TestDeleteSelectedRow()
        {
            // Arrange
            mockCommand.Setup(c => c.ExecuteNonQuery()).Returns(1);

            // Act
            form.DeleteSelectedRow();

            // Assert
            mockCommand.Verify(c => c.ExecuteNonQuery(), Times.Once);
        }
    }
}
