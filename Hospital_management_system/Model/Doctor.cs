using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management_system.Model
{
    public class Doctor
    {
        // Private attributes
        private int doctorId;
        private string firstName;
        private string lastName;
        private string specialization;
        private string contactNumber;

        // Default constructor
        public Doctor() { }

        // Parameterized constructor
        public Doctor(int doctorId, string firstName, string lastName, string specialization, string contactNumber)
        {
            this.doctorId = doctorId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.specialization = specialization;
            this.contactNumber = contactNumber;
        }

        // Getters and setters
        public int DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        // ToString() method
        public override string ToString()
        {
            return $"DoctorId: {doctorId}, FirstName: {firstName}, LastName: {lastName}, Specialization: {specialization}, ContactNumber: {contactNumber}";
        }
    }
}
