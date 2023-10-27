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

/*
internal class Card
{
    public Card()
    {
    }

    public string Name { get; set; }
    public int Value { get; set; }

    var Cards = new List<Card>()
{
    new Card() { Name = "Dier 1", Value = 1 },
    new Card() { Name = "Dier 2", Value = 2 },
    new Card() { Name = "Dier 3", Value = 3 },
    new Card() { Name = "Dier 4", Value = 4 },
    new Card() { Name = "Dier 5", Value = 5 },
    new Card() { Name = "Dier 6", Value = 6 }
};
}
*/

//werkt niet^




//string[] Cards = { "Dier 1", "Dier 2",  "Dier 3", "Dier 4", "Dier 5", "Dier 6" };

String Cards = "Temp";

var rnd = new Random();
var shuffledCards = Cards.OrderBy(a => rnd.Next());
//Do something with shuffledCards

// werkt wel^



/*
for (int i = 0; i < Cards.Length; i++)
{
    swap(ref Cards[i], ref Cards[i + rnd.Next(Cards.Length - i)]);
}

void swap(ref string a, ref string b)
{
    string t = a;
    a = b;
    b = t;
}
*/

//andere form van shufflen^



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







