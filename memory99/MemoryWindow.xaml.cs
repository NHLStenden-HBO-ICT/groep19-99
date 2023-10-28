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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;
using System.IO;


namespace memory99
{

    /// <summary>
    /// Interaction logic for Memory.xaml
    /// </summary>

    public partial class MemoryWindow : Window
    {
        private BitmapImage backside = new BitmapImage(new Uri("/images/logo.png", UriKind.Relative));
        private List<BitmapImage> images;
        private List<int> deck = new List<int>();
        private List<Boolean> flippedCards = new List<Boolean>();
        private int previousIndex = -1;
        private int previousImage = -1;
        private Boolean notEqual = false;
        private int index = -1;
        private int score = 0;

        // <summary>
        // Constructs a new Memory Game with a deck of cards.
        // </summary>
        public MemoryWindow(String Naam1, String Naam2)
        {
            InitializeComponent();
            //
            Speler1.Content = Naam1;
            Speler2.Content = Naam2;
            // add all images in the list
            images = AddImages();
            // preset all cards to not flipped
            for (int i = 0; i < 12; i++)
            {
                flippedCards.Add(false);
            }
            // pick 6 random cards and add them twice
            Random r = new Random();
            for (int i = 0; i < 6; i++) {
                int rInt = r.Next(1, images.Count);
                while (deck.Contains(rInt))
                {
                   rInt = r.Next(1, images.Count);
                }
                deck.Add(rInt);
                deck.Add(rInt);
            }
            // randomly shuffle the deck
            deck = deck.OrderBy(a => r.Next()).ToList();
            // set all images to the backside of the card
            foreach (var ctrl in MemoryGrid.Children)
            {
                if (ctrl.GetType().Name.Equals("Button"))
                {
                    ((Image)((Button)ctrl).Content).Source = backside;
                }
            }

            MemoryGrid.Focus();
        }

        // one of the buttons is clicked
        private void CheckImage(object sender, RoutedEventArgs e)
        {
            if(notEqual) { 
                ((Image)((Button)MemoryGrid.FindName("b" + index)).Content).Source = backside;
                ((Image)((Button)MemoryGrid.FindName("b" + (previousIndex+1))).Content).Source = backside;
                flippedCards[index - 1] = false;
                flippedCards[previousIndex] = false;
                previousIndex = -1;
                previousImage = -1;
                notEqual = false;
                return;
            }
            // determine index based on the name (b1, b2, ... b12)
            index = Int32.Parse(((Button)sender).Name.Substring(1));
            
            if (!flippedCards[index - 1])
            {   // card is not flipped
                if(previousIndex == -1)
                {   // first card
                    ((Image)((Button)sender).Content).Source = images[deck[index - 1]];
                    flippedCards[index - 1] = true;
                    previousIndex = index - 1;
                    previousImage = deck[index - 1];
                } else
                {   // second card
                    ((Image)((Button)sender).Content).Source = images[deck[index - 1]];
                    flippedCards[index - 1] = true;
                    if (previousImage == deck[index - 1])
                    {   // equal images
                        previousIndex = -1;
                        previousImage = -1;
                    } else
                    {   // not equal
                        notEqual = true;
                    }
                }
            }
        }

        private List<BitmapImage> AddImages()
        {
            List<BitmapImage> deck = new List<BitmapImage>();
            deck.Add(new BitmapImage(new Uri("/images/dieren achterkant speler 1.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/dieren achterkant speler 2.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/dieren ezel steen.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/dieren honden steen.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/dieren konijn steen.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/dieren paarden steen.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/dieren schaap steen.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/dieren varken steen.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/friese nijntje steen.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/jarige nijntje steen.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/nijntje achterkant steen speler 1.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/nijntje achterkant steen speler 2.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/nijntje met ballon steen.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/nijntje met knuffel steen.png", UriKind.Relative)));
            deck.Add(new BitmapImage(new Uri("/images/nijntje met schildpadden steen.png", UriKind.Relative)));
            return deck;
        }
    }

}
