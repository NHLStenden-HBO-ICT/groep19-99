using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace memory99
{
    public partial class MainWindow : Window
    {
        //bool muziek = false;

        public MainWindow()
        {
            InitializeComponent();
        }


        public void MemoryDierenThema_Click(object sender, RoutedEventArgs e)
        {
            MemoryWindow memory = new MemoryWindow(Speler1.Text,Speler2.Text,"Dieren");
            memory.Left = this.Left;
            memory.Top = this.Top;
            memory.Height = this.Height;
            memory.Width = this.Width;
            memory.Visibility = Visibility.Visible;
        }

        private void MemoryNijntjeThema_Click(object sender, RoutedEventArgs e)
        {
            MemoryWindow memory = new MemoryWindow(Speler1.Text, Speler2.Text,"Nijntje");
            memory.Left = this.Left;
            memory.Top = this.Top;
            memory.Height = this.Height;
            memory.Width = this.Width;
            memory.Visibility = Visibility.Visible;
        }
        private void MemoryOnderwaterThema_Click(object sender, RoutedEventArgs e)
        {
            MemoryWindow memory = new MemoryWindow(Speler1.Text, Speler2.Text, "Onderwater");
            memory.Left = this.Left;
            memory.Top = this.Top;
            memory.Height = this.Height;
            memory.Width = this.Width;
            memory.Visibility = Visibility.Visible;
        }

        private void Uitleg_Click(object sender, RoutedEventArgs e)
        {
            UitlegScherm uitlegScherm = new UitlegScherm();
            uitlegScherm.Left = this.Left;
            uitlegScherm.Top = this.Top;
            uitlegScherm.Height = this.Height;
            uitlegScherm.Width = this.Width;
            uitlegScherm.Visibility = Visibility.Visible;
        }

        private void Spel_Sluiten(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
