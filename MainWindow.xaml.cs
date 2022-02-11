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

namespace LatinNounApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();

            Console.WriteLine("Here\'s some stuff.");
        }

        /*DeclineNoun: Uses LatinNoun class to decline noun user inputs into "UserNoun" input box 
         and then sets the TextBlocks used to hold the noun in its grammatical declensions
         equal to the noun in its cooresponding declension.*/
        private LatinNoun latinNoun;
        public void DeclineNoun(Object sender, RoutedEventArgs e)
        {
            // LatinNoun class responds to empty input with error, if statment prevents this.
            if (!UserNoun.Text.Equals(""))
            {
                latinNoun = new LatinNoun(UserNoun.Text);

                NomSg.Text = latinNoun.NominativeSingular;
                AccSg.Text = latinNoun.AccusitiveSingular;
                DatSg.Text = latinNoun.DativeSingular;
                GenSg.Text = latinNoun.GenativeSingular;
                AblSg.Text = latinNoun.AblativeSingular;
                VocSg.Text = latinNoun.VocativeSingular;

                NomPl.Text = latinNoun.NominativePlural;
                AccPl.Text = latinNoun.AccusitivePlural;
                DatPl.Text = latinNoun.DativePlural;
                GenPl.Text = latinNoun.GenativePlural;
                AblPl.Text = latinNoun.AblativePlural;
                VocPl.Text = latinNoun.VocativePlural;

                Gender.Text = latinNoun.Gender;
            }
        
        }
       
    }
}

// (10 OCT 2021) Next step, learn about error handling to respond to errors that come up, first and foremost, the error that occures when a letter in the suffix is capitalized 