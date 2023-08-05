```csharp
using System;
using System.Data.SQLite;
using System.IO;
using System.Text;
using CsvHelper;

namespace Utils
{
    public class DataImportExport
    {
        private string _connectionString;

        public DataImportExport(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ExportData(string filePath)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Prompts; SELECT * FROM Instructions;", connection);

                using (var reader = command.ExecuteReader())
                {
                    using (var writer = new StreamWriter(filePath))
                    {
                        using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
                        {
                            csv.WriteRecords(reader);
                        }
                    }
                }
            }
        }

        public void ImportData(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<dynamic>();
                    foreach (var record in records)
                    {
                        using (var connection = new SQLiteConnection(_connectionString))
                        {
                            connection.Open();
                            var command = new SQLiteCommand($"INSERT INTO Prompts VALUES ({record.ID}, {record.Title}, {record.Content}, {record.Timestamp});" +
                                                            $"INSERT INTO Instructions VALUES ({record.ID}, {record.PromptID}, {record.InstructionText}, {record.Timestamp});", connection);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
```