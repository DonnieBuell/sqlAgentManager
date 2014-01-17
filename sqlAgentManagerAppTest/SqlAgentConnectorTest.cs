using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sqlAgentManager.contracts;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sqlAgentManager.sqlAgentConnector;
 

namespace sqlAgentManagerAppTest
{
    [TestClass]
    public class SqlAgentConnectorTest
    {
        [TestMethod]
        public void  TestEmptyList()
        {
           SqlAgentConnector instance = new SqlAgentConnector();
           List<string> result = instance.GetJobs().ToList<string>();
           Assert.IsNotNull(result);
           Assert.AreEqual(0, result.Count);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNullJob()
        {
            ISqlAgentConnector sqlConnector = new SqlAgentConnector();
            sqlConnector.StartJob(null);
        }
    }
}
