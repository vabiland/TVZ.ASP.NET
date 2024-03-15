using System;

namespace Vjezba.Model;

public class Student : Osoba
{
    private string _jmbag;

    public string JMBAG
    {
        get => _jmbag;
        set
        {
            try
            {
                long valueToLong = long.Parse(value);
                if (valueToLong > 10000000 && valueToLong < 10000000000)
                    _jmbag = valueToLong.ToString("D10");
                else throw new InvalidOperationException("JMBAG sadrži isključivo 10 znamenaka");
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("JMBAG sadrži isključivo znamenake");
            }
        }
    }
    public decimal Prosjek { get; set; }
    public int BrPolozeno { get; set; }
    public int ECTS { get; set; }
    
}