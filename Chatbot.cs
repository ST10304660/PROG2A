using System;
using System.Numerics;
using System.Reflection;
using System.Threading;


namespace CybersecurityAwarenessChatbot
{
    // Farrell (2019, p. 104) – Shows use of static methods
    public class Chatbot
    {
        // Entry point to start the chatbot interaction
        public static void StartChatbot()
        {
            GreetingResponse();  // Calling GreetingResponse() to ask for the user's name and greet them

            Console.WriteLine("Type 'help' to get started or 'exit' to quit.\n");

            while (true)// Farrell (2019, p. 190) – Infinite loop for continuous interaction
            {
                // Get user input
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("You :   ");// Farrell (2019, p. 64) – Prompt user input
                Console.ResetColor();

                string userInput = Console.ReadLine().Trim().ToLower();// Farrell (2019, Ch. 2) – Read input, normalize for comparison


                if (userInput == "exit")// Farrell(2019, Ch. 4) – Conditional logic to exit
                {
                    Console.WriteLine("Stay safe online! Goodbye.");// Farrell (2019, p. 64) – Output message
                    break;// Farrell (2019, p. 190) – Exit loop
                }
                else if (userInput == "help")// Farrell (2019, Ch. 4) – Decision structure
                
                    {
                    ShowHelp();// Farrell (2019, Ch. 5) – Call modular help method
                }
                else
                {
                    ResponseHandler.Response(userInput); // Farrell (2019, Ch. 5) – Delegate to response handler
                }
            }
        }


        // Greeting method to welcome the user
        private static void GreetingResponse()
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer(); // Create TTS object

