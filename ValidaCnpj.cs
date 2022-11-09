namespace Validador
{
  internal class ValidaCnpj
  {
    public static bool ValidadorCnpj(string Cnpj)
    {
      Cnpj = Cnpj.Trim();
      Cnpj = Cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

      if (Cnpj.Length != 14) //Verificando o Tamanho do CNPJ
        return false;

      for (int i = 0; i <= 13; i++) //Verificando se todos os Números são Inteiros
      {
        if (!char.IsDigit(Cnpj[i]))
          return false;
      }

      for (int i = 0; i < 13; i++) //Verificando se são Números Repetidos
      {
        string StringRepetido = string.Concat(Enumerable.Repeat(i.ToString(), 14));

        if (Cnpj == StringRepetido)
          return false;
      }

      #region "Verificação do Décimo Terceiro Dígito"
      int[] MultiplicadorInicial = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
      string CnpjTemp = Cnpj.Substring(0, 12);
      int Soma = 0;

      for (int i = 0; i < 12; i++)
        Soma += int.Parse(CnpjTemp[i].ToString()) * MultiplicadorInicial[i];

      int Resto;

      Resto = Soma % 11;

      if (Resto < 2)
        Resto = 0;
      else
        Resto = 11 - Resto;

      if (Resto.ToString() != Cnpj[12].ToString())
        return false;
      #endregion

      #region "Verificação do Último Dígito"
      int[] SegundoMultiplicador = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
      CnpjTemp = Cnpj.Substring(0, 13);
      Soma = 0;
      Resto = 0;

      for (int i = 0; i < 13; i++)
        Soma += int.Parse(CnpjTemp[i].ToString()) * SegundoMultiplicador[i];

      Resto = Soma % 11;

      if (Resto < 2)
        Resto = 0;
      else
        Resto = 11 - Resto;

      if (Resto.ToString() != Cnpj[13].ToString())
        return false;
      #endregion

      return true;
    }
  }
}
