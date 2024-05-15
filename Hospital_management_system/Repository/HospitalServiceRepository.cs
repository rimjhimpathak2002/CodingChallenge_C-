using Hospital_management_system.Model;
using Student_Information_System.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management_system.Repository
{
    public class HospitalServiceRepository : IHospitalServiceRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public HospitalServiceRepository()
        {
            sqlConnection = new SqlConnection("Server=DESKTOP-2LFUD90;Database=HMS;Trusted_Connection=True");
            cmd = new SqlCommand();

        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            Appointment appointment = new Appointment();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT appointmentId, patientId, doctorId, appointmentDate, Description FROM Appointment WHERE appointmentId = @appointmentId";
            cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                appointment.AppointmentId = (int)reader["appointmentId"];
                appointment.PatientId = (int)reader["patientId"];
                appointment.DoctorId = (int)reader["doctorId"];
                appointment.AppointmentDate = (DateTime)reader["appointmentDate"];
                appointment.Description = reader["description"] as string;
            }
            sqlConnection.Close();
            return appointment;
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT appointmentId, patientId, doctorId, appointmentDate, description FROM Appointment WHERE patient_id = @patientId";
            cmd.Parameters.AddWithValue("@patientId", patientId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Appointment appointment = new Appointment
                {
                    AppointmentId = (int)reader["appointmentId"],
                    PatientId = (int)reader["patientId"],
                    DoctorId = (int)reader["doctorId"],
                    AppointmentDate = (DateTime)reader["appointmentDate"],
                    Description = reader["Description"] as string
                };
                appointments.Add(appointment);
            }
            sqlConnection.Close();
            return appointments;
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT appointmentId, patientId, doctorId, appointmentDate, description FROM Appointment WHERE doctorId = @doctorId";
            cmd.Parameters.AddWithValue("@doctorId", doctorId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Appointment appointment = new Appointment
                {
                    AppointmentId = (int)reader["appointmentId"],
                    PatientId = (int)reader["patientId"],
                    DoctorId = (int)reader["doctorId"],
                    AppointmentDate = (DateTime)reader["appointmentDate"],
                    Description = reader["description"] as string
                };
                appointments.Add(appointment);
            }
            sqlConnection.Close();
            return appointments;
        }

        
        public bool ScheduleAppointment(Appointment appointment)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.CommandText = "INSERT INTO Appointment (patientId, doctorId, appointmentDate, description) VALUES (@patientId, @doctorId, @appointmentDate, @description)";
            cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
            cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
            cmd.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@description", appointment.Description);

            
            // int rowsAffected = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return cmd.ExecuteNonQuery() > 0;
            
        }


        public bool UpdateAppointment(Appointment appointment)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Appointment SET patientId = @patientId, doctorId = @doctorId, appointmentDate = @appointmentDate, description = @description WHERE appointment_id = @appointmentId";
            cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
            cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
            cmd.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate);
            cmd.Parameters.AddWithValue("@description", appointment.Description);
            cmd.Parameters.AddWithValue("@appointmentId", appointment.AppointmentId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected > 0;
        }

        public bool CancelAppointment(int appointmentId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Appointment WHERE appointmentId = @appointmentId";
            cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected > 0;
        }
    }
}
