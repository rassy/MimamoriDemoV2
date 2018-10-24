using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.co.brycen.MimamoriDemo
{
    /// <summary>
    /// デバイスクラス
    /// </summary>
    class ClsDeviceState
    {
        #region private変数
        /// <summary>
        /// デバイスID
        /// </summary>
        private string strDeviceId;

        /// <summary>
        /// 指数
        /// </summary>
        private int intIndicater;

        /// <summary>
        /// 位置情報 X
        /// </summary>
        private int intLocationX;
        
        /// <summary>
        /// 位置情報 Y
        /// </summary>
        private int intLocationY;
        #endregion

        #region 定数
        /// <summary>
        /// 熱中症指数：注意
        /// </summary>
        private const int IDC_CAUTION = 0;
        
        /// <summary>
        /// 熱中症指数：警戒
        /// </summary>
        private const int IDC_WEAK_ALERT = 1;

        /// <summary>
        /// 熱中症指数：厳重警戒
        /// </summary>
        private const int IDC_STRONG_ALERT = 2;

        /// <summary>
        /// 熱中症指数：危険
        /// </summary>
        private const int IDC_DANGEROUS = 3;
        #endregion

        #region property
        /// <summary>
        /// デバイスID
        /// </summary>
        public string DeviceId
        {
            set { this.strDeviceId = value; }
            get { return this.strDeviceId; }
        }

        /// <summary>
        /// 指数
        /// </summary>
        public int Indicater
        {
            set { this.intIndicater = value; }
            get { return this.intIndicater; }
        }

        /// <summary>
        /// 指数画像パス
        /// </summary>
        public Bitmap IndicaterImage
        {
            get {
                switch (this.intIndicater) {

                    case IDC_CAUTION:
                        return Properties.Resources.L00_注意_顔のみ;
                    case IDC_WEAK_ALERT:
                        return Properties.Resources.L01_警戒_顔のみ;
                    case IDC_STRONG_ALERT:
                        return Properties.Resources.L02_厳重警戒_顔のみ;
                    case IDC_DANGEROUS:
                        return Properties.Resources.L03_危険_顔のみ;
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// 位置情報 X
        /// </summary>
        public int LocationX
        {
            set { this.intLocationX = value; }
            get { return this.intLocationX; }
        }

        /// <summary>
        /// 位置情報 Y
        /// </summary>
        public int LocationY
        {
            set { this.intLocationY = value; }
            get { return this.intLocationY; }
        }
        #endregion
    }
}
