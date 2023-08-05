```csharp
using System;
using System.Data.SQLite;
using src.Security;

namespace src.Database
{
    public class DatabaseManager
    {
        private SQLiteConnection connection;
        private string connectionString = "Data Source=prompts.db;Version=3;";

        public DatabaseManager()
        {
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            CreateTables();
        }

        private void CreateTables()
        {
            string createPromptsTable = "CREATE TABLE IF NOT EXISTS Prompts (ID INTEGER PRIMARY KEY, Title TEXT, Content TEXT, Timestamp DATETIME)";
            string createInstructionsTable = "CREATE TABLE IF NOT EXISTS Instructions (ID INTEGER PRIMARY KEY, PromptID INTEGER, InstructionText TEXT, Timestamp DATETIME, FOREIGN KEY(PromptID) REFERENCES Prompts(ID))";

            SQLiteCommand command = new SQLiteCommand(createPromptsTable, connection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand(createInstructionsTable, connection);
            command.ExecuteNonQuery();
        }

        public void InsertPrompt(Prompt prompt)
        {
            string query = $"INSERT INTO Prompts (Title, Content, Timestamp) VALUES ('{prompt.Title}', '{prompt.Content}', '{DateTime.Now}')";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void InsertInstruction(Instruction instruction)
        {
            string query = $"INSERT INTO Instructions (PromptID, InstructionText, Timestamp) VALUES ('{instruction.PromptID}', '{instruction.InstructionText}', '{DateTime.Now}')";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void UpdatePrompt(Prompt prompt)
        {
            string query = $"UPDATE Prompts SET Title = '{prompt.Title}', Content = '{prompt.Content}', Timestamp = '{DateTime.Now}' WHERE ID = {prompt.ID}";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void UpdateInstruction(Instruction instruction)
        {
            string query = $"UPDATE Instructions SET PromptID = '{instruction.PromptID}', InstructionText = '{instruction.InstructionText}', Timestamp = '{DateTime.Now}' WHERE ID = {instruction.ID}";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void DeletePrompt(int id)
        {
            string query = $"DELETE FROM Prompts WHERE ID = {id}";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void DeleteInstruction(int id)
        {
            string query = $"DELETE FROM Instructions WHERE ID = {id}";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}
```