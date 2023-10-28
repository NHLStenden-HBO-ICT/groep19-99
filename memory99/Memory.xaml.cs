using memory99;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static memory99.Memory;
using static System.Formats.Asn1.AsnWriter;

namespace memory99
{
    
    /// <summary>
    /// Interaction logic for Memory.xaml
    /// </summary>
    


    public partial class Memory : Window
    {
        private List<string> deck;
        private List<string> flippedCards;
        private int score;

        // <summary>
        // Constructs a new Memory Game with a deck of cards.
        // </summary>
        public Memory()
        {
            deck = new List<string>();
            flippedCards = new List<string>();
            score = 0;
        }


    }

}







