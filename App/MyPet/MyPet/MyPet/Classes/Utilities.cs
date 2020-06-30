using System.Text.RegularExpressions;

namespace MyPet.Classes
{
    class Utilities
    {
        public static bool cpfValido(string cpf)
        {
            return Regex.Match(cpf, @"[0-9]{ 3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}").Success;
        }
    }
}
