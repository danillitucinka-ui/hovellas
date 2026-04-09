using System.Windows;

namespace HovellasUI
{
    public partial class DialogWindow : Window
    {
        private SuspectManager suspectManager;
        private DialogueEngine dialogueEngine;
        private string currentSuspect;

        public DialogWindow(SuspectManager sm, DialogueEngine de)
        {
            InitializeComponent();
            suspectManager = sm;
            dialogueEngine = de;
            currentSuspect = "Алексей Иванов"; // Пример
            UpdateDialog();
        }

        private void UpdateDialog()
        {
            DialogText.Text = dialogueEngine.StartDialogue(currentSuspect);
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {
            dialogueEngine.UpdateTrust(currentSuspect, 10, "Positive choice");
            UpdateDialog();
        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {
            dialogueEngine.UpdateTrust(currentSuspect, -10, "Negative choice");
            UpdateDialog();
        }
    }
}