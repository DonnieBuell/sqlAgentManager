using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sqlAgentManager.contracts
{
    public interface ISqlAgentConnector
    {
        IEnumerable<string> GetJobs();
        void StartJob(string jobName);
    }
}
