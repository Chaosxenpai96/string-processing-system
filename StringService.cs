namespace StringProcessingApp.Services
{
    public class StringService
    {
        private string _originalText = string.Empty;
        private string _currentText = string.Empty;

        public string CurrentText => _currentText;

        public void SetText(string text)
        {
            _originalText = text;
            _currentText = text;
        }

        public string ToUppercase()
        {
            _currentText = _currentText.ToUpper();
            return _currentText;
        }

        public string ToLowercase()
        {
            _currentText = _currentText.ToLower();
            return _currentText;
        }

        public int CountCharacters()
        {
            return _currentText.Length;
        }

        public bool CheckContains(string word)
        {
            return _currentText.Contains(word);
        }

        public string ReplaceWord(string oldWord, string newWord)
        {
            _currentText = _currentText.Replace(oldWord, newWord);
            return _currentText;
        }

        public string ExtractSubstring(int startIndex, int length)
        {
            return _currentText.Substring(startIndex, length);
        }

        public string TrimSpaces()
        {
            _currentText = _currentText.Trim();
            return _currentText;
        }

        public string ResetText()
        {
            _currentText = _originalText;
            return _currentText;
        }

        public bool HasText()
        {
            return !string.IsNullOrEmpty(_currentText);
        }
    }
}
