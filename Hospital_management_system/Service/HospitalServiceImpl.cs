using Hospital_management_system.Model;
using Hospital_management_system.myExceptions;
using Hospital_management_system.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management_system.Service
{
    public class HospitalServiceImpl : IHospitalServiceImpl
    {
        readonly IHospitalServiceRepository hospitalrepository;

        public HospitalServiceImpl()
        {
            hospitalrepository = new HospitalServiceRepository();
        }

        public void GetAppointmentById()
        {
            Appointment appointment = new Appointment();
      
            Console.WriteLine("------------- Welcome To Appointment Department -----------------");
            Console.WriteLine("---------------- Enter below details ----------------");
            Console.WriteLine("Appointment Id");
            appointment.AppointmentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(hospitalrepository.GetAppointmentById(appointment.AppointmentId));
        }

        // Function to check Whether Patient Id Exists in DB or Not
        //public bool DoesPatientExist(int patientId)
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection("LocalConnectionString"))
        //    {
        //        string query = "SELECT COUNT(1) FROM Patient WHERE patientId = @patientId";
        //        using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
        //        {
        //            cmd.Parameters.AddWithValue("@patientId", patientId);
        //            sqlConnection.Open();
        //            int count = (int)cmd.ExecuteScalar();
        //            return count > 0;
        //        }
        //    }
        //}
        public void GetAppointmentForPatient()
        {
            try
            {
                Appointment appointment = new Appointment();
                Console.WriteLine("---------------------- Welcome To Appointment Department ------------------------------- ");
                Console.WriteLine(" -------------------- Fill below details of Patient--------------------------- ");
                // Input patient ID
                Console.WriteLine("Enter Patient ID:");
                int patientId = Convert.ToInt32(Console.ReadLine());
                

                List<Appointment> patientAppointments = hospitalrepository.GetAppointmentsForDoctor(patientId);

                // Display appointments
                Console.WriteLine("Appointments for Patients:");
                foreach (Appointment item in patientAppointments)
                {
                    Console.WriteLine(item);
                }
            }
            catch(PatientNumberNotFoundException ex )
            {
                Console.WriteLine(ex.Message);
            }
      

        }

        public void GetAppointmentsForDoctors() 
        {
            Appointment appointment = new Appointment();
            Console.WriteLine("---------------------- Welcome To Appointment Department ------------------------------- ");
            Console.WriteLine(" -------------------- Fill below details of Doctor--------------------------- ");
            // Input doctor ID
            Console.WriteLine("Enter doctor ID:");
            int doctorId = Convert.ToInt32(Console.ReadLine());

            // Get appointments for the doctor
            List<Appointment> doctorAppointments = hospitalrepository.GetAppointmentsForDoctor(doctorId);

            // Display appointments
            Console.WriteLine("Appointments for Doctor:");
            foreach (Appointment item in doctorAppointments)
            {
                Console.WriteLine(item);
            }
        }

        public void ScheduleAppointment()
        {
            // Input appointment details
            Console.WriteLine("Enter patient ID:");
            int patientId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter doctor ID:");
            int doctorId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter appointment date (yyyy-MM-dd): (HH:mm:ss)");
            DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter description:");
            string description = Convert.ToString(Console.ReadLine());

            // Create an appointment object
            Appointment appointment = new Appointment();

            // Schedule the appointment
            bool isScheduled = hospitalrepository.ScheduleAppointment(appointment);

            // Display result
            if (isScheduled)
            {
                Console.WriteLine("Appointment successfully scheduled.");
            }
            else
            {
                Console.WriteLine("Failed to schedule the appointment.");
            }
        }  

        public void CancelAppointment()
        {
            // Input appointment ID to cancel
            Console.WriteLine("Enter appointment ID to cancel:");
            int appointmentId = Convert.ToInt32(Console.ReadLine());

            // Cancel the appointment
            bool isCancelled = hospitalrepository.CancelAppointment(appointmentId);

            // Display result
            if (isCancelled)
            {
                Console.WriteLine("Appointment successfully cancelled.");
            }
            else
            {
                Console.WriteLine("Failed to cancel the appointment. Appointment ID may not exist.");
            }
        }
    }
}
