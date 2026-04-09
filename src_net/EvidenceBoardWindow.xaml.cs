using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace HovellasUI
{
    public partial class EvidenceBoardWindow : Window
    {
        private List<Suspect> suspects;
        private List<Evidence> evidences;
        private List<Line> connections = new List<Line>();

        public EvidenceBoardWindow(List<Suspect> s, List<Evidence> e)
        {
            InitializeComponent();
            suspects = s;
            evidences = e;
            DrawBoard();
        }

        private void DrawBoard()
        {
            // Рисуем подозреваемых
            for (int i = 0; i < suspects.Count; i++)
            {
                var img = new Image { Width = 50, Height = 50 };
                Canvas.SetLeft(img, 100 + i * 100);
                Canvas.SetTop(img, 50);
                BoardCanvas.Children.Add(img);
            }

            // Рисуем улики
            for (int i = 0; i < evidences.Count; i++)
            {
                var img = new Image { Width = 50, Height = 50 };
                Canvas.SetLeft(img, 100 + i * 100);
                Canvas.SetTop(img, 200);
                BoardCanvas.Children.Add(img);
            }
        }

        // Логика соединения нитями (упрощенная)
        private void Connect(int suspectIndex, int evidenceIndex)
        {
            var line = new Line
            {
                X1 = 125 + suspectIndex * 100,
                Y1 = 75,
                X2 = 125 + evidenceIndex * 100,
                Y2 = 225,
                Stroke = System.Windows.Media.Brushes.Red,
                StrokeThickness = 2
            };
            BoardCanvas.Children.Add(line);
            connections.Add(line);
        }
    }
}