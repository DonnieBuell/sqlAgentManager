using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sqlAgentManager.contracts;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;

namespace sqlAgentManager.sqlAgentConnector
{
    public class SqlAgentConnector : ISqlAgentConnector
    {
        ServerConnection connection;
        Server server;

        public SqlAgentConnector()
        {
			this.connection = new ServerConnection(@"ServerName", "UserName", "Password");
            this.server = new Server(this.connection);
        }

        public IEnumerable<string> GetJobs()
        {
            try
            {
                JobCollection jobs = this.server.JobServer.Jobs;

                List<string> jobNames = new List<string>();
                foreach (Job job in jobs)
                {
                    jobNames.Add(job.Name);
                }

                return jobNames;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void StartJob(string jobName)
        {
            Job selectedJob = this.server.JobServer.Jobs[jobName];
            selectedJob.Start();
        }
    }
}
