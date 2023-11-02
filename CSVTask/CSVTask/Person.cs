

namespace CSVTask
{
    public class Person : IComparable<Person>
    {
        private enum Gender
        {
            Male,
            Female,
            Other
        }
        private string firstname;
        private string surname;
        private string email;
        private Gender gender;
        private string IP;
        public Person()
        {
            // Default Constructor for the person object
            this.firstname = "Unknown";
            this.surname = "Unknown";
            this.email = "Unknown";
            this.gender = Gender.Other;
            this.IP = "0.0.0.0";
        }
        public Person(string firstname, string surname)
        {
            this.firstname = firstname;
            this.surname = surname;
            this.email = "Unknown";
            this.gender = Gender.Other;
            this.IP = "0.0.0.0";
        }
        public Person(string firstname, string surname, string gender)
        {
            this.firstname = firstname;
            this.surname = surname;
            this.email = "Unknown";
            this.gender = ParseGender(gender);
            this.IP = "0.0.0.0";
        }
        public Person(string firstname, string surname, string email, string gender, string IP)
        {
            this.firstname = firstname;
            this.surname = surname;
            this.email = email;
            this.gender = ParseGender(gender);
            this.IP = IP;
        }
        private Gender ParseGender(string gender)
        {
            switch (gender.ToLower())
            {
                case "male":
                    return Gender.Male;
                case "female":
                    return Gender.Female;
                default:
                    return Gender.Other;
            }
        }
        public int CompareTo(Person other)
        {
            return surname.CompareTo(other.surname);
        }

        public override string ToString()
        {
            return $"{this.firstname},{this.surname},{this.email},{this.gender},{this.IP}";
        }
    }
}