            Console.ForegroundColor = ConsoleColor.Cyan;
            string welcomeMessage = "Welcome to PUPFED - Your Cybersecurity Awareness Assistant!";
            Console.WriteLine(welcomeMessage);
            //synth.Speak(welcomeMessage); // Speak greeting message
            Console.ResetColor();

            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(userName))
            {
                string personalGreet = $"Hello, {userName}! I'm here to help you learn about cybersecurity.";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(personalGreet);
                //synth.Speak(personalGreet); // Speak personalized greeting
                Console.ResetColor();
            }
            else
            {
                string defaultGreet = "It seems you didn't enter a name. No worries, let's continue!";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(defaultGreet);
                //synth.Speak(defaultGreet); // Speak default message
                Console.ResetColor();
            }
        }

            private static void ShowHelp()
        {
            Console.WriteLine("\nHere are some topics you can ask about:"); // Farrell (2019, p. 64)
            Console.WriteLine("- How are you"); // Sample user input options
            Console.WriteLine("- What is cybersecurity?"); // Topic guidance
            Console.WriteLine("- How do I protect my password?"); // Security tip
            Console.WriteLine("- What is phishing?"); // Cyber threat explanation
            Console.WriteLine("- How do I update my software?"); // Maintenance advice
            Console.WriteLine("- What is malware?"); // Threat type info
            Console.WriteLine("- Tell me a fun fact"); // Engagement
        }

        // Show help topics
        // Inner class to handle response logic
        public class ResponseHandler// Farrell (2019, Ch. 8) – Class structure and inner class use
        {
            public static void Response(string userInput)// Farrell (2019, Ch. 5) – Static response method
            {
                userInput = userInput.ToLower();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Chatbot: ");
                Console.ResetColor();

                SimulateTyping(); // Simulates typing delay

                // Provide responses based on user input

                if (userInput.Contains("how are you"))
                {
                    Console.WriteLine("I'm PUPFED, I'm just a chatbot, but I'm always ready to help you with your cybersecurity questions!"); // Farrell (2019, Ch. 5)
                }
                else if (userInput.Contains("what's your purpose"))
                {
                    Console.WriteLine("My purpose is to help you learn about cybersecurity and keep you safe from online threats."); // Farrell (2019, Ch. 5)
                }
                else if (userInput.Contains("what can i ask you about") || userInput.Contains("what can I ask"))
                {
                    Console.WriteLine("You can ask me about various cybersecurity topics like phishing, password security, suspicious links, malware, VPNs, and much more! Type 'help' for a list of topics."); // Farrell (2019, Ch. 5)
                }
                else if (userInput.Contains("phishing"))
                {
                    Console.WriteLine("Phishing - Is a form of social engineering where attackers trick you into revealing sensitive information. Always check the sender's address and avoid clicking on suspicious links.");
                }
                else if (userInput.Contains("password"))
                {
                    Console.WriteLine("Password - A strong password should be at least 12 characters long, include numbers, special characters, and both upper and lowercase letters. Use different passwords for each account.");
                }
                else if (userInput.Contains("link"))
                {
                    Console.WriteLine("Link - Always be cautious when clicking on links. Check the URL carefully and avoid clicking on links from unknown or untrusted sources.");
                }
                else if (userInput.Contains("cybersecurity?"))
                {
                    Console.WriteLine("Cybersecurity refers to the practice of protecting systems, networks, and programs from digital attacks. These cyberattacks are usually aimed at accessing, changing, or destroying sensitive information, extorting money, or interrupting normal business processes.");
                }
                else if (userInput.Contains("two-factor authentication") || userInput.Contains("2FA"))
                {
                    Console.WriteLine("Two-Factor Authentication (2FA) - Adds an extra layer of security by requiring not only a password but also a second factor, like a text message code or authentication app.");
                }
                else if (userInput.Contains("cyberattack"))
                {
                    Console.WriteLine("Cyberattack - Is any malicious attempt to damage, disrupt, or gain unauthorized access to computer systems, networks, or devices.");
                }
                else if (userInput.Contains("safe"))
                {
                    Console.WriteLine("To stay safe online, always use strong, unique passwords, enable two-factor authentication, and avoid clicking on suspicious links.");
                }
                else if (userInput.Contains("https") || userInput.Contains("http"))
                {
                    Console.WriteLine("HTTP - HTTP (Hypertext Transfer Protocol) is a communication protocol used for transferring data over the web. It enables the fetching of resources, such as HTML pages, images, and other content, allowing users to browse websites."
                        + "HTTPS - HTTPS (Hypertext Transfer Protocol Secure) is the secure version of HTTP, used for encrypted communication between a web browser and a website. It ensures confidentiality, integrity, and authentication of data over the internet.");
                }
                else if (userInput.Contains("wi-fi") || userInput.Contains("public"))
                {
                    Console.WriteLine("Use a strong password for your Wi-Fi and avoid connecting to unsecured, public Wi-Fi networks without a VPN.");
                }
                else if (userInput.Contains("phishing tip"))
                {
                    Console.WriteLine("Phishing Tip: Always check the sender's email address carefully, avoid clicking suspicious links, and never share sensitive information through email unless you're sure of the recipient's identity.");
                }
                else if (userInput.Contains("protect") || userInput.Contains("data") || userInput.Contains("protection"))
                {
                    Console.WriteLine("Data protection is the process of preserving valuable information against theft, loss or errors occurring in the storage and transmission process.");
                }
                else if (userInput.Contains("vpn") || userInput.Contains("virtual"))
                {
                    Console.WriteLine("A VPN (Virtual Private Network) encrypts your internet connection, keeping your browsing activity private.");
                }
                else if (userInput.Contains("privacy"))
                {
                    Console.WriteLine("Privacy refers to the right of individuals to keep their personal information secure and control how it is collected, used, and shared.");
                }
                else if (userInput.Contains("mfa") || userInput.Contains("multi factor authentication"))
                {
                    Console.WriteLine("Multi-Factor Authentication (MFA) is a security process that requires users to provide two or more verification factors to gain access to a resource such as an application or online account.");
                }
                else if (userInput.Contains("ai") || userInput.Contains("artificial intelligence"))
                {
                    Console.WriteLine("AI is technology that appears to emulate human behavior in that it can continually learn and draw its own conclusions (even based on novel or abstract concepts), " +
                        "engage in natural dialog with people, and / or replace people in the execution of more complex (non-routine) tasks.");
                }
                else if (userInput.Contains("ads") || userInput.Contains("fake"))
                {
                    Console.WriteLine("Fake ads are deceptive advertisements that mislead users, often used in phishing attempts or to spread malware.");
                }
                else if (userInput.Contains("browser") || userInput.Contains("cookies"))
                {
                    Console.WriteLine("Cookies are small data files stored on your computer by websites to remember information about you, such as login status or preferences.");
                }
                else if (userInput.Contains("phishing email"))
                {
                    Console.WriteLine("A phishing email is a fraudulent message designed to trick the recipient into revealing sensitive information, such as login credentials or financial details.");
                }
                else if (userInput.Contains("spear-phishing"))
                {
                    Console.WriteLine("Spear-phishing is a targeted phishing attack aimed at a specific individual or organization, often using personalized information to increase credibility.");
                }
                else if (userInput.Contains("dns spoofing"))
                {
                    Console.WriteLine("DNS spoofing is an attack where corrupted DNS data is introduced into a DNS resolver's cache, causing the name server to return an incorrect IP address, diverting traffic to malicious sites.");
                }
                else if (userInput.Contains("biometric") || userInput.Contains("authentication"))
                {
                    Console.WriteLine("Biometric authentication is a security process that relies on the unique biological characteristics of a person, such as fingerprints, facial recognition, or iris scans.");
                }
                else if (userInput.Contains("recover"))
                {
                    Console.WriteLine("Recovery in cybersecurity refers to the process of restoring data and systems after a security breach or data loss event.");
                }
                else if (userInput.Contains("sms") || userInput.Contains("smishing") || userInput.Contains("phone") || userInput.Contains("calls") || userInput.Contains("vishing"))
                {
                    Console.WriteLine("Smishing (SMS phishing) and vishing (voice phishing) are forms of social engineering where attackers use text messages or phone calls to trick users into revealing sensitive information.");
                }
                else if (userInput.Contains("javascript"))
                {
                    Console.WriteLine("JavaScript is a programming language commonly used in web development. It can also be exploited by attackers to run malicious scripts on websites or steal user information.");
                }
                else if (userInput.Contains("trojan") || userInput.Contains("horse") || userInput.Contains("virus")) 
                {
                    Console.WriteLine("A virus is a self-replicating program that attaches itself to legitimate files or programs and spreads when the infected file is executed.\n  " +
                        "A Trojan horse is malware that disguises itself as a legitimate or useful program to trick users into installing it.");
                }
                else if (userInput.Contains("risk"))
                {
                    Console.WriteLine("A cybersecurity risk refers to the potential for loss or damage to an organization's information systems or data due to cyber threats.");
                }
                else if (userInput.Contains("spam") || userInput.Contains("filters"))
                {
                    Console.WriteLine("Spam refers to unwanted or unsolicited messages, typically sent in bulk. Spam filters are tools used to automatically detect and block such messages.");
                }
                else if (userInput.Contains("browsing") || userInput.Contains("history"))
                {
                    Console.WriteLine("Browsing history is a record of web pages that a user has visited. It can be tracked and potentially misused by third parties.");
                }
                else if (userInput.Contains("browser") || userInput.Contains("extension"))
                {
                    Console.WriteLine("Browser extensions are small software modules that add features to a web browser. Malicious extensions can compromise privacy or security.");
                }
                else if (userInput.Contains("malware") || userInput.Contains("virus"))
                {
                    Console.WriteLine("Malware refers to malicious software designed to damage, exploit, or gain unauthorized access to a computer system.");
                }
                else if (userInput.Contains("blockhain"))
                {
                    Console.WriteLine("A growing list of records, called blocks, linked using cryptography. It is a decentralized, distributed and public digital ledger that is used to record transactions across many computers in a way that the record can’t be altered retroactively without additionally changing all successive blocks and the consent of the network.");
                }
                else if (userInput.Contains("container"))
                {
                    Console.WriteLine("A container is a software unit that packages code so applications can run quickly across multiple environments. Containerization allows applications to be developed once and easily deployed across virtually any environment regardless of operating system, virtual machine or bare metal, on-prem data centers or public cloud.");
                }
                else if (userInput.Contains("dark web"))
                {
                    Console.WriteLine("The dark web is the part of the world wide web that is only accessible by means of special software, allowing users and website operators to remain somewhat more anonymous.");
                }
                else if (userInput.Contains("mitm") || userInput.Contains("man in the middle attack"))
                {
                    Console.WriteLine("An attack where a hacker intercepts communication between two parties.");
                }
                else if (userInput.Contains("denial of service attack") || userInput.Contains("dos"))
                {
                    Console.WriteLine("An attack that overwhelms a network or system, making it unavailable to users.");
                }
                else if (userInput.Contains("ips"))
                {
                    Console.WriteLine("Intrusion Prevention System (IPS) - A system that detects and blocks threats before they can harm the network.");
                }
                else if (userInput.Contains("ids"))
                {
                    Console.WriteLine("Intrusion Detection System (IDS) - A system that monitors network traffic for suspicious activities.");
                }
                else if (userInput.Contains("ransomeware"))
                {
                    Console.WriteLine("A type of malware that encrypts data and demands payment to restore access.");
                }
                else if (userInput.Contains("hashing"))
                {
                    Console.WriteLine("A process of converting data into a fixed-length code that cannot be reversed.");
                }
                else if (userInput.Contains("tokenization"))
                {
                    Console.WriteLine("Replacing sensitive data with a unique identifier (token) to protect the original data.");
                }
                else if (userInput.Contains("data masking"))
                {
                    Console.WriteLine("Hiding sensitive information to prevent unauthorized access.");
                }
                else if (userInput.Contains("firewall"))
                {
                    Console.WriteLine("A security system that monitors and controls incoming and outgoing network traffic.");
                }
                else if (userInput.Contains("spoofing"))
                {
                    Console.WriteLine(" An attack where fake DNS responses redirect users to malicious websites.");
                }
                else if (userInput.Contains("encryption"))
                {
                    Console.WriteLine("The process of converting data into a coded format to prevent unauthorized access.");
                }
                else if (userInput.Contains("authentication "))
                {
                    Console.WriteLine("The process of verifying the identity of a user or device.");
                }
                else if (userInput.Contains("zero-day"))
                {
                    Console.WriteLine("A zero-day vulnerability is a software flaw that is unknown to the vendor and has no patch available, making it highly exploitable by attackers.");
                }
                else if (userInput.Contains("social engineering"))
                {
                    Console.WriteLine("Social engineering is the manipulation of individuals into giving up confidential information, often by pretending to be a trustworthy source.");
                }
                else if (userInput.Contains("vpn") || userInput.Contains("virtual private network"))
                {
                    Console.WriteLine("A VPN (Virtual Private Network) creates a secure connection over the internet, encrypting your data and hiding your IP address to protect your privacy.");
                }
                else if (userInput.Contains("patch") || userInput.Contains("software update"))
                {
                    Console.WriteLine("A patch is a software update that fixes vulnerabilities, bugs, or adds improvements to a program or system.");
                }
                else if (userInput.Contains("backdoor"))
                {
                    Console.WriteLine("A backdoor is a hidden method of bypassing normal authentication in a computer system, often used by attackers to gain access.");
                }
                else if (userInput.Contains("brute force"))
                {
                    Console.WriteLine("A brute-force attack involves guessing passwords or encryption keys by trying all possible combinations until the correct one is found.");
                }
                else if (userInput.Contains("rootkit"))
                {
                    Console.WriteLine("A rootkit is a type of malware designed to gain unauthorized access and hide its presence on a computer system.");
                }
                else if (userInput.Contains("keylogger"))
                {
                    Console.WriteLine("A keylogger is software or hardware that records every keystroke a user types, often used by attackers to steal passwords and other sensitive data.");
                }
                else if (userInput.Contains("sandboxing"))
                {
                    Console.WriteLine("Sandboxing is a cybersecurity practice of running code in a controlled environment to prevent it from affecting the main system.");
                }
                else if (userInput.Contains("insider threat"))
                {
                    Console.WriteLine("An insider threat is a security risk that originates from within the organization, such as a disgruntled employee or contractor.");
                }
                else if (userInput.Contains("ddos") || userInput.Contains("distributed denial of service"))
                {
                    Console.WriteLine("A DDoS (Distributed Denial of Service) attack involves overwhelming a network or website with traffic from multiple sources to make it unavailable.");
                }
                else if (userInput.Contains("cyber hygiene"))
                {
                    Console.WriteLine("Cyber hygiene refers to routine practices and steps users take to maintain system health and improve online security.");
                }
                else if (userInput.Contains("botnet"))
                {
                    Console.WriteLine("A botnet is a network of infected computers controlled by a hacker to perform tasks like sending spam or launching attacks.");
                }
                else if (userInput.Contains("honeypot"))
                {
                    Console.WriteLine("A honeypot is a decoy system used to attract cyber attackers and analyze their behavior without putting real systems at risk.");
                }
                else if (userInput.Contains("privilege escalation"))
                {
                    Console.WriteLine("Privilege escalation is the act of exploiting a bug or design flaw to gain higher access rights than intended.");
                }
                else if (userInput.Contains("cyber attack"))
                {
                    Console.WriteLine("A cyber attack is an attempt by hackers to damage, disrupt, or gain unauthorized access to computer systems, networks, or data.");
                }
                else if (userInput.Contains("cybercrime"))
                {
                    Console.WriteLine("Cybercrime refers to criminal activities carried out using computers or the internet, such as identity theft, fraud, and hacking.");
                }
                else if (userInput.Contains("security breach"))
                {
                    Console.WriteLine("A security breach is an incident where information is accessed without authorization, putting data and systems at risk.");
                }
                else if (userInput.Contains("zero trust"))
                {
                    Console.WriteLine("Zero Trust is a security model that assumes no user or system should be trusted by default, requiring verification at every step.");
                }
                else if (userInput.Contains("penetration test") || userInput.Contains("pen test"))
                {
                    Console.WriteLine("A penetration test is a simulated cyberattack used to evaluate the security of a system by identifying vulnerabilities before attackers can exploit them.");
                }
                else if (userInput.Contains("data breach"))
                {
                    Console.WriteLine("A data breach is when sensitive or confidential data is accessed or disclosed without authorization.");
                }
                else if (userInput.Contains("firewall"))
                {
                    Console.WriteLine("A firewall is a security system that monitors and controls network traffic based on predetermined security rules.");
                }
                else if (userInput.Contains("keylogger"))
                {
                    Console.WriteLine("A keylogger is a malicious program that records keystrokes to steal sensitive information like passwords.");
                }
                else if (userInput.Contains("captcha"))
                {
                    Console.WriteLine("A CAPTCHA is a test used to determine whether a user is human, often used to block bots.");
                }
                else if (userInput.Contains("whaling"))
                {
                    Console.WriteLine("Whaling is a phishing attack that targets high-profile individuals like executives.");
                }
                else if (userInput.Contains("spyware"))
                {
                    Console.WriteLine("Spyware is software that secretly gathers information about a user without their consent.");
                }
                else if (userInput.Contains("brute force"))
                {
                    Console.WriteLine("A brute force attack is when a hacker tries every possible combination to crack a password.");
                }
                else if (userInput.Contains("patch"))
                {
                    Console.WriteLine("A patch is a software update that fixes security vulnerabilities or bugs.");
                }
                else if (userInput.Contains("encryption key"))
                {
                    Console.WriteLine("An encryption key is used to encrypt or decrypt data in a cryptographic system.");
                }
                else if (userInput.Contains("exploit"))
                {
                    Console.WriteLine("An exploit is code that takes advantage of a security vulnerability to cause unintended behavior.");
                }
                else if (userInput.Contains("cyber hygiene"))
                {
                    Console.WriteLine("Cyber hygiene refers to best practices that users follow to stay safe online and protect their systems.");
                }
                else if (userInput.Contains("botnet"))
                {
                    Console.WriteLine("A botnet is a network of infected computers controlled by a hacker to perform cyber attacks.");
                }
                else if (userInput.Contains("adware"))
                {
                    Console.WriteLine("Adware is software that automatically shows or downloads ads when you're online.");
                }
                else if (userInput.Contains("session hijacking"))
                {
                    Console.WriteLine("Session hijacking is when a hacker takes over your web session to gain unauthorized access.");
                }
                else if (userInput.Contains("rat"))
                {
                    Console.WriteLine("A RAT (Remote Access Trojan) gives hackers full control over your computer remotely.");
                }
                else if (userInput.Contains("digital footprint"))
                {
                    Console.WriteLine("A digital footprint is the trail of data you leave behind while using the internet.");
                }
                else if (userInput.Contains("air gap"))
                {
                    Console.WriteLine("An air gap is a security measure that isolates a device or network from external connections.");
                }
                else if (userInput.Contains("fun fact"))
                {
                    DisplayRandomFunFact();
                }

                else
                {
                    Console.WriteLine("I'm sorry, I don't understand that. Type 'help' for a list of topics.");
                }

            }

            static void DisplayRandomFunFact()
            {
                string[] funFacts = new string[]
                {
            "Fun Fact 1: The first computer virus was created in 1986 and was called 'Brain' by two brothers in Pakistan.",
            "Fun Fact 2: '123456' and 'password' are still among the most commonly used passwords!",
            "Fun Fact 3: Cybercrime earns more annually than the global illegal drug trade—over $6 trillion!",
            "Fun Fact 4: In 2020, a hacker tried to poison a Florida water supply remotely but was caught in time.",
            "Fun Fact 5: The term 'hacker' originally meant a skilled programmer or problem-solver in the 1960s.",
            "Fun Fact 6: The longest password ever used in a data breach had 1,904 characters!",
            "Fun Fact 7: Some hackers are hired by companies to test security—these are called white-hat hackers.",
            "Fun Fact 8: CAPTCHA stands for 'Completely Automated Public Turing test to tell Computers and Humans Apart'.",
            "Fun Fact 9: In 2021, over 2200 cyber attacks happened daily—that’s nearly 1 every 39 seconds!",
            "Fun Fact 10: A single phishing email cost Sony Pictures over $100 million in damage.",
            "Fun Fact 11: The largest DDoS attack in history exceeded 2.5 terabits per second in traffic.",
            "Fun Fact 12: Some malware can now detect if it’s running in a virtual environment and deactivate itself.",
            "Fun Fact 13: The word 'cyber' comes from 'cybernetics', a term coined in the 1940s.",
            "Fun Fact 14: In 1999, the Melissa virus caused over $80 million in damage by emailing itself to contacts.",
            "Fun Fact 15: Many hackers use social engineering—tricking people—rather than complex code.",
            "Fun Fact 16: The first webcam was invented to monitor a coffee pot at Cambridge University.",
            "Fun Fact 17: An average data breach takes over 200 days to detect.",
            "Fun Fact 18: One typo in an email address could expose sensitive company data.",
            "Fun Fact 19: Ransomware groups now offer 'customer support' to help victims pay in cryptocurrency!",
            "Fun Fact 20: Cybersecurity is expected to grow into a $10 trillion industry by 2025."
            };

                Random rand = new Random();
                int index = rand.Next(funFacts.Length);
                Console.WriteLine(funFacts[index]);
            }
        }

        private static void SimulateTyping()
            {
                Thread.Sleep(1000); // Simulates typing delay
            }
        }
    }
