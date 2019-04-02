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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace s12001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            //input
            char[] cards = new char[17];
            string debugoutput = "";
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = txtInput.Text[i];
                debugoutput += cards[i].ToString() + Environment.NewLine;
            }
            //MessageBox.Show(debugoutput);

            //process
            int points = 0;
            int total = 0;
            string output = "Cards Dealt\tPoints";
            //loop and calculate points for each hand based on face value.  Add to output
            //Ace(4 points), King(3 points), Queen(2 points) and Jack(1 point).
            int cardsInSuit = -1;
            for (int i = 0; i < cards.Length; i++)
            {
                switch (cards[i])
                {
                    case ('A'): points += 4;
                        break;
                    case ('K'): points+=3;
                        break;
                    case ('Q'): points += 2;
                        break;
                    case ('J'): points += 1;
                        break;
                    case ('D'):
                    case ('H'):
                    case ('S'):
                        switch (cardsInSuit)
                        {
                            case 0: points += 3; break;
                            case 1: points += 2; break;
                            case 2: points += 1; break;
                        }
                        output += points.ToString() + Environment.NewLine;
                        
                        total += points;
                            points = 0;
                        cardsInSuit = -1;

                        break;
                                
                }
                cardsInSuit++;

            }
            output += points.ToString() + Environment.NewLine;
            total += points;
            points = 0;


            //output
            lblOuptut.Content = output;


        }
    }
}
