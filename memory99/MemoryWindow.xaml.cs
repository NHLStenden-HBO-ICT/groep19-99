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
using System.Windows.Controls.Primitives;
using System.Net.Sockets;


namespace memory99
{

    /// <summary>
    /// Interaction logic for Memory.xaml
    /// </summary>

    public partial class MemoryWindow : Window
    {
        private List<BitmapImage> images;
        private List<int> deck = new List<int>();
        private List<Boolean> flippedCards = new List<Boolean>();
        private int previousIndex = -1;
        private int previousImage = -1;
        private Boolean notEqual = false;
        private int index = -1;
        private int actieveSpeler = 1;
        private int scoreSpeler1 = 0;
        private int scoreSpeler2 = 0;
        private String thema;
        private String naam1;
        private String naam2;

        // <summary>
        // Constructs a new Memory Game with a deck of cards.
        // </summary>
        public MemoryWindow(String Naam1, String Naam2, String thema)
        {
            InitializeComponent();
            // set the names of the players
            Speler1.Content = Naam1;
            Speler2.Content = Naam2;
            this.naam1 = Naam1;
            this.naam2 = Naam2;
            // show the active player
            Speler2.BorderThickness = new Thickness(6);
            Speler1.BorderThickness = new Thickness(6);
            Speler1.BorderBrush = Brushes.DeepPink;
            Speler1.Background = Brushes.Coral;

            // add all images in the list
            images = AddImages(thema);
            this.thema = thema;
            // preset all cards to not flipped
            for (int i = 0; i < 12; i++)
            {
                flippedCards.Add(false);
            }
            // pick 6 random cards and add them twice
            Random r = new Random();
            for (int i = 0; i < 6; i++) {
                int rInt = r.Next(1, images.Count+1);
                while (deck.Contains(rInt))
                {
                   rInt = r.Next(1, images.Count+1);
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
                    ((Image)((Button)ctrl).Content).Source = GetBackside(thema, actieveSpeler);
                }
            }

            MemoryGrid.Focus();
        }

        // one of the buttons/cards is clicked
        private void CheckImage(object sender, RoutedEventArgs e)
        {
            if(notEqual) { 
                flippedCards[index - 1] = false;
                flippedCards[previousIndex] = false;
                previousIndex = -1;
                previousImage = -1;
                notEqual = false;
                ChangePlayer();
                return;
            }
            // determine index based on the name (b1, b2, ... b12)
            index = Int32.Parse(((Button)sender).Name.Substring(1));
            
            if (!flippedCards[index - 1])
            {   // card is not flipped
                if(previousIndex == -1)
                {   // first card
                    ((Image)((Button)sender).Content).Source = images[deck[index - 1]-1];
                    flippedCards[index - 1] = true;
                    previousIndex = index - 1;
                    previousImage = deck[index - 1];
                } else
                {   // second card
                    ((Image)((Button)sender).Content).Source = images[deck[index - 1]-1];
                    flippedCards[index - 1] = true;
                    if (previousImage == deck[index - 1])
                    {   // equal images
                        previousIndex = -1;
                        previousImage = -1;
                        if(actieveSpeler==1)
                        {
                            scoreSpeler1++;
                        } else
                        {
                            scoreSpeler2++;
                        }
                        CheckForEndGame();
                    } else
                    {   // not equal
                        notEqual = true;
                    }
                }
            }
        }

        private void CheckForEndGame()
        {
            Boolean klaar = true;
            for (int i = 0; i < 12; i++) {
                if( !flippedCards[i])
                {
                    klaar = false;
                    break;
                }
            }
            if (klaar)
            {
                if (scoreSpeler1 > scoreSpeler2)
                {
                    WinstScherm winst = new WinstScherm(naam1, scoreSpeler1, naam2, scoreSpeler2,false);
                    winst.Left = this.Left;
                    winst.Top = this.Top;
                    winst.Height = this.Height;
                    winst.Width = this.Width;
                    winst.Visibility = Visibility.Visible;
                } else if(scoreSpeler1 < scoreSpeler2)
                {
                    WinstScherm winst = new WinstScherm(naam2, scoreSpeler2, naam1, scoreSpeler1,false);
                    winst.Left = this.Left;
                    winst.Top = this.Top;
                    winst.Height = this.Height;
                    winst.Width = this.Width;
                    winst.Visibility = Visibility.Visible;
                } else
                {
                    WinstScherm winst = new WinstScherm(naam1, scoreSpeler1, naam2, scoreSpeler2,true);
                    winst.Left = this.Left;
                    winst.Top = this.Top;
                    winst.Height = this.Height;
                    winst.Width = this.Width;
                    winst.Visibility = Visibility.Visible;
                }
            }
        }

