using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Abstract
{
    public interface IRecordRepository
    {
        List<CallReport> GetCallReports();
        void DeleteCallReports(CallReport callReport);

        CallReport AddCallReport(CallReport callReport);
    }
}
