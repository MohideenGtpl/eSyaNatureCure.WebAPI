using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
    public interface IServiceRateRepository
    {
        Task<List<DO_ServiceRates>> GetServiceList(int businessKey);
        Task<DO_ServiceRates> GetServiceRates(int businessKey, int serviceId, int rateType, string currencyCode);
    }
}
