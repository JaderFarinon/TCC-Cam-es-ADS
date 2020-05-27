using System.Text.RegularExpressions;

namespace inst_global_saude.Classes
{
    class Utilities
    {
        public static bool IsValidEmail(string cpf)
        {
            return Regex.Match(cpf, @"[0-9]{ 3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}").Success;
        }
    }
}
