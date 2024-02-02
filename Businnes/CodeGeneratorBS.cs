
using Interface.Businnes;

namespace Businnes
{

    public class CodeGeneratorBS: ICodeGeneratorBS
    {
        private const string Characters = "ACDEFGHKLMNPRTXYZ234579";
        private Random random = new Random();

        //TC Kimlik numarasındki mantık gibi ilk 6 hane random 7. Hane  ve 8. Hane ise kontrol haneleri olacakt şekil tasarlandı.
        public string GenerateCode()
        {
            var codeChars = new char[8];
            int sumOfOdds = 0, sumOfEvens = 0;

            for (int i = 0; i < 6; i++)
            {
                codeChars[i] = Characters[random.Next(Characters.Length)];
                int numericValue = codeChars[i] % 10; // ASCII değ. bağlı sayi.

                if (i % 2 == 0) sumOfOdds += numericValue; 
                else sumOfEvens += numericValue;
            }

            // 7. karakter
            int seventhCharNumericValue = ((sumOfOdds * 7) - sumOfEvens) % 10;
            codeChars[6] = Characters[seventhCharNumericValue];

            // 8. karakter
            int eighthCharNumericValue = (sumOfOdds + sumOfEvens + seventhCharNumericValue) % 10;
            codeChars[7] = Characters[eighthCharNumericValue];

            return new string(codeChars);
        }
    }

}