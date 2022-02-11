using System;
using System.Collections.Generic;
using System.Text;

namespace LatinNounApplication
{
    class LatinNoun
    {
       
        // Properties and fields
            // Noun declensions - singular and then plural.
        public String NominativeSingular { get; set; }
        public String AccusitiveSingular { get; set; }
        public String DativeSingular { get; set; }
        public String GenativeSingular { get; set; }
        public String AblativeSingular { get; set; }
        public String VocativeSingular { get; set; }
        public String NominativePlural { get; set; }
        public String AccusitivePlural { get; set; }
        public String DativePlural { get; set; }
        public String GenativePlural { get; set; }
        public String AblativePlural { get; set; }
        public String VocativePlural { get; set; }

        // Noun gender
        private String _gender;
        public String Gender
        {
            get => this._gender;

            // CheckGender() sets this.gender String field to "value"
            set
            {

                value = value.ToLower();

                if (Equals(value, "masculine") || Equals(value, "feminine") || Equals(value, "neuter")) { this._gender = value; }
                else if (Equals(value, "male")) { this._gender = "masculine"; }
                else if (Equals(value, "female")) { this._gender = "feminine"; }
                else if (Equals(value, "neutral")) { this._gender = "neuter"; }
                else
                {

                    value = UserInputFunctions.RequestValidConsoleInput("Please input valid gramatical gender; masculine, feminine or neuter.");
                    // Calls Gender's set method recursivly.
                    Gender = value;

                }

             }
        }
        // Nound declension (first, second, third etc.)
        private String _declension;
        public String Declension
        { 
            get=>this._declension;
            set
            {

                value = value.ToLower();
                if (Equals("first", value) || Equals("second", value) || Equals("third", value) ||
                    Equals("fourth", value) || Equals("fifth", value)){ 
                    this._declension = value; 
                }
                else if (Equals("1st", value) || Equals("1", value)) { 
                    this._declension = "first"; 
                }
                else if (Equals("2nd", value) || Equals("2", value)) { 
                    this._declension = "second"; 
                }
                else{
                    value = UserInputFunctions.RequestValidConsoleInput(value + " is not a valid declension. Please enter valid Latin declension;" +
                        " first, second, third, fourth or fifth.");
                    // Calls Declension's set method recursivly. 
                    Declension = value;
                }
            }
        }

        // Constructors
        public LatinNoun(String latinNoun)
        {

            int feminineSuffixLength = 1, masculineSuffixLength = 2, thirdDeclensionSuffixLength = 1;

            // Check to see if noun is feminine, indicated by "-a" suffix in the nominative case, if so, Append feminine endings.
            if (Equals(latinNoun.Substring(latinNoun.Length - feminineSuffixLength, feminineSuffixLength), "a"))
            {
                AppendSuffixes(feminineSuffixLength, latinNoun, "am", "ae", "ae", "a", "a", "ae", "as", "is", "arum", "is", "ae");
                this._gender = "Feminine";
                this._declension = "First";

            }
            // Check to see if noun is masculine, indicated by "-us" suffix in the nominative case, if so, apend masculine endings.
            else if (Equals(latinNoun.Substring(latinNoun.Length - masculineSuffixLength, masculineSuffixLength), "us"))
            {
                AppendSuffixes(masculineSuffixLength, latinNoun, "um", "o", "i", "o", "us", "i", "os", "is", "orum", "is", "i");
                this._gender = "Masculine";
                this._declension = "Second";
            }
            // Check to see if noun is neuter, indicated by "-um" suffix in the nominative case, if so, append neuter endings.
            else if (Equals(latinNoun.Substring(latinNoun.Length - masculineSuffixLength, masculineSuffixLength), "um"))
            {
                AppendSuffixes(masculineSuffixLength, latinNoun, "um", "o", "i", "o", "um", "a", "a", "is", "orum", "is", "a");
                this._gender = "Neuter";
                this._declension = "Second";
            }
            // Next two blocks are an attempt to append third declension suffixes, though this is far from perfect. Third declension
            // suffixes are less consistent than standard feminine, masculine and neuter suffixes.
            else if(Equals(latinNoun.Substring(latinNoun.Length - thirdDeclensionSuffixLength, thirdDeclensionSuffixLength), "o") &&
                Equals(latinNoun.Substring(latinNoun.Length - thirdDeclensionSuffixLength-1, thirdDeclensionSuffixLength+1),"mo")==false )
            {

                AppendSuffixes(0,latinNoun,"nem","ni","nis","ne","","nes","nes","nibus","num","nibus","nes");
                this._declension = "Third";

            }
            else if(Equals(latinNoun.Substring(latinNoun.Length - thirdDeclensionSuffixLength, thirdDeclensionSuffixLength), "x"))
            {

                AppendSuffixes(1, latinNoun, "cem", "ci", "cis", "ce", "x", "ces", "ces", "cibus", "cum", "cibus", "ces");
                this._declension = "Third";

            }
            else { Console.WriteLine("Declension not found."); }

        }

        /*AppendSuffixes() - Private function used in LatinNoun constructor. Arguments are as follows: the suffix length (int suffixLength), 
         * nominative form of the noun being declined (String latinNoun) and the nouns suffixes (String accSing, String genSing etc.). The method determines the gender 
         * of the noun, and then assigns the apropiete set of suffixes to their respective fields. 
         * Notes: Does not take input for the nominative singular suffix, the noun is entered in the nominative singular declension by default. Suffix length 
         * refers to the length of the suffix in the nominitve singular declension, i.e., the suffix length for "lupus," with the suffix "-us," is 2.*/
        private void AppendSuffixes(int suffixLength, String latinNoun, String accusativeSingular, String dativeSingular, String genitiveSingular, String ablativeSingular, String vocativeSingular,
            String nominativePlural, String accusativePlural, String dativePlural, String genitivePlural, String ablativePlural, String vocativePlural)
        {

            // Singular 
            NominativeSingular = latinNoun;
            AccusitiveSingular = AppendSingleSuffix(latinNoun, accusativeSingular, suffixLength);
            DativeSingular = AppendSingleSuffix(latinNoun, dativeSingular, suffixLength);
            GenativeSingular = AppendSingleSuffix(latinNoun, genitiveSingular, suffixLength);
            AblativeSingular = AppendSingleSuffix(latinNoun, ablativeSingular, suffixLength);
            VocativeSingular = AppendSingleSuffix(latinNoun, vocativeSingular, suffixLength);

            // Plural
            NominativePlural = AppendSingleSuffix(latinNoun, nominativePlural, suffixLength);
            AccusitivePlural = AppendSingleSuffix(latinNoun, accusativePlural, suffixLength);
            DativePlural = AppendSingleSuffix(latinNoun, dativePlural, suffixLength);
            GenativePlural = AppendSingleSuffix(latinNoun, genitivePlural, suffixLength);
            AblativePlural = AppendSingleSuffix(latinNoun, ablativePlural, suffixLength);
            VocativePlural = AppendSingleSuffix(latinNoun, vocativePlural, suffixLength);

        }
        /* AppendSingleSuffix(): Private method used in the Append suffixes method. Takes nominative noun (String), suffix(String) and suffix length(int)
         * as arguments and returns latin noun with the suffix appended(String). */
        private String AppendSingleSuffix(String nominativeNoun, String suffix, int suffixLength){
            return nominativeNoun.Substring(0, nominativeNoun.Length - suffixLength) + suffix;
        }
        
    }
}
