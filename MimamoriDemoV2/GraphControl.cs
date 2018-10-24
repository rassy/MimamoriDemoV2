using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using jp.co.brycen.MimamoriDemo.Properties;
using System.Threading.Tasks;

namespace jp.co.brycen.MimamoriDemo
{
    public partial class GraphControl : UserControl
    {
        // 端末リスト
        string[] deviceList;

        public GraphControl()
        {
            InitializeComponent();

            Timer timer = new Timer();
            timer.Tick += Timer_Tick;
            try
            {
                timer.Interval = int.Parse(Settings.Default["GraphInterval"].ToString());
            }
            catch
            {
                timer.Interval = 1000;
            }

            try
            {
                deviceList = Settings.Default["DeviceList"].ToString().Split(',');
            }
            catch
            {
                deviceList = new string[] { "端末１", "端末２", "端末３" };
            }

            //Task.Delay(TimeSpan.FromSeconds(3));
            RefreshChart();
            timer.Enabled = true;
        }

        /// <summary>
        /// タイマーによる発火
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            RefreshChart();
        }

        /// <summary>
        /// グラフをリフレッシュする
        /// </summary>
        private void RefreshChart()
        {
            if (deviceList.Length > 0)
            {
                CreateChart(chart1, deviceList[0], pictureBox1, lblTemp1, lblHumid1, lblTimeStamp1);
            }
            if (deviceList.Length > 1)
            {
                CreateChart(chart2, deviceList[1], pictureBox2, lblTemp2, lblHumid2, lblTimeStamp2);
            }
            if (deviceList.Length > 2)
            {
                CreateChart(chart3, deviceList[2], pictureBox3, lblTemp3, lblHumid3, lblTimeStamp3);
            }
        }

        /// <summary>
        /// グラフを設定する
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="strIdName"></param>
        /// <param name="pictureBox"></param>
        /// <param name="lblTemp"></param>
        /// <param name="lblHumid"></param>
        /// <param name="lblTimeStamp"></param>
        private void CreateChart(Chart chart, string strIdName, PictureBox pictureBox, Label lblTemp, Label lblHumid, Label lblTimeStamp)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            // 温度
            var tempSeries = new Series();
            tempSeries.ChartType = SeriesChartType.Column;
            tempSeries.LegendText = "温度";
            tempSeries.XValueMember = "time";
            tempSeries.YValueMembers = "temp";
            tempSeries.YAxisType = AxisType.Primary;

            // 湿度
            var humidSeries = new Series();
            humidSeries.ChartType = SeriesChartType.Line;
            humidSeries.LegendText = "湿度";
            humidSeries.BorderWidth = 2;
            humidSeries.MarkerStyle = MarkerStyle.Circle;
            humidSeries.XValueMember = "time";
            humidSeries.YValueMembers = "humid";
            humidSeries.BorderColor = Color.Red;
            humidSeries.Color = Color.Red;
            humidSeries.YAxisType = AxisType.Secondary;

            ChartArea area = new ChartArea();
            area.AxisX.Title = "時間";
            area.AxisY.Title = "温度（℃）";
            area.AxisY2.Title = "湿度（％）";

            chart.ChartAreas.Add(area);
            chart.Series.Add(tempSeries);
            chart.Series.Add(humidSeries);

            chart.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("ＭＳ ゴシック", 8);
            chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("ＭＳ ゴシック", 8);
            chart.ChartAreas[0].AxisY2.LabelStyle.Font = new Font("ＭＳ ゴシック", 8);

            string maxTemp = Settings.Default["MaxTemp"].ToString();
            string minTemp = Settings.Default["MinTemp"].ToString();
            string maxHumid = Settings.Default["MaxHumid"].ToString();
            string minHumid = Settings.Default["MinHumid"].ToString();

            if (maxTemp != "")
            {
                chart.ChartAreas[0].AxisY.Maximum = int.Parse(maxTemp);
            }
            if (minTemp != "")
            {
                chart.ChartAreas[0].AxisY.Minimum = int.Parse(minTemp);
            }
            if (maxHumid != "")
            {
                chart.ChartAreas[0].AxisY2.Maximum = int.Parse(maxHumid);
            }
            if (minHumid != "")
            {
                chart.ChartAreas[0].AxisY2.Minimum = int.Parse(minHumid);
            }
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            // データの読み込み
            var sourceDt = ImportCsvToDataTable(CreateDataTable(), Settings.Default["CsvFilePath"].ToString());

            if (sourceDt != null && sourceDt.Rows.Count > 0)
            {
                var rows = sourceDt.Select(string.Format("id = '{0}' AND timestamp >='{1}'", strIdName, DateTime.Now.AddMinutes(int.Parse(Settings.Default["TargetMinutes"].ToString()) * -1).ToString("yyyy/MM/dd HH:mm:ss")), "timestamp");
                //var rows = sourceDt.Select(string.Format("id = '{0}'", strIdName), "timestamp");

                if (rows.Count() > 0)
                {
                    switch (rows[rows.Count() - 1]["wbgt"].ToString())
                    {
                        case "0":
                            pictureBox.Image = Resources.L00_注意;
                            break;
                        case "1":
                            pictureBox.Image = Resources.L01_警戒;
                            break;
                        case "2":
                            pictureBox.Image = Resources.L02_厳重警戒;
                            break;
                        case "3":
                            pictureBox.Image = Resources.L03_危険;
                            break;
                    }

                    lblTemp.Text = rows[rows.Count() - 1]["temp"].ToString();
                    lblHumid.Text = rows[rows.Count() - 1]["humid"].ToString();
                    DateTime datetime = DateTime.Parse(rows[rows.Count() - 1]["timestamp"].ToString());
                    lblTimeStamp.Text = datetime.ToLongTimeString();

                    // distinctかける
                    DataView dv = rows.CopyToDataTable().DefaultView;
                    DataTable dt = dv.ToTable(true, "id", "deviceid", "temp", "humid", "wbgt", "timestamp", "time");
                    chart.DataSource = dt;
                    dv.Dispose();
                }
            }
            sourceDt.Dispose();
        }

        /// <summary>
        /// CSV読み込み用のDataTable作成
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("deviceid", typeof(string));
            dt.Columns.Add("temp", typeof(double));
            dt.Columns.Add("humid", typeof(double));
            dt.Columns.Add("wbgt", typeof(int));
            dt.Columns.Add("timestamp", typeof(DateTime));
            dt.Columns.Add("time", typeof(string));
            return dt;
        }

        /// <summary>
        /// CSVファイルをDataTableに読み込み
        /// </summary>
        /// <param name="dt"">DataTable</param>
        /// <param name="strFilePath">読み込むCSVのパス</param>
        /// <returns></returns>
        private DataTable ImportCsvToDataTable(DataTable dt,string strFilePath)
        {
            using (FileStream fs = new FileStream(strFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < dt.Columns.Count - 1; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dr[dt.Columns.Count - 1] = DateTime.Parse(rows[dt.Columns.Count - 2].ToString()).ToShortTimeString();
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }
    }
}
