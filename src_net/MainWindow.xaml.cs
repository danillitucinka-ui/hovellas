using System.Windows;
using System.Windows.Threading;

namespace HovellasUI
{
    public partial class MainWindow : Window
    {
        private SuspectManager suspectManager;
        private EvidenceManager evidenceManager;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            suspectManager = new SuspectManager();
            evidenceManager = new EvidenceManager();
            UpdateSuspicionList();
            StartMatrixRain();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void UpdateSuspicionList()
        {
            SuspicionList.Items.Clear();
            foreach (var suspect in suspectManager.GetAllSuspects())
            {
                SuspicionList.Items.Add($"{suspect.Name}: {suspect.SuspicionIndex}");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Динамическое время: ошибки отнимают 5 мин
            // Проверка на конец времени
            evidenceManager.UpdateSuspicion(suspectManager);
            UpdateSuspicionList();
            // Если время > 7200 сек, GameOver
        }

        private void StartMatrixRain()
        {
            // Simple matrix rain simulation
            for (int i = 0; i < 50; i++)
            {
                var textBlock = new System.Windows.Controls.TextBlock
                {
                    Text = "010101",
                    Foreground = System.Windows.Media.Brushes.Green,
                    FontFamily = new System.Windows.Media.FontFamily("Courier New"),
                    FontSize = 12
                };
                Canvas.SetLeft(textBlock, i * 20);
                Canvas.SetTop(textBlock, -i * 10);
                MatrixCanvas.Children.Add(textBlock);
            }
        }

        private void OpenDialog_Click(object sender, RoutedEventArgs e)
        {
            // Открыть диалог с NPC, передача фокуса
            // inputHandler.SetDialogMode(true);
            var dialog = new DialogWindow(suspectManager, dialogueEngine);
            dialog.ShowDialog();
            // inputHandler.SetDialogMode(false);
        }

        private void OpenBoard_Click(object sender, RoutedEventArgs e)
        {
            var board = new EvidenceBoardWindow(suspectManager.GetAllSuspects(), evidenceManager.GetAllEvidences());
            board.Show();
        }

        private void DeductionCanvas_Drop(object sender, DragEventArgs e)
        {
            // Логика перетаскивания улик для обвинения
            var data = e.Data.GetData(typeof(Evidence)) as Evidence;
            if (data != null)
            {
                // Обвинить подозреваемого на основе улик
                // Проверка логики
            }
        }

        // Динамическое время и алиби NPC
        private void UpdateGameplay()
        {
            // Если ошибка в диалоге, отнять 5 мин
            // Изменить алиби NPC на основе найденных улик
            foreach (var suspect in suspectManager.GetAllSuspects())
            {
                if (evidenceManager.FoundCount() > 5) suspect.SuspicionIndex -= 10;
            }
        }
    }
}