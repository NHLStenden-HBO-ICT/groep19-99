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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static memory99.Memory;

namespace memory99
{

    /// <summary>
    /// Interaction logic for Memory.xaml
    /// </summary>
    public partial class Memory : Window
    {
        public Memory()
        {

        }

    }

}

public class Card
{
    public string? Name { get; set; }
    public int? Value { get; set; }

}



var Cards = new List<Card>()
{
    new Card() { Name = "Dier 1", Value = 1 },
    new Card() { Name = "Dier 2", Value = 2 },
    new Card() { Name = "Dier 3", Value = 3 },
    new Card() { Name = "Dier 4", Value = 4 },
    new Card() { Name = "Dier 5", Value = 5 },
    new Card() { Name = "Dier 6", Value = 6 }
};



var rnd = new Random();
var shuffledCards = Cards.OrderBy(a => rnd.Next());
//Do something with shuffledCards

Card.cs(shuffledCards, Cards);
