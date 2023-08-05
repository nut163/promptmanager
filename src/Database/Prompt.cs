```csharp
using System;

namespace SoftwareForManagingPromptsAndInstructions.Database
{
    public class Prompt
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public Prompt(int id, string title, string content, DateTime timestamp)
        {
            ID = id;
            Title = title;
            Content = content;
            Timestamp = timestamp;
        }
    }
}
```