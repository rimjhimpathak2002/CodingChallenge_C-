using Hospital_management_system.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management_system.mainmod
{
    public class MainMethod
    {
        IHospitalServiceImpl hospital;
        public MainMethod()
        {
            hospital = new HospitalServiceImpl();
        }
        
        public void app()
        {
            //Console.WriteLine("This Function is GetAppointmentbyID");
            // hospital.GetAppointmentById();// --working
            //Console.WriteLine("This Function is ScheduleAppointmentt");
            //hospital.ScheduleAppointment(); //--Giving Error 
            //Console.WriteLine("This Function is GetAppointmentForPatient");
              hospital.GetAppointmentForPatient(); //--working
            //Console.WriteLine("This Function is GetAppointmentforDoctors");
            //  hospital.GetAppointmentsForDoctors(); //--working
            //Console.WriteLine("This Function is CancelAppointment");
            //   hospital.CancelAppointment(); //--working
        }
    }
}
