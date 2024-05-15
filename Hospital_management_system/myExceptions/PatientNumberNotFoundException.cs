using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management_system.myExceptions
{
    public class PatientNumberNotFoundException : Exception
    {
        public PatientNumberNotFoundException()
        {

        }

        public PatientNumberNotFoundException(string message)
            : base(message)
        {

        }
        public PatientNumberNotFoundException(int patientId)
        : base($"Patient with ID {patientId} not found in the database.")
        {

        }

    }
}
