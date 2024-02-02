using Interface.Businnes;

class ConsoleManager
{
    private readonly ICodeGeneratorBS codeGenerator;
    private readonly ICodeValidatorBS codeValidator;

    public ConsoleManager(ICodeGeneratorBS codeGen, ICodeValidatorBS codeVal)
    {
        codeGenerator = codeGen;
        codeValidator = codeVal;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("1- Kod Üret");
            Console.WriteLine("2- Kodu Doğrula");
            Console.WriteLine("3- Ekranı temizle");
            Console.WriteLine("0- Çıkış");
            Console.Write("Seçiminizi yapınız: ");


            var choice = Console.ReadLine();

            Console.WriteLine("\n");

            switch (choice)
            {
                case "1":
                    GenerateCode();
                    Console.WriteLine("\n");
                    break;
                case "2":
                    ValidateCode();
                    Console.WriteLine("\n");
                    break;
                case "3":
                    Console.Clear();
                    break;
                case "0":
                    Console.WriteLine("Çıkış yapılıyor...");
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }

            

        }
    }

    private void GenerateCode()
    {
        var code = codeGenerator.GenerateCode();
        Console.WriteLine($"Üretilen kod: {code}");
    }

    private void ValidateCode()
    {
        Console.Write("Doğrulanacak kodu giriniz: ");
        var code = Console.ReadLine();
        var isValid = codeValidator.ValidateCode(code);
        if (isValid)
        {
            Console.WriteLine("Kod geçerli.");
        }
        else
        {
            Console.WriteLine("Kod geçersiz.");
        }
    }
}