using Interface.Businnes;

namespace Businnes
{
    public class CodeValidatorBS : ICodeValidatorBS
    {

        // önce değerler kontrol edilir, ardından 7. ve 8. karakterlerin doğruluğu kontrol edilir.
        public bool ValidateCode(string code)
        {
            if (string.IsNullOrEmpty(code) || code.Length != 8) return false;

            int sumOfOdds = 0, sumOfEvens = 0;

            for (int i = 0; i < 6; i++)
            {
                if (!"ACDEFGHKLMNPRTXYZ234579".Contains(code[i])) return false;

                int numericValue = code[i] % 10;

                if (i % 2 == 0) sumOfOdds += numericValue;
                else sumOfEvens += numericValue;
            }

            int seventhCharNumericValue = ((sumOfOdds * 7) - sumOfEvens) % 10;
            int eighthCharNumericValue = (sumOfOdds + sumOfEvens + seventhCharNumericValue) % 10;

            return code[6] == "ACDEFGHKLMNPRTXYZ234579"[seventhCharNumericValue] && code[7] == "ACDEFGHKLMNPRTXYZ234579"[eighthCharNumericValue];
        }
    }


}