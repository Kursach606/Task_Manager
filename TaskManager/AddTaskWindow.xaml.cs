using System;
using System.Windows;
using System.Windows.Controls;
using Npgsql;

namespace TaskManager
{
    public partial class AddTaskWindow : Window
    {
        private string connectionString;

        public AddTaskWindow(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string description = descriptionTextBox.Text;
            DateTime dueDate = dueDatePicker.SelectedDate ?? DateTime.Now;

            if (priorityComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                if (int.TryParse(selectedItem.Content.ToString(), out int priority))
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();

                        string sql = "INSERT INTO tasks (name, description, due_date, priority) VALUES (@name, @description, @dueDate, @priority)";
                        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("name", name);
                            command.Parameters.AddWithValue("description", description);
                            command.Parameters.AddWithValue("dueDate", dueDate);
                            command.Parameters.AddWithValue("priority", priority);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Задача успешно добавлена!");

                    Close();
                }
                else
                {
                    MessageBox.Show("Приоритет должен быть числом!");
                }
            }
        }


        private void Canсel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
