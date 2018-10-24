using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.co.brycen.MimamoriDemo
{
    class ClsWarehouseSupplyState
    {

        #region private変数
        /// <summary>
        /// デバイスID
        /// </summary>
        private string strSpplyId;

        /// <summary>
        /// 位置情報 X
        /// </summary>
        private int intLocationX;

        /// <summary>
        /// 位置情報 Y
        /// </summary>
        private int intLocationY;
        #endregion

        #region property
        /// <summary>
        /// デバイスID
        /// </summary>
        public string SupplyId
        {
            set { this.strSpplyId = value; }
            get { return this.strSpplyId; }
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
