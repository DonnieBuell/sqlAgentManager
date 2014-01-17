using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using sqlAgentManager.contracts;

namespace sqlAgentManager.App
{
    public partial class MainWindow : Window
    {
        private ISqlAgentConnector agentConnector;
        private IEnumerable<string> jobs;
        private string selectedJob;

        public MainWindow(ISqlAgentConnector connector)
        {
            this.agentConnector = connector;
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            this.agentConnector.StartJob(this.selectedJob);
        }

        private void lbxJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedJob = this.lbxJobs.SelectedItem.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.refresh();
            this.lbxJobs.ItemsSource = this.jobs;
        }

        private void refresh()
        {
            this.jobs = this.agentConnector.GetJobs();
        }
    }
}