        private void ChangePlayer()
        {
            if(actieveSpeler == 1)
            {
                Speler1.BorderThickness = new Thickness(6);
                Speler2.BorderThickness = new Thickness(6);
                Speler2.BorderBrush = Brushes.Orange;
                Speler2.Background = Brushes.Gold;
                Speler1.Background = Brushes.Transparent;
                actieveSpeler = 2;
            } else
            {
                Speler2.BorderThickness = new Thickness(6);
                Speler1.BorderThickness = new Thickness(6);
                Speler1.BorderBrush = Brushes.DeepPink;
                Speler1.Background = Brushes.Coral;
                Speler2.Background = Brushes.Transparent;
                actieveSpeler = 1;
            }
            // set all images to the backside of the card if they are not flipped
            foreach (var ctrl in MemoryGrid.Children)
            {
                if (ctrl.GetType().Name.Equals("Button"))
                {
                    // determine index based on the name (b1, b2, ... b12)
                    index = Int32.Parse(((Button)ctrl).Name.Substring(1));
                    if (!flippedCards[index-1]) { 
                        ((Image)((Button)ctrl).Content).Source = GetBackside(thema, actieveSpeler);
                    }
                }
            }
        }

        private BitmapImage GetBackside(String thema,int speler)
        {
            if (thema == "Nijntje")
            {
                if (speler == 1)
                {
                    return new BitmapImage(new Uri("/images/nijntje achterkant steen speler 1.png", UriKind.Relative));
                } else
                {
                    return new BitmapImage(new Uri("/images/nijntje achterkant steen speler 2.png", UriKind.Relative));
                }
            }
            else if (thema == "Dieren")
            {
                if (speler == 1)
                {
                    return new BitmapImage(new Uri("/images/dieren achterkant speler 1.png", UriKind.Relative));
                } else
                {
                    return new BitmapImage(new Uri("/images/dieren achterkant speler 2.png", UriKind.Relative));
                }
            }
            else if (thema == "Onderwater")
            {
                if (speler == 1)
                {
                    return new BitmapImage(new Uri("/images/onderwater achterkant steen speler 1.png", UriKind.Relative));
                }
                else
                {
                    return new BitmapImage(new Uri("/images/onderwater achterkant steen speler 2.png", UriKind.Relative));
                }
            }
            return new BitmapImage(new Uri("/images/logo.png", UriKind.Relative));
        }

        private List<BitmapImage> AddImages(String thema)
        {
            List<BitmapImage> deck = new List<BitmapImage>();
            if (thema == "Nijntje")
            {
                deck.Add(new BitmapImage(new Uri("/images/friese nijntje steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/jarige nijntje steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/nijntje met ballon steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/nijntje met knuffel steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/nijntje met schildpadden steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/spelende nijntje steen.png", UriKind.Relative)));
            }
            else if (thema == "Dieren")
            {
                deck.Add(new BitmapImage(new Uri("/images/dieren ezel steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/dieren honden steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/dieren konijn steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/dieren paarden steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/dieren schaap steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/dieren varken steen.png", UriKind.Relative)));
            }
            else if (thema == "Onderwater")
            {
                deck.Add(new BitmapImage(new Uri("/images/henkie de haai steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/krab steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/kwal steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/schilpad steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/walrus steen.png", UriKind.Relative)));
                deck.Add(new BitmapImage(new Uri("/images/zeester steen.png", UriKind.Relative)));
            }
            return deck;
        }

        private void GaTerug(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Return_Click_1(object sender, RoutedEventArgs e)
        {
            MemoryWindow win = new MemoryWindow(naam1, naam2, thema);
            win.Show();
            this.Close();
        }
    }

}
