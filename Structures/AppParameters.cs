using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFReader.Structures
{
    public class AppParameters
    {
        private int _charactersTo,
                    _charactersAfter;

        private const int _defaultCharsTo = 10,
                          _defaultCharsAfter = 10;

        public int CharactersTo 
        {
            get => _charactersTo;
            set { _charactersTo = value; } 
        }

        public int CharactersAfter
        {
            get => _charactersAfter;
            set { _charactersAfter = value; }
        }

        public AppParameters(int charactersTo, int charactersAfter)
        {
            _charactersTo = charactersTo;
            _charactersAfter = charactersAfter;
        }

        public AppParameters()
        {
            _charactersTo = Settings.Default.charactersTo;
            _charactersAfter = Settings.Default.charactersAfter;
        }

        public void SaveParameters()
        {
            Settings.Default.charactersTo = CharactersTo;
            Settings.Default.charactersAfter = CharactersAfter;
            Settings.Default.Save();
        }

        public void ResetToDeafault()
        {
            Settings.Default.charactersTo = _defaultCharsTo;
            Settings.Default.charactersAfter = _defaultCharsAfter;
            Settings.Default.Save();
            CharactersTo = Settings.Default.charactersTo;
            CharactersAfter = Settings.Default.charactersAfter;
        }
    }
}
