using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PTiraz.SelectServer;

namespace PTiraz
{
    public partial class MainForm : Form
    {
        int oldRaceNo = 0;
        int lastDistance = 0;

        static string[] Gender = { "", "男子", "女子", "混成", "混合" };
        private System.Windows.Forms.Timer timer;
        private void AddEndTime()
        {
            string sql = @"
               IF NOT EXISTS (
    SELECT * 
    FROM sysobjects 
    WHERE name = '時間経過' 
      AND xtype = 'U'
)
BEGIN
    CREATE TABLE 時間経過 (
        大会番号 INT NOT NULL,
        競技番号 INT NOT NULL,
        時刻 NVARCHAR(5) NULL,
        PRIMARY KEY (大会番号, 競技番号)
    );
END; ";
            try
            {
                using (SqlConnection conn = new SqlConnection(GlobalV.MagicHead + GlobalV.ServerName + GlobalV.MagicWord))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }
           

        }
        public MainForm()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += DispRace;
            timer.Tick += DispTime;
            timer.Start();

            //AddEndTime();

        }
        private void RecordCurrentTime(int raceNo)
        {
            if (raceNo == 0) return;
            string currentTime = DateTime.Now.ToString("HH:mm");
            /*
            string sql = "UPDATE プログラム SET 時間 = '@Endtime'" +
                      " WHERE 大会番号=  @EventNo and 表示用競技番号= @RaceNo ";
            */
            string sql = "UPdate プログラム set 時間= '" + currentTime +"' " + 
                "where 大会番号=" + GlobalV.EventNo + "  and 表示用競技番号=" + raceNo;

            try
            {
                using (SqlConnection conn = new SqlConnection(GlobalV.MagicHead + GlobalV.ServerName + GlobalV.MagicWord))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        /*
                        cmd.Parameters.AddWithValue("@EndTime", currentTime);
                        cmd.Parameters.AddWithValue("@EventNo", GlobalV.EventNo);
                        cmd.Parameters.AddWithValue("@RaceNo", raceNo);
                        */
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void DispTime(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString("HH:mm");
            lblCurrentTime.Text = currentTime;

        }
        private void DispNextRace(int raceNo)
        {
            int thisDistance;
            string sqlQuery = "select 表示用競技番号, クラス.クラス名称, プログラム.性別コード , 距離.距離, 種目.種目 from"
                + " プログラム inner join クラス on プログラム.クラス番号 = クラス.クラス番号"
                + " inner join 距離 on 距離.距離コード = プログラム.距離コード"
                + " inner join 種目 on 種目.種目コード = プログラム.種目コード "
                + " where クラス.大会番号= @EventNo "
                + " and プログラム.大会番号= @EventNo "
                + " and プログラム.表示用競技番号= @RaceNo ";
            using (SqlConnection conn = new SqlConnection(GlobalV.MagicHead + GlobalV.ServerName + GlobalV.MagicWord))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@EventNo", GlobalV.EventNo);
                    cmd.Parameters.AddWithValue("@RaceNo", raceNo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        lblRaceNo.Text = "競技番号 : " + reader["表示用競技番号"];
                        lblClassGender.Text = "" + reader["クラス名称"] + " " + Gender[Convert.ToInt32(reader["性別コード"])];
                        string distanceString = "" + reader["距離"];
                        thisDistance =Convert.ToInt32( distanceString.Substring(0, 4));
                        lblDistanceStyle.Text = "" + distanceString + " " + reader["種目"];
                        if (thisDistance!= lastDistance)
                        {
                            CustomMessageBox.Show("距離が" + thisDistance + "m に変わりました", "Caution!!");
                            lastDistance = thisDistance;
                        }
                    }
                }
            }
        }
        private void DispRace(object sender, EventArgs e) {

            int raceNo = GetCurrentPrgNo();
            if (raceNo == 0)
            {
                timer.Tick -= DispRace;
                timer.Tick -= DispTime;
                timer.Stop();
                MessageBox.Show("すべてのレース終了しました。");
                this.Close();

                return;
            }
            if (oldRaceNo != raceNo)
            {
                RecordCurrentTime(oldRaceNo);
                oldRaceNo = raceNo;
                DispNextRace(raceNo);
            }
        }
        private static int GetCurrentPrgNo()
        {
            string sqlQuery = "select 表示用競技番号 , 進行フラグ  from プログラム " +
                " where 大会番号 = " + GlobalV.EventNo +
                " Order by 表示用競技番号";
            SqlConnection connection = null;
            try
            {

                using (connection = new SqlConnection(GlobalV.MagicHead + GlobalV.ServerName + GlobalV.MagicWord))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (Convert.ToInt32(reader["進行フラグ"]) == 1) return Convert.ToInt32(reader["表示用競技番号"]);

                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return 0;
        }

    }
}
