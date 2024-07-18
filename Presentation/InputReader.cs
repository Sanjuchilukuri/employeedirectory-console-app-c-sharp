using Presentation.Error;
using Application.Validations;

namespace Presentation.UserInputManagement
{
    public static class InputReader
    {
        public static int GetOption(int count)
        {
            while (true)
            {
                string userInput = Console.ReadLine()!.Trim();
                if (InputValidation.IsValidOption(count, userInput))
                {
                    return Convert.ToInt32(userInput);
                }
                else
                {
                    ErrorMessage.InvalidOption();
                }
            }
        }

        public static string? GetDate(string inputType)
        {
            while (true)
            {
                string userInput = Console.ReadLine()!.Trim();
                if (inputType == "Mandatory" && userInput == "")
                {
                    ErrorMessage.MandatoryInput();
                    continue;
                }
                if (InputValidation.IsValidDate(inputType, userInput))
                {
                    return userInput;
                }
                else
                {
                    ErrorMessage.InvalidInput("Date");
                }
            }
        }

        public static string GetEmpID()
        {
            while (true)
            {
                string userInput = Console.ReadLine()!.Trim();
                if (InputValidation.IsValidEmpID(userInput))
                {
                    return userInput;
                }
                else
                {
                    ErrorMessage.InvalidInput("EmpID");
                }
            }
        }

        public static string? GetMail()
        {
            while (true)
            {
                string userInput = Console.ReadLine()!.Trim();
                if (userInput == "")
                {
                    ErrorMessage.MandatoryInput();
                    continue;
                }
                if (InputValidation.IsValidMail(userInput))
                {
                    return userInput;
                }
                else
                {
                    ErrorMessage.InvalidInput("Mail");
                }
            }
        }

        public static string? GetName(string inputType)
        {
            while (true)
            {
                string userInput = Console.ReadLine()!.Trim();
                if (inputType == "Mandatory" && userInput == "")
                {
                    ErrorMessage.MandatoryInput();
                    continue;
                }
                if (InputValidation.IsValidName(inputType, userInput))
                {
                    return userInput;
                }
                else
                {
                    ErrorMessage.InvalidInput("Name");
                }
            }
        }

        public static string? GetPhno()
        {
            while (true)
            {
                string userInput = Console.ReadLine()!.Trim();
                if (InputValidation.IsValidPhno(userInput))
                {
                    return userInput;
                }
                else
                {
                    ErrorMessage.InvalidInput("Phone Number");
                }
            }
        }

        public static int GetEditEmployeeInput(int maxRange)
        {
            while (true)
            {
                string userInput = Console.ReadLine()!.Trim();
                if (InputValidation.IsValidOption(maxRange, userInput))
                {
                    return Convert.ToInt32(userInput);
                }
                else
                {
                    ErrorMessage.InvalidInput();
                }
            }
        }

        public static char GetCharInput()
        {
            while (true)
            {
                string userInput = Console.ReadLine()!.Trim();
                if (InputValidation.IsValidYesNoInput(userInput))
                {
                    return Convert.ToChar(userInput);
                }
                else
                {
                    ErrorMessage.InvalidInput();
                }
            }
        }
    }
}
