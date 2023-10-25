using System;
using System.Collections.ObjectModel;
using System.Windows;
using Npgsql;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> tasks;
        private string connectionString = "Host=localhost;Port=5432;Database=task_manager;Username=postgres;Password=12qwaszx";

        public MainWindow()
        {
            InitializeComponent();
            tasks = new ObservableCollection<Task>();
            LoadTasks();
        }

        private void LoadTasks()
        {
            tasks.Clear();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM tasks ORDER BY priority ASC";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Task task = new Task
                            {
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                DueDate = reader.GetDateTime(3),
                                Priority = reader.GetInt32(4)
                            };

                            tasks.Add(task);
                        }
                        CheckDueDates();
                    }
                }
            }

            taskGrid.ItemsSource = tasks;
        }

        private void CheckDueDates()
        {
            foreach (Task task in tasks)
            {
                TimeSpan timeUntilDue = task.DueDate - DateTime.Now;
                if (timeUntilDue.TotalDays <= 1)
                {
                    MessageBox.Show($"Задача '{task.Name},' подходит срок выполнения!");
                }
            }
        }
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            // Добавление
            AddTaskWindow addTaskWindow = new AddTaskWindow(connectionString);
            addTaskWindow.ShowDialog();

            // Обновляется список
            LoadTasks();
            
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на выбор
            if (taskGrid.SelectedItem != null && taskGrid.SelectedItem is Task selectedTask)
            {
                // Редактирование
                EditTaskWindow editTaskWindow = new EditTaskWindow(connectionString, selectedTask);
                editTaskWindow.ShowDialog();

                // Обновление списка
                LoadTasks();
               
            }
        }


        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на выбор
            if (taskGrid.SelectedItem != null && taskGrid.SelectedItem is Task selectedTask)
            {
                // Удаление
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM tasks WHERE name = @name";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("name", selectedTask.Name);
                        command.ExecuteNonQuery();
                    }
                }

                // Обновляем список
                LoadTasks();
            }
        }
    }
}
