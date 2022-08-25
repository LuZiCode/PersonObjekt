using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace PersonObjekt
{
    public class CreatePerson
    {
        private readonly PersonDTO? _personDTO;
        public string? name;
        public DateTime dob;
        public int age;
        public string? email;
        public string? password;
        public bool Continue = false;

        public CreatePerson()
        {
            while (Continue == false)
            {
                Console.Clear();
                Console.Write("Indtast navn: ");
                name = Console.ReadLine();
                Console.Write("Indtast fødselsdag: ");
                dob = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Indtast email: ");
                email = Console.ReadLine();
                Console.Write("Indtast adgangskode: ");
                password = Console.ReadLine();


                _personDTO = new PersonDTO()
                {
                    Name = name,
                    Email = email,
                    Password = password
                };

                var f = new ClassLibrary.CheckRequirements(_personDTO);
                var d = f.CheckListings();

                if (d != "")
                {
                    Console.WriteLine("\nFEJLMEDDELSE!!\n" + d + "\nTryk på en knap for at prøve igen");
                    Console.ReadKey(true);
                }
                else
                {
                    CalculateAge();

                    Continue = true;
                    Console.Clear();
                    Console.WriteLine("Person oprettet" + "\n" +"\nNavn: " + name + "\nFødselsdato: " + dob.Date +  "\nAlder: " + age + "\nEmail: " + email + "\nAdgangskode: " + password);
                }
            }
        }

        private void CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (today < new DateTime(today.Year, dob.Month, dob.Day)) age--;
            this.age = age;
        }
    }
}
