using System;
using System.Collections.Generic;

namespace MIS.Model
{
    [Serializable]
    public class Patient
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string BirthDate { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string Snils { get; set; }
        public string InsurancePolice { get; set; }
        public string RegistrationAddress { get; set; }
        public string ResidentialAddress { get; set; }
        public string Profession { get; set; }
        public string PhoneNumber { get; set; }
        public List<Inspection> Inspections { get; set; }
        public string LatestInspectionDate { get; set; }

        public Patient(string name, string surname, string patronymic, string birthDate, string passportSeries, string passportNumber, string snils,
            string insurancePolice, string registrationAddress, string residentialAddress, string profession,
            string phoneNumber)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            Snils = snils;
            InsurancePolice = insurancePolice;
            RegistrationAddress = registrationAddress;
            ResidentialAddress = residentialAddress;
            Profession = profession;
            PhoneNumber = phoneNumber;
        }

        public Patient()
        {

        }
    }
}