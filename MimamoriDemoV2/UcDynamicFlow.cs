using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jp.co.brycen.MimamoriDemo.Properties;

namespace jp.co.brycen.MimamoriDemo
{
    public partial class UcDynamicFlow : UserControl
    {
        /// <summary>
        /// デバイス状態クラスのリスト
        /// </summary>
        private List<ClsDeviceState> m_lstDeviceState = new List<ClsDeviceState>();

        /// <summary>
        /// CSV読み込み行数MAX
        /// </summary>
        private int m_intMaxNum = 0;

        /// <summary>
        /// CSV読み込み行数現在
        /// </summary>
        private int m_intCurNum = 0;

        /// <summary>
        /// サプライ状態クラスのリスト
        /// </summary>
        private List<ClsWarehouseSupplyState> m_lstSupplyState = new List<ClsWarehouseSupplyState>();

        /// <summary>
        /// CSV読み込み行数MAX
        /// </summary>
        private int m_intSupMaxNum = 0;

        /// <summary>
        /// CSV読み込み行数現在
        /// </summary>
        private int m_intSupCurNum = 0;

        /// <summary>
        /// NEW
        /// </summary>
        public UcDynamicFlow()
        {
            InitializeComponent();

            // CSVファイル読み込み
            this.ReadCSV();
            // CSVファイル読み込み
            this.ReadSupplyCSV();

            // タイマーセット（デバイス情報設定）
            Timer timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Enabled = true;
        }

        /// <summary>
        /// タイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.SetStsToUsrIcon();

            this.SetStsToSupplyIcon();
        }

        #region Device
        /// <summary>
        /// CSVファイル読み込み
        /// </summary>
        private void ReadCSV()
        {
            this.m_lstDeviceState.Clear();

			using (StreamReader reader = new StreamReader(Settings.Default["CsvFilePath2"].ToString(), Encoding.UTF8))
			{

				while (reader.Peek() >= 0)
				{
					ClsDeviceState objDvcSts = new ClsDeviceState();

					string[] cols = reader.ReadLine().Split(',');

					// 変なデータは受け取らない
					if (String.IsNullOrEmpty(cols[0]) || String.IsNullOrEmpty(cols[0]) || String.IsNullOrEmpty(cols[0]) || String.IsNullOrEmpty(cols[0]))
					{
						continue;
					}

					// データ格納
					objDvcSts.DeviceId = cols[0].ToString();
					objDvcSts.Indicater = Convert.ToInt32(cols[1]);
					objDvcSts.LocationX = Convert.ToInt32(cols[2]);
					objDvcSts.LocationY = Convert.ToInt32(cols[3]);

					this.m_lstDeviceState.Add(objDvcSts);
				}
			}
        }

        /// <summary>
        /// デバイス情報設定
        /// </summary>
        private void SetStsToUsrIcon()
        {
            if (this.m_lstDeviceState == null || !(this.m_lstDeviceState.Any()))
            {
                return;
            }

            this.m_intMaxNum = this.m_lstDeviceState.Count - 1;

            // デバイス名と同一のコントロール取得
            ClsDeviceState dvcSts = this.m_lstDeviceState[this.m_intCurNum];
            PictureBox pcbDevice = (PictureBox)this.Controls[dvcSts.DeviceId];

            if (pcbDevice != null)
            {
                // ロケーション画像設定
                pcbDevice.Location = new Point(dvcSts.LocationX, dvcSts.LocationY);
                pcbDevice.Image = dvcSts.IndicaterImage;
            }

            if (this.m_intMaxNum == this.m_intCurNum)
            {
                this.m_intCurNum = 0;
            }
            else
            {
                this.m_intCurNum++;
            }

        }
		#endregion

		#region Supply
		/// <summary>
		/// CSVファイル読み込み
		/// </summary>
		private void ReadSupplyCSV()
		{
			this.m_lstSupplyState.Clear();

			using (StreamReader reader = new StreamReader(Settings.Default["CsvFilePath3"].ToString(), Encoding.UTF8))
			{

				while (reader.Peek() >= 0)
				{
					ClsWarehouseSupplyState objSupplySts = new ClsWarehouseSupplyState();

					string[] cols = reader.ReadLine().Split(',');

					// 変なデータは受け取らない
					if (String.IsNullOrEmpty(cols[0]) || String.IsNullOrEmpty(cols[0]) || String.IsNullOrEmpty(cols[0]) || String.IsNullOrEmpty(cols[0]))
					{
						continue;
					}

					// データ格納
					objSupplySts.SupplyId = cols[0].ToString();
					objSupplySts.LocationX = Convert.ToInt32(cols[1]);
					objSupplySts.LocationY = Convert.ToInt32(cols[2]);

					this.m_lstSupplyState.Add(objSupplySts);
				}
			}
        }

        /// <summary>
        /// サプライ情報設定
        /// </summary>
        private void SetStsToSupplyIcon()
        {
            if (this.m_lstSupplyState == null || !(this.m_lstSupplyState.Any()))
            {
                return;
            }

            this.m_intSupMaxNum = this.m_lstSupplyState.Count - 1;

            // デバイス名と同一のコントロール取得
            ClsWarehouseSupplyState dvcSts = this.m_lstSupplyState[this.m_intSupCurNum];
            PictureBox pcbDevice = (PictureBox)this.Controls[dvcSts.SupplyId];

            if (pcbDevice != null)
            {
                // ロケーション画像設定
                pcbDevice.Location = new Point(dvcSts.LocationX, dvcSts.LocationY);
            }

            if (this.m_intSupMaxNum == this.m_intSupCurNum)
            {
                this.m_intSupCurNum = 0;
            }
            else
            {
                this.m_intSupCurNum++;
            }

        }
        #endregion
    }
}
