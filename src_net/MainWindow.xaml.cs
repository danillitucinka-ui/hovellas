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
            evidenceManager.UpdateSuspicion(suspectManager);
            UpdateSuspicionList();
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
    }
}