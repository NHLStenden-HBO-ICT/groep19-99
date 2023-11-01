using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace memory99
{
    /// <summary>
    /// Interaction logic for WinstScherm.xaml
    /// </summary>
    public partial class WinstScherm : Window
    {
        public WinstScherm(String Winnaar, int ScoreWinnaar, String TweedePlaats, int ScoreTweedePlaats,Boolean equal)
        {
            InitializeComponent();
            if (!equal)
            {
                Regel1.Content = "Winnaar: " + Winnaar;
                Regel2.Content = "Score: " + ScoreWinnaar;
                Regel3.Content = "Tweede plaats: " + TweedePlaats;
                Regel4.Content = "Score: " + ScoreTweedePlaats;
            } else
            {
                Regel1.Content = "Gelijkspel: " + Winnaar;
                Regel2.Content = "Score: " + ScoreWinnaar;
                Regel3.Content = "Gelijkspel: " + TweedePlaats;
                Regel4.Content = "Score: " + ScoreTweedePlaats;
            }
        }

        private void GaTerug(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
