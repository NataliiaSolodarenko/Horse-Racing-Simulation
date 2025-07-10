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

namespace PracTask
{
    public partial class Form1 : Form
    {
        private ProgressBar[] progressBars;
        private List<(int horseNumber, int time)> raceResults;
        private readonly object lockObject = new object();
        private bool isStarted = false;
        private bool isRaceCancelled;

        public Form1()
        {
            InitializeComponent();

            progressBars = new ProgressBar[] { progressBar1, progressBar2, progressBar3, progressBar4, progressBar5 };
        }

        private async void start_Click(object sender, EventArgs e)
        {
            isRaceCancelled = false;

            if (!isStarted)
            {
                isStarted = true;
                start.Text = "Stop";
                raceResults = new List<(int horseNumber, int time)>();
                resultsDataGridView.Rows.Clear();

                var barrier = new Barrier(progressBars.Length);
                var tasks = new List<Task>();

                for (int i = 0; i < progressBars.Length; i++)
                {
                    int horseIndex = i;
                    var progressBar = progressBars[i];

                    tasks.Add(Task.Run(() => RunHorse(horseIndex, progressBar, barrier)));

                    await Task.Delay(50);
                }

                try
                {
                    await Task.WhenAll(tasks);
                    if (!isRaceCancelled)
                        DisplayResults();
                }
                catch
                {
                    MessageBox.Show("The race has been stopped!", "Stop");
                }

                isStarted = false;
                start.Text = "Start";
            }
            else 
            {
                isRaceCancelled = true;
                start.Text = "Start";
                isStarted = false;
            }
        }

        private void RunHorse(int horseIndex, ProgressBar progressBar, Barrier barrier)
        {
            var random = new Random();

            barrier.SignalAndWait();

            int progress = 0;
            int elapsedTime = 0;

            while (progress < 100)
            {
                if (isRaceCancelled)
                    return;

                int speed = random.Next(1, 5);
                progress += speed;

                if (progress > 100) progress = 100;
                Invoke(new Action(() =>
                {
                    progressBar.Value = progress;
                }));

                Thread.Sleep(500);
                elapsedTime += 500;
            }

            lock (lockObject)
            {
                raceResults.Add((horseIndex + 1, elapsedTime));
            }
        }

        private void DisplayResults()
        {
            resultsDataGridView.ColumnCount = 1;
            resultsDataGridView.Columns[0].Width = 100;
            resultsDataGridView.RowHeadersWidth = 100;
            resultsDataGridView.Columns[0].HeaderText = "Horse";

            raceResults = raceResults.OrderBy(r => r.time).ToList();

            foreach (var result in raceResults)
            {
                resultsDataGridView.Rows.Add($"Horse #{result.horseNumber}");
            }

            for(int i = 0; i < progressBars.Length; i++)
                resultsDataGridView.Rows[i].HeaderCell.Value = (1+i) + " Place";
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStarted)
            {
                e.Cancel = true;
                MessageBox.Show("The race is still in progress. Please stop it before closing the window.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
