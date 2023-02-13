using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Helpers;

public static class Extensions
{

    public static bool Exist(this ECustomer current, ECustomer nnew)
        => current.Document == nnew.Document ?
        true :
        false;

    public static (bool value, string message) Validate(this ECustomer p)
    {
        if (Validadte_Document(p.Document!))
        {
            if (Convert.ToDateTime(p.BirthDate) > DateTime.Now.AddYears(-16) &&
                Convert.ToDateTime(p.BirthDate) < DateTime.Now.AddDays(-130))
                return (true, "ok");
            else
                return (false, "invalid date");
        }
        else
            return (false, "invalid document");
    }

    private struct Document
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

    private static bool Validadte_Document(Document value) => value._isvalid;
}