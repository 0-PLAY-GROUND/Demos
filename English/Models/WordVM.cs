using English.Models;
using System.Collections.Generic;

namespace English.Models
{
    public class WordVM
    {
        public Word Word;
        public string WordLink { get { return "https://www.lexico.com/en/definition/" + this.Word.WordText; } }       
        public WordVM()
        {
            Word = new Word();
            
        }
    }
}
