namespace _06_Custom_Helpers.Helpers
{
    public static class StringHelpers
    {
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return char.ToUpper(input[0]) + input.Substring(1);//ilk harfi büyült geri kalanı olduğu gibi kalsın
        }
        public static string CapitalizeWord(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            var words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = CapitalizeFirstLetter(words[i]);
            }
            return string.Join(" ", words);
        }
        public static string WordsLength(string input)
        {
            return $"{input} uzunluğu: {input.Length}";
        }
    }
}
