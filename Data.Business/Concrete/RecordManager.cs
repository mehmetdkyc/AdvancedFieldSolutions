using Data.Access.Abstract;
using Data.Access.Concrete;
using Data.Business.Abstract;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Business.Concrete
{
    public class RecordManager : IRecordsService

    {

        private IRecordRepository recordRepository;

        public RecordManager()
        {
            recordRepository = new RecordRepository();
        }
        public CallReport AddCallReport(CallReport callReport)
        {
            return recordRepository.AddCallReport(callReport);
        }

        public void DeleteCallReports(CallReport callReport)
        {
            recordRepository.DeleteCallReports(callReport);
        }

        public List<CallReport> GetCallReports()
        {
            return recordRepository.GetCallReports();
        }
    }
}
