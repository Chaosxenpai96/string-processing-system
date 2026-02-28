using StringProcessingApp.Services;

namespace StringProcessingApp.Views
{
    public class StringView
    {
        private readonly StringService _stringService;

        public StringView()
        {
            _stringService = new StringService();
        }

        public void Run()
        {
            Console.WriteLine("      STRING PROCESSING SYSTEM          ");
           
            bool running = true;

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1":
                        EnterText();
                        break;
                    case "2":
                        ViewCurrentText();
                        break;
                    case "3":
                        ConvertToUppercase();
                        break;
                    case "4":
                        ConvertToLowercase();
                        break;
                    case "5":
                        CountCharacters();
                        break;
                    case "6":
                        CheckContains();
                        break;
                    case "7":
                        ReplaceWord();
                        break;
                    case "8":
                        ExtractSubstring();
                        break;
                    case "9":
                        TrimSpaces();
                        break;
                    case "10":
                        ResetText();
                        break;
                    case "11":
                        running = false;
                        Console.WriteLine("\nGoodbye!");
                        break;
                    default:
                        Console.WriteLine("\n[!] Invalid option. Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("               MAIN MENU                ");
            Console.WriteLine(" 1.  Enter Text");
            Console.WriteLine(" 2.  View Current Text");
            Console.WriteLine(" 3.  Convert to UPPERCASE");
            Console.WriteLine(" 4.  Convert to lowercase");
            Console.WriteLine(" 5.  Count Characters");
            Console.WriteLine(" 6.  Check if Contains Word");
            Console.WriteLine(" 7.  Replace Word");
            Console.WriteLine(" 8.  Extract Substring");
            Console.WriteLine(" 9.  Trim Spaces");
            Console.WriteLine(" 10. Reset Text");
            Console.WriteLine(" 11. Exit");
            Console.Write("Enter your choice: ");
        }

        private void EnterText()
        {
            Console.Write("\nEnter your text: ");
            string input = Console.ReadLine() ?? "";
            _stringService.SetText(input);
            Console.WriteLine($"[✓] Text saved: \"{_stringService.CurrentText}\"");
        }

        private void ViewCurrentText()
        {
            if (!_stringService.HasText())
            {
                Console.WriteLine("\n[!] No text entered yet. Please use option 1 first.");
                return;
            }
            Console.WriteLine($"\nCurrent Text: \"{_stringService.CurrentText}\"");
        }

        private void ConvertToUppercase()
        {
            if (!_stringService.HasText()) { NoTextWarning(); return; }
            string result = _stringService.ToUppercase();
            Console.WriteLine($"\n[✓] Uppercase: \"{result}\"");
        }

        private void ConvertToLowercase()
        {
            if (!_stringService.HasText()) { NoTextWarning(); return; }
            string result = _stringService.ToLowercase();
            Console.WriteLine($"\n[✓] Lowercase: \"{result}\"");
        }

        private void CountCharacters()
        {
            if (!_stringService.HasText()) { NoTextWarning(); return; }
            int count = _stringService.CountCharacters();
            Console.WriteLine($"\n[✓] Character count: {count}");
        }

        private void CheckContains()
        {
            if (!_stringService.HasText()) { NoTextWarning(); return; }
            Console.Write("\nEnter the word to search for: ");
            string word = Console.ReadLine() ?? "";
            bool found = _stringService.CheckContains(word);
            Console.WriteLine(found
                ? $"\n[✓] The text CONTAINS \"{word}\"."
                : $"\n[✗] The text does NOT contain \"{word}\".");
        }

        private void ReplaceWord()
        {
            if (!_stringService.HasText()) { NoTextWarning(); return; }
            Console.Write("\nEnter the word to replace: ");
            string oldWord = Console.ReadLine() ?? "";
            Console.Write("Enter the new word: ");
            string newWord = Console.ReadLine() ?? "";
            string result = _stringService.ReplaceWord(oldWord, newWord);
            Console.WriteLine($"\n[✓] Result: \"{result}\"");
        }

        private void ExtractSubstring()
        {
            if (!_stringService.HasText()) { NoTextWarning(); return; }
            Console.WriteLine($"\nCurrent text ({_stringService.CountCharacters()} characters): \"{_stringService.CurrentText}\"");

            Console.Write("Enter start index: ");
            if (!int.TryParse(Console.ReadLine(), out int startIndex))
            {
                Console.WriteLine("[!] Invalid index.");
                return;
            }

            Console.Write("Enter length: ");
            if (!int.TryParse(Console.ReadLine(), out int length))
            {
                Console.WriteLine("[!] Invalid length.");
                return;
            }

            try
            {
                string result = _stringService.ExtractSubstring(startIndex, length);
                Console.WriteLine($"\n[✓] Extracted substring: \"{result}\"");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("[!] Index or length is out of range. Please check your values.");
            }
        }

        private void TrimSpaces()
        {
            if (!_stringService.HasText()) { NoTextWarning(); return; }
            string result = _stringService.TrimSpaces();
            Console.WriteLine($"\n[✓] Trimmed text: \"{result}\"");
        }

        private void ResetText()
        {
            if (!_stringService.HasText()) { NoTextWarning(); return; }
            string result = _stringService.ResetText();
            Console.WriteLine($"\n[✓] Text reset to original: \"{result}\"");
        }

        private void NoTextWarning()
        {
            Console.WriteLine("\n[!] No text entered yet. Please use option 1 first.");
        }
    }
}
