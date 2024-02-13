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
                    _charactersAfter,
                    _maxCharactersTo,
                    _maxCharactersAfter;

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

        public int MaxCharactersTo
        {
            get => _maxCharactersTo;
            set { _maxCharactersTo = value; }
        }

        public int MaxCharactersAfter
        {
            get => _maxCharactersAfter;
            set { _maxCharactersAfter = value; }
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
    }
}
