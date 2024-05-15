using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management_system.Model
{
    public class Appointment
    {
        // Private attributes
        private int appointmentId;
        private int patientId;
        private int doctorId;
        private DateTime appointmentDate;
        private string description;

        // Default constructor
        public Appointment() { }

        // Parameterized constructor
        public Appointment(int appointmentId, int patientId, int doctorId, DateTime appointmentDate, string description)
        {
            this.appointmentId = appointmentId;
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.appointmentDate = appointmentDate;
            this.description = description;
        }

        // Getters and setters
        public int AppointmentId
        {
            get { return appointmentId; }
            set { appointmentId = value; }
        }

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public int DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
        }

        public DateTime AppointmentDate
        {
            get { return appointmentDate; }
            set { appointmentDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // ToString() method
        public override string ToString()
        {
            return $"AppointmentId: {appointmentId}, PatientId: {patientId}, DoctorId: {doctorId}, AppointmentDate: {appointmentDate}, Description: {description}";
        }
    }
}
