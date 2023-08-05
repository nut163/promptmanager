```csharp
using System;

namespace SoftwareForManagingPromptsAndCustomInstructions.Database
{
    public class Instruction
    {
        public int ID { get; set; }
        public int PromptID { get; set; }
        public string InstructionText { get; set; }
        public DateTime Timestamp { get; set; }

        public Instruction(int id, int promptId, string instructionText, DateTime timestamp)
        {
            ID = id;
            PromptID = promptId;
            InstructionText = instructionText;
            Timestamp = timestamp;
        }
    }
}
```