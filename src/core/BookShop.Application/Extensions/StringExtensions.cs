﻿using System.Text.RegularExpressions;
using System.Text;

namespace BookShop.Application.Extensions;

public static class StringExtensions
{
    public static string CharacterRegulatory(this string name, int maxLenght = 30)
    {
        int i = name.IndexOfAny(new char[] { 'ş', 'ç', 'ö', 'ğ', 'ü', 'ı', 'ə' });
        string newName = name.ToLower().Trim();
        if (i > -1)
        {
            StringBuilder outPut = new(newName);
            outPut.Replace('ö', 'o');
            outPut.Replace('ç', 'c');
            outPut.Replace('ş', 's');
            outPut.Replace('ı', 'i');
            outPut.Replace('ğ', 'g');
            outPut.Replace('ü', 'u');
            outPut.Replace('ə', 'e');
            newName = outPut.ToString();
        }
        newName = Regex.Replace(newName, @"[^a-z0-9\s-]", String.Empty);
        newName = Regex.Replace(newName, @"[\s-]+", "-").Trim();
        newName = newName[..(newName.Length <= maxLenght ? newName.Length : maxLenght)].Trim();
        newName = Regex.Replace(newName, @"\s", "-");
        return newName.ToLower();
    }
}
