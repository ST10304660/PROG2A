using System;
//using System.Speech.Synthesis; // Enables text-to-speech


namespace CybersecurityAwarenessChatbot
{
    class Program
    {
        static void Main()
        {
            // Display the ASCII logo
            ASCIIArt.DisplayLogo();

            // Start the chatbot interaction (calling Chatbot.cs)
            Chatbot.StartChatbot();
        }
    }

    // Class for ASCII Art
    public class ASCIIArt
    {
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"

            ██████╗ ██╗   ██╗██████╗ ███████╗███████╗██████╗ 
            ██╔══██╗██║   ██║██╔══██╗██╔════╝██╔════╝██╔══██╗
            ██████╔╝██║   ██║██████╔╝█████╗  █████╗  ██║  ██║
            ██╔═══╝ ██║   ██║██╔═══╝ ██╔══╝  ██╔══╝  ██║  ██║
            ██║     ╚██████╔╝██║     ██║     ███████╗██████╔╝
            ╚═╝      ╚═════╝ ╚═╝     ╚═╝     ╚══════╝╚═════╝

 PUP (Potentially Unwanted Programs), Fed (Federal Cybersecurity Concerns)

                   Cybersecurity Awareness Chatbot

            ");
            Console.ResetColor();
        }
    }
}
