using System;
using System.Collections.Generic;

namespace Vjezba.Model;

public class Profesor : Osoba
{
    public string Odjel { get; set; }
    public Zvanje Zvanje { get; set; }
    public DateTime DatumIzbora { get; set; }
    public List<Predmet> Predmeti { get; set; }

    public Profesor()
    {
        Predmeti = new List<Predmet>();
    }
    public int KolikoDoReizbora()
    {
        
        if (Zvanje == Zvanje.Asistent)
        {
            DateTime datumReizbora = DatumIzbora.AddYears(4);
            return (datumReizbora - DateTime.Now).Days / 365;
        }
        else
        {
            DateTime datumReizbora = DatumIzbora.AddYears(5);
            return (datumReizbora - DateTime.Now).Days / 365;
        }
    }
}

public enum Zvanje
{
    Asistent, Predavac, VisiPredavac, ProfVisokeSkole
    
}