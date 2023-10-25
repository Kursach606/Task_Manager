using System;
using System.Windows;
using System.Windows.Controls;
using Npgsql;

namespace TaskManager
{
    public partial class EditTaskWindow : Window
    {
        private string connectionString;
        private Task task;

        public EditTaskWindow(string connectionString, Task task)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.task = task;

            nameTextBox.Text = task.Name;
            descriptionTextBox.Text = task.Description;
            dueDatePicker.SelectedDate = task.DueDate;
            priorityComboBox.SelectedItem = task.Priority;
        }

        private void UpdateTask_Click(object sender, RoutedEventArgs e)
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

                        string sql = "UPDATE tasks SET name = @name, description = @description, due_date = @dueDate, priority = @priority WHERE name = @oldName";
                        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("name", name);
                            command.Parameters.AddWithValue("description", description);
                            command.Parameters.AddWithValue("dueDate", dueDate);
                            command.Parameters.AddWithValue("priority", priority);
                            command.Parameters.AddWithValue("oldName", task.Name);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Задача успешно обновлена!");

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
