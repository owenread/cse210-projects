using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

public class Job
{

    // Member Variables
    public string _jobTitle = "";
    public string _company = "";
    public int _startYear;
    public int _endYear;

    // Method
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }


}