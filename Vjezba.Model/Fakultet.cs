using System;
using System.Collections.Generic;
using System.Linq;


namespace Vjezba.Model;

public class Fakultet
{
    private Osoba _osoba;
    public List<Osoba> ListOsoba { get; set; }


    public Fakultet()
    {
        ListOsoba = new List<Osoba>();
    }

    public void insertOsoba(Osoba value)
    {
        if (value is Osoba && value != null)
            ListOsoba.Add(value);
    }

    public int KolikoProfesora()
    {
        int brjkaProfesora = 0;
        foreach (var osoba in ListOsoba)
        {
            if (osoba is Profesor)
            {
                brjkaProfesora++;
            }
        }
        return brjkaProfesora;
    }

    public int KolikoStudenata()
    {
        int brojkaStudenata = 0;
        foreach (var osoba in ListOsoba)
        {
            if (osoba is Student)
            {
                brojkaStudenata++;
            }
        }
        return brojkaStudenata;
    }

    public Student DohvatiStudenta(string JMBAG)
    {
        foreach (var osoba in ListOsoba)
        {
            if (osoba is Student student)
            {
                if (JMBAG == student.JMBAG)
                    return student;
            }
        }
        return null;
    }

    public IEnumerable<Profesor> DohvatiProfesore()
    {
        return ListOsoba
                 .Where(a => a is Profesor)
                 // .Cast<Profesor>()
                 .OfType<Profesor>()
                 .OrderBy(prof => prof.DatumIzbora);

        // .ToList();
        // List<Profesor> profesorList = new List<Profesor>();
        // foreach (var osoba in ListOsoba)
        // {
        //     if (osoba is Profesor profesor)
        //     {
        //         // if (student.JMBAG.Equals(JMBAG))
        //         //     return student;
        //         profesorList.Add(profesor);
        //     }
        // }
        // profesorList.Sort((a, b) => b.DatumIzbora.CompareTo(a.DatumIzbora));
        // return profesorList;
    }

    public IEnumerable<Student> DohvatiStudente91()
    {
        return ListOsoba
            .Where(a => a.DatumRodjenja.Year > 1991)
            .OfType<Student>();
        // .ToList();
    }

    public IEnumerable<Student> DohvatiStudente91NoLinq()
    {
        List<Student> studentList = new List<Student>();
        foreach (var osoba in ListOsoba)
        {
            if (osoba is Student student && student.DatumRodjenja.Year > 1991)
                studentList.Add(student);
        }

        return studentList;
    }

    public IEnumerable<Student> StudentiNeTvzD()
    {
        return ListOsoba
            .OfType<Student>()
            // .Where(a => (a.JMBAG / 1000000 != 0246) && a.Prezime.Substring(0,1).Equals("D")) 
            .Where(a => (long.Parse(a.JMBAG) / 1000000 != 0246))
            .Where(a => a.Prezime.FirstOrDefault().Equals('D'));
        // .ToList();
    }

    public List<Student> DohvatiStudente91List()
    {
        return ListOsoba
            .Where(a => a.DatumRodjenja.Year > 1991)
            .OfType<Student>()
            .ToList();
    }

    public Student NajboljiProsjek(int god)
    {
        return ListOsoba
            .OfType<Student>()
            .Where(a => a.DatumRodjenja.Year == god)
            .OrderByDescending(a => a.Prosjek)
            .FirstOrDefault();
    }

    public IEnumerable<Student> StudentiGodinaOrdered(int god)
    {
        return ListOsoba
            .OfType<Student>()
            .Where(a => a.DatumRodjenja.Year == god)
            .OrderByDescending(a => a.Prosjek);
    }

    public IEnumerable<Profesor> SviProfesori(bool v)
    {
        return ListOsoba
            .OfType<Profesor>()
            .OrderBy(a => a.Prezime)
            .ThenBy(a => a.Ime);
    }

    public int KolikoProfesoraUZvanju(Zvanje zvanje)
    {
        return ListOsoba
            .OfType<Profesor>()
            .Where(a => a.Zvanje == zvanje)
            .Count();
    }

    public IEnumerable<Profesor> NeaktivniProfesori(int x)
    {
        return ListOsoba
            .OfType<Profesor>()
            .Where(a => a.Predmeti.Count < x);
    }

    public IEnumerable<Profesor> AktivniAsistenti(int x, int minEcts)
    {
        return ListOsoba
            .OfType<Profesor>()
            .Where(a => a.Zvanje == Zvanje.Asistent)
            .Where(a => a.Predmeti.Any(a => a.ECTS > minEcts))
            .Where(a => a.Predmeti.Count > x);
    }

    public void IzmjeniProfesore(Action<Profesor> action)
    {
        ListOsoba.OfType<Profesor>()
               .ToList()
               .ForEach(action);
    }
}