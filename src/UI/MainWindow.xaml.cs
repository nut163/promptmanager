```csharp
using System;
using System.Windows;
using src.Database;
using src.Utils;

namespace src.UI
{
    public partial class MainWindow : Window
    {
        private DatabaseManager _dbManager;
        private SearchFilter _searchFilter;
        private DataImportExport _dataImportExport;

        public MainWindow()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
            _searchFilter = new SearchFilter(_dbManager);
            _dataImportExport = new DataImportExport(_dbManager);
        }

        private void CreatePromptButton_Click(object sender, RoutedEventArgs e)
        {
            var promptWindow = new PromptWindow(_dbManager);
            promptWindow.Show();
        }

        private void UpdatePromptButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedPrompt = (Prompt)PromptListView.SelectedItem;
            if (selectedPrompt != null)
            {
                var promptWindow = new PromptWindow(_dbManager, selectedPrompt);
                promptWindow.Show();
            }
        }

        private void DeletePromptButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedPrompt = (Prompt)PromptListView.SelectedItem;
            if (selectedPrompt != null)
            {
                _dbManager.DeletePrompt(selectedPrompt);
                RefreshPromptList();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchResults = _searchFilter.SearchPrompts(SearchTextBox.Text);
            PromptListView.ItemsSource = searchResults;
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            _dataImportExport.ImportData();
            RefreshPromptList();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            _dataImportExport.ExportData();
        }

        private void RefreshPromptList()
        {
            var prompts = _dbManager.GetPrompts();
            PromptListView.ItemsSource = prompts;
        }
    }
}
```