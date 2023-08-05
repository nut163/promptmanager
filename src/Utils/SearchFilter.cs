```csharp
using System.Collections.Generic;
using System.Linq;
using src.Database;

namespace src.Utils
{
    public static class SearchFilter
    {
        public static List<Prompt> FilterPrompts(string searchTerm, List<Prompt> prompts)
        {
            return prompts.Where(p => p.Title.Contains(searchTerm) || p.Content.Contains(searchTerm)).ToList();
        }

        public static List<Instruction> FilterInstructions(string searchTerm, List<Instruction> instructions)
        {
            return instructions.Where(i => i.InstructionText.Contains(searchTerm)).ToList();
        }
    }
}
```