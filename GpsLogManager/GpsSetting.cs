using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GpsLogManager.Data;
using GpsLogManager.Field;

namespace GpsLogManager
{
    public partial class GpsSetting : Form
    {
        List<GpsLogSetting> listSetting = null;

        private string DbPath { get; set; }

        public GpsSetting() 
        {
            InitializeComponent();

            listSetting = new List<GpsLogSetting>();
            GetSetting();
        }

        /// <summary>
        /// 설정 정보 등록 / 수정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompleted_Click(object sender, EventArgs e)
        {
            //Hashtable ht = new Hashtable();

            //ht.Add("Name", txtName.Text);
            //ht.Add("Weight", txtWeight.Text);

            //Utils.Setting config = new Setting();
            //config.WriteXml(ht);

            GpsLogSetting setting = new GpsLogSetting();

            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("이름을 입력하세요.", "Gpslog Manager", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }

            if (txtWeight.Text == string.Empty)
            {
                MessageBox.Show("체중을 입력하세요\nkcal 계산에 필요한 정보입니다..", "Gpslog Manager", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWeight.Focus();
                return;
            }

            if (listSetting.Count > 0)
            {
                foreach (GpsLogSetting item in listSetting)
                {
                    setting.NAME = item.NAME;
                    setting.WEIGHT = Convert.ToInt32(txtWeight.Text);
                    setting.HEIGHT = 0;
                    setting.DB_PATH = "1";

                    listSetting.Add(setting);

                    using (GpsLogDac dac = new GpsLogDac())
                    {
                        dac.UpdateSetting(listSetting);
                    }
                }

                MessageBox.Show("프로그램 설정이 수정되었습니다.", "Gpslog Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                setting.NAME = txtName.Text;
                setting.WEIGHT = Convert.ToInt32(txtWeight.Text);
                setting.HEIGHT = 0;
                setting.DB_PATH = "1";

                listSetting.Add(setting);

                using (GpsLogDac dac = new GpsLogDac())
                {
                    dac.InsertSetting(listSetting);
                }

                MessageBox.Show("프로그램 설정이 등록되었습니다.", "Gpslog Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            GetSetting();

            this.Close();
        }

        /// <summary>
        ///  닫기(취소)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCanCel_Click(object sender, EventArgs e)
        {
            List<GpsLogSetting> listInfo = new List<GpsLogSetting>();
            using (GpsLogDac dac = new GpsLogDac())
            {
                listInfo = dac.GetSetting<GpsLogSetting>();
            }

            if (listInfo.Count > 0)
                this.Close();
            else
                Application.Exit();
        }
        
        /// <summary>
        /// 화면 로딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GpsSetting_Load(object sender, EventArgs e)
        {
            GetSetting();
        }

        public void GetSetting()
        {
            using (GpsLogDac dac = new GpsLogDac())
            {
                listSetting = dac.GetSetting<GpsLogSetting>();
            }

            if (listSetting.Count > 0)
            {
                txtName.Text = listSetting[0].NAME;
                txtWeight.Text = listSetting[0].WEIGHT.ToString();

                txtName.Enabled = false;
            }
            else
            {
                txtName.Enabled = true;
                txtName.Text = string.Empty;
                txtWeight.Text = string.Empty;
            }
        }

        /// <summary>
        /// 설정 정보 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            listSetting = new List<GpsLogSetting>();

            foreach (GpsLogSetting item in listSetting)
            {
                GpsLogSetting setting = new GpsLogSetting();

                setting.NAME = item.NAME;
                setting.WEIGHT = Convert.ToInt32(txtWeight.Text);
                setting.HEIGHT = 0;
                setting.DB_PATH = string.Empty;

                listSetting.Add(setting);

                using (GpsLogDac dac = new GpsLogDac())
                {
                    dac.DeleteSetting(listSetting);
                }

                MessageBox.Show("프로그램 설정이 삭제되었습니다.", "Gpslog Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            GetSetting();
        }
    }
}
