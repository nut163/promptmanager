```csharp
using System;
using System.Windows;
using src.Database;

namespace src.UI
{
    public partial class InstructionWindow : Window
    {
        private Instruction currentInstruction;
        private DatabaseManager dbManager;

        public InstructionWindow(DatabaseManager dbManager, Instruction instruction = null)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            this.currentInstruction = instruction;

            if (instruction != null)
            {
                txtInstruction.Text = instruction.InstructionText;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInstruction.Text))
            {
                MessageBox.Show("Instruction cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (currentInstruction == null)
            {
                currentInstruction = new Instruction { InstructionText = txtInstruction.Text };
                dbManager.AddInstruction(currentInstruction);
            }
            else
            {
                currentInstruction.InstructionText = txtInstruction.Text;
                dbManager.UpdateInstruction(currentInstruction);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
```