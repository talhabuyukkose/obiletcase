using System.Diagnostics;

namespace Obilet.Core.Extensions;

/// <summary>
/// This class preapare language
/// </summary>
public sealed class Language
{
    private const string Tr = "tr-TR";
    private const string En = "en-En";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ipCountry"></param>
    /// <returns>Return language value type of string</returns>
    public static string Get(string ipCountry)
    {
        return ipCountry switch
        {
            "TR" => Tr,
            "EN" => En,
            _ => Tr
        };
    }
}