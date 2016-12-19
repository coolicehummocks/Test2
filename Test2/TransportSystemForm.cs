using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public partial class TransportSystemForm : Form
    {
        TransportSystem transportSystem;

        public TransportSystemForm()
        {
            InitializeComponent();     

            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(DoWork);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            bgWorker.WorkerReportsProgress = true;           
        }

        private void TransportSystemForm_Load(object sender, EventArgs e)
        {            
            transportSystem  = new TransportSystem();
        }

        private void b_start_Click(object sender, EventArgs e)
        {
            bgWorker.RunWorkerAsync();
        }

        void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgw = (BackgroundWorker)sender;
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                string message = transportSystem.Iterate();
                bgw.ReportProgress(0, message);
            }
        }

        void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MessageTxBox.Text = MessageTxBox.Text + "\r\n" + e.UserState.ToString();
            MessageTxBox.SelectionStart = MessageTxBox.Text.Length;
            MessageTxBox.ScrollToCaret();
        }

        void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Sumilation finished");
        }
  
    }
}
