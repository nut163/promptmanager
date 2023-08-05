```csharp
using System;
using System.Windows;
using src.Database;

namespace src.UI
{
    public partial class PromptWindow : Window
    {
        private DatabaseManager _dbManager;
        private Prompt _currentPrompt;

        public PromptWindow(DatabaseManager dbManager)
        {
            InitializeComponent();
            _dbManager = dbManager;
        }

        private void LoadPrompt(int id)
        {
            _currentPrompt = _dbManager.GetPrompt(id);
            txtTitle.Text = _currentPrompt.Title;
            txtContent.Text = _currentPrompt.Content;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _currentPrompt.Title = txtTitle.Text;
            _currentPrompt.Content = txtContent.Text;
            _currentPrompt.Timestamp = DateTime.Now;

            _dbManager.UpdatePrompt(_currentPrompt);
            MessageBox.Show("Prompt saved successfully.");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _dbManager.DeletePrompt(_currentPrompt.Id);
            MessageBox.Show("Prompt deleted successfully.");
            this.Close();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            _currentPrompt = new Prompt();
            txtTitle.Text = "";
            txtContent.Text = "";
        }
    }
}
```