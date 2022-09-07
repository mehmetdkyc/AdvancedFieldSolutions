using Data.Access.Abstract;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Concrete
{
    public class RecordRepository : IRecordRepository
    {
        public CallReport AddCallReport(CallReport callReport)
        {
            using (var context = new AdvancedDbContext())
            {
                context.CallReport.Add(callReport);
                context.SaveChanges();
                return callReport;

            }
        }

        public void DeleteCallReports(CallReport callReport)
        {
            using (var context = new AdvancedDbContext())
            {
                context.CallReport.Remove(callReport);
                context.SaveChanges();

            }
        }

        public List<CallReport> GetCallReports()
        {
            using (var context = new AdvancedDbContext())
            {
                return context.CallReport.ToList();

            }
        }
    }
}
