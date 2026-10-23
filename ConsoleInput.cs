namespace ProductListManager
{
    public class ConsoleInput
    {
        // Asks the user until a non-empty value is entered.
        // prompt - text shown before the input, emptyMessage - error shown when the input is empty.
        public string ReadNonEmpty(string prompt, string emptyMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string? line = Console.ReadLine();

                // ReadLine() returns null when the input stream is closed (Ctrl+Z or redirected input has ended).
                if (line == null)
                {
                    Environment.Exit(0);
                }

                string userInput = line.Trim();

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    return userInput;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(emptyMessage);
                Console.ResetColor();
            }
        }
    }
}
