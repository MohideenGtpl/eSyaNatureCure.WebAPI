using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
    public interface IClinicalVitalsRepository
    {
        Task<List<DO_ClinicalInformation>> GetClinicalInformation(int businessKey, long UHID, long ipNumber, string clType);
        Task<DO_ReturnParameter> InsertIntoClinicalInformation(DO_ClinicalInformation obj);
        Task<List<DO_ClinicalInformation>> GetInformationValueView(int businessKey, long UHID, long ipNumber, string clType);
        Task<DO_ReturnParameter> InsertPatientClinicalInformation(DO_ClinicalInformation obj);
        Task<DO_ReturnParameter> UpdatePatientClinicalInformation(DO_ClinicalInformation obj);
        Task<List<DO_ClinicalInformation>> GetClinicalInformationValueByTransaction(int businessKey, long UHID, long ipNumber, int transactionID);
        Task<DO_ReturnParameter> DeletePatientClinicalInformation(DO_ClinicalInformation obj);
    }
}
