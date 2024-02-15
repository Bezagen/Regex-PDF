using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFReader.Structures
{
    public class SearchParameters
    {
        private string _searchOption;
        private string _estimateKey;
        private string _regexPattern;
        private int _symbolsCount;
        private List<string> _searchOptions;
        private List<string> _regexPatterns;

        public string SearchOption { get => _searchOption;}
        public string EstimateKey { get => _estimateKey;}
        public string RegexPattern { get => _regexPattern; }
        public int SymbolsCount { get => _symbolsCount;  }
        public List<string> SearchOptions { get => _searchOptions; }
        public List<string> RegexPatterns { get => _regexPatterns; }

        public SearchParameters(string searchOption, string estimateKey, string regexPattern, int symbolsCount) // For tags search
        {
            _searchOption = searchOption;
            _estimateKey = estimateKey;
            _regexPattern = regexPattern;
            _symbolsCount = symbolsCount;
        }

        public SearchParameters(List<string> searchOptions, string estimateKey, string regexPattern, int symbolsCount) // List tags
        {
            _searchOptions = searchOptions;
            _estimateKey = estimateKey;
            _regexPattern = regexPattern;
            _symbolsCount = symbolsCount;
        }

        public SearchParameters(string estimateKey, string regexPattern) // For Regex search
        {
            _estimateKey = estimateKey;
            _regexPattern = regexPattern;
        }

        public SearchParameters(string estimateKey, List<string> regexPatterns) //For RegexList search
        {
            _estimateKey = estimateKey;
            _regexPatterns = regexPatterns;
        }
    }
}
