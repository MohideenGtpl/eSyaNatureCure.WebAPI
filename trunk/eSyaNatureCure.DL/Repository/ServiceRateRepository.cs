using eSyaNatureCure.DL.Entities;
using eSyaNatureCure.DO;
using eSyaNatureCure.IF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.DL.Repository
{
    public class ServiceRateRepository: IServiceRateRepository
    {
        public async Task<List<DO_ServiceRates>> GetServiceList(int businessKey)
        {
            using (var db = new eSyaEnterprise())
            {
                var sr = await db.GtEssrms
                    .Join(db.GtEssrbl,
                        s => new { s.ServiceId },
                        b => new { b.ServiceId },
                        (s, b) => new { s, b })
                    .Join(db.GtEssrcl,
                        sb => new { sb.s.ServiceClassId },
                        c => new { c.ServiceClassId },
                        (sb, c) => new { sb, c })
                   .Join(db.GtEssrgr,
                        sbc => new { sbc.c.ServiceGroupId },
                        g => new { g.ServiceGroupId },
                        (sbc, g) => new { sbc, g })
                    .Where(w => w.sbc.sb.b.BusinessKey == businessKey 
                            && w.sbc.sb.s.ActiveStatus && w.sbc.sb.b.ActiveStatus 
                            && w.sbc.c.ActiveStatus && w.g.ActiveStatus)
                    .Select(r => new DO_ServiceRates
                    {
                        ServiceTypeId = r.g.ServiceTypeId,
                        ServiceId = r.sbc.sb.s.ServiceId,
                        ServiceDesc = r.sbc.sb.s.ServiceDesc
                    })
                    .ToListAsync();

                return sr;
            }
        }

        public async Task<DO_ServiceRates> GetServiceRates(int businessKey, int serviceId, int rateType, string currencyCode)
        {
            using (var db = new eSyaEnterprise())
            {
                var sr = await db.GtEssrms
                    .Join(db.GtEssrbl,
                        s => new { s.ServiceId },
                        b => new { b.ServiceId },
                        (s, b) => new { s, b })
                    .Join(db.GtEssrbr
                        .Where(w=>w.RateType == rateType && w.CurrencyCode == currencyCode 
                            && w.ActiveStatus 
                           // && w.EffectiveDate.Date >= System.DateTime.Now.Date 
                            && DateTime.Now.Date <= (w.EffectiveTill == null ? DateTime.Now.Date : w.EffectiveTill.Value.Date)),
                        sb => new { sb.b.BusinessKey, sb.b.ServiceId },
                        r => new { r.BusinessKey, r.ServiceId },
                        (sb, r) => new { sb, r })
                        .Where(w => w.sb.b.BusinessKey == businessKey && w.sb.s.ServiceId == serviceId
                          
                            && w.sb.s.ActiveStatus && w.sb.b.ActiveStatus && w.r.ActiveStatus
                        )
                    .Select(r => new DO_ServiceRates
                    {
                       ServiceId = r.sb.s.ServiceId,
                        ServiceDesc = r.sb.s.ServiceDesc,
                        ServiceRule = r.r.ServiceRule,
                        ServiceRate = r.r.OpbaseRate
                    })
                    .FirstOrDefaultAsync();

                return sr;
            }
        }
    }
}
