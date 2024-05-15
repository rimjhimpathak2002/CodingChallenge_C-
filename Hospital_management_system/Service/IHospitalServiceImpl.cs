using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management_system.Service
{
    public interface IHospitalServiceImpl
    {
        void GetAppointmentById();
        void GetAppointmentForPatient();
       

        void GetAppointmentsForDoctors();

        void ScheduleAppointment();

        void CancelAppointment();
    }
}
