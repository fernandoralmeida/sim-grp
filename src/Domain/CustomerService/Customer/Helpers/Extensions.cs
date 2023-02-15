using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Helpers;

public static class Extensions
{

    public static bool IsNumeric(this string valor)
    {
        int i;
        return int.TryParse(valor, out i);
    }
    public static string Mask(this string value, string mask, char substituteChar = '#')
    {
        int valueIndex = 0;
        try
        {
            return new string(mask.Select(maskChar => maskChar == substituteChar ? value[valueIndex++] : maskChar).ToArray());
        }
        catch (IndexOutOfRangeException e)
        {
            throw new Exception("Valor muito curto para substituir todos os caracteres substitutos na máscara", e);
        }
    }

    public static string MaskRemove(this string valor)
    {
        try
        {
            var str = valor;
            str = new string((from c in str
                              where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                              select c
                   ).ToArray());

            return str;
        }
        catch
        {
            return valor;
        }
    }
    public static bool Exist(this ECustomer current, ECustomer nnew)
        => current.Document == nnew.Document ?
        true :
        false;

    internal struct Document
    {
        private readonly string _value;
        public readonly bool _isvalid;
        private Document(string value)
        {
            _value = value;

            if (value == null)
            {
                _isvalid = false;
                return;
            }

            var position = 0;
            var t_digit_1 = 0;
            var t_digit_2 = 0;
            var v_digit_1 = 0;
            var v_digit_2 = 0;
            bool identical_digits = true;
            var last_digit = -1;

            foreach (var c in value)
            {
                if (char.IsDigit(c))
                {

                    var digit = c - '0';

                    if (position != 0 && last_digit != digit)
                    {
                        identical_digits = false;
                    }
                    last_digit = digit;

                    if (position < 9)
                    {
                        t_digit_1 += digit * (10 - position);
                        t_digit_2 += digit * (11 - position);
                    }
                    else if (position == 9)
                    {
                        v_digit_1 = digit;
                    }
                    else if (position == 10)
                    {
                        v_digit_2 = digit;
                    }

                    position++;
                }
            }

            if (position > 11)
            {
                _isvalid = false;
                return;
            }

            if (identical_digits)
            {
                _isvalid = false;
                return;
            }

            var digit_1 = t_digit_1 % 11;

            digit_1 = digit_1 < 2
                ? 0
                : 11 - digit_1;

            if (v_digit_1 != digit_1)
            {
                _isvalid = false;
                return;
            }

            t_digit_2 += digit_1 * 2;
            var digit_2 = t_digit_2 % 11;
            digit_2 = digit_2 < 2
                ? 0
                : 11 - digit_2;

            _isvalid = v_digit_2 == digit_2;
        }

        public static implicit operator Document(string value) => new Document(value);

        public override string ToString() => _value;
    }

    internal static bool Validadte_Document(Document value) => value._isvalid;

    public static bool ValidateDocument(string document)
    {
        if (document.Length != 14)
            return false;

        int[] pesos1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] pesos2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        int soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(document[i].ToString()) * pesos1[i];
        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(document[i].ToString()) * pesos2[i];
        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        return document.EndsWith(digito1.ToString() + digito2.ToString());
    }
}