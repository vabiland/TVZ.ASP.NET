// See https://aka.ms/new-console-template for more information

using System;
using Vjezba.Model;

Console.WriteLine("Hello, World!");
Osoba osoba = new Osoba();
osoba.SetOIB(12345678901);
Console.WriteLine($"Osoba ima OIB {osoba.GetOIB()}");

int i = 0;
while (i < 2)
{
    try
    {
        if (i < 1)
            osoba.JMBG = 12128945612355;
        osoba.JMBG = 1312089561235;
        i++;
        // pokusaj = false;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        i++;
        // throw;
    }
}

Console.WriteLine($"Osoba ima JMBG {osoba.JMBG}");
Console.WriteLine($"Osoba je rođena {osoba.DatumRodjenja.ToString("dd.MM.yyyy.")}");

Student student1 = new Student();
student1.Ime = "Ivo";
student1.Prezime = "Gregurević";
student1.JMBAG = 1472583695;

Fakultet faks = new Fakultet();
faks.insertOsoba(student1);

Student dohvaceniStudent = faks.DohvatiStudenta(student1.JMBAG);

Console.WriteLine($"Ime i prezime dohvaćenog studenta {dohvaceniStudent.Ime} {dohvaceniStudent.Prezime}");
Profesor p = new Profesor();


