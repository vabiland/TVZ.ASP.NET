using System;

namespace Vjezba.Model;

public class Osoba
{
    private string _oib;
    private string _jmbg;
    public string Ime { get; set; }
    public string Prezime { get; set; }

    // public long GetOIB() => _oib;
    //
    // public void SetOIB(long value)
    // {
    //     if (value > 1000000000 && value < 100000000000)
    //         _oib = value;
    //     else throw new InvalidOperationException("OIB sadrži isključivo 11 znamenaka");
    // }
    public string OIB
    {
        get => _oib;
        set
        {
            if (value.Length != 11)
                throw new InvalidOperationException("JMBAG sadrži isključivo 10 znamenaka");
            long valueToLong;
            try
            {
                valueToLong = long.Parse(value);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("OIB sadrži isključivo znamenke");
            }

            if (valueToLong < 1000000000 || valueToLong > 100000000000)
                throw new InvalidOperationException("OIB sadrži isključivo 11 znamenaka");
            _oib = valueToLong.ToString("D11");
        }
    }

    public string JMBG
    {
        get => _jmbg;
        set
        {
            if (value.Length != 13)
                throw new InvalidOperationException("JMBG sadrži isključivo 13 znamenaka");
            try
            {
                long valueToLong = long.Parse(value);
                if (valueToLong < 100000000000 || valueToLong > 10000000000000)
                    throw new InvalidOperationException("JMBG sadrži isključivo 13 znamenaka");
                _jmbg = valueToLong.ToString("D13");
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("JMBG sadrži isključivo znamenke");
            }
        }
    }

    public DateTime DatumRodjenja
    {
        get
        {
            long longDate = long.Parse(JMBG) / 1000000;
            string dateString = longDate.ToString("D7");
            DateTime dateTime = DateTime.ParseExact(dateString, "ddMMyyy", null);
            int added = 1000;
            if (dateTime.Year < 500)
                return dateTime.AddYears(2 * added);
            else
                return dateTime.AddYears(added);
        }
        set => throw new NotImplementedException();
    }
}