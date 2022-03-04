using System;
using System.Globalization;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(RemoverAcentos("áúóà"));
    }

    public static string RemoverAcentos(string texto)
    {
        texto = texto.ToUpper();

        string textoNormalizado = texto.Normalize(NormalizationForm.FormKD);

        StringBuilder stringBuilder = new StringBuilder();

        for (int k = 0; k < textoNormalizado.Length; k++)
        {
            UnicodeCategory caractereUnicode = CharUnicodeInfo.GetUnicodeCategory(textoNormalizado[k]);

            if (
                caractereUnicode == UnicodeCategory.SpaceSeparator || 
                caractereUnicode == UnicodeCategory.UppercaseLetter || 
                caractereUnicode == UnicodeCategory.DecimalDigitNumber
            )
            {
                stringBuilder.Append(textoNormalizado[k]);
            }
        }

        return stringBuilder.ToString();
    }
}
