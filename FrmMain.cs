using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace KSANamePlate
{
    public partial class FrmMain : Form
    {
        private Bitmap image;
        private Setting st;
        private List<RoomInfo> roomDB;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void writeLog(string str)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => textLog.Text += str + Environment.NewLine));
            else
                textLog.Text += str + Environment.NewLine;
        }

        private Bitmap getPicture(string stdID)
        {
            string url = "http://students.ksa.hs.kr/uploadfiles/SCTSTUDENTN/" + stdID + ".jpg";
            Bitmap image = new Bitmap(1, 1);
            HttpWebRequest requestPic = (HttpWebRequest)HttpWebRequest.Create(url);
            requestPic.UserAgent = "Mozilla/5.0";

            try
            {
                WebResponse responsePic = requestPic.GetResponse();
                image = (Bitmap)Image.FromStream(responsePic.GetResponseStream());
            }
            catch
            {
                writeLog("Fail to load " + stdID + "'s picture. Use default img instead");
            }
            return image;
        }

        private void butLoadImageFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "KSA NamePlate Generator";
            openFileDialog.Filter = "Image Files (png)|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(openFileDialog.FileName);
                if (image == null) writeLog("Unable to set image");
            }
        }

        private void butLoadSettingFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "KSA NamePlate Generator";
            openFileDialog.Filter = "Conf Files (ini)|*.ini";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                st = Setting.FromFile(openFileDialog.FileName);
                if (st == null) writeLog("Unable to load setting file");
            }
        }

        private void butLoadDBFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "KSA NamePlate Generator";
            openFileDialog.Filter = "Text Files (txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                roomDB = RoomInfo.ParseFile(openFileDialog.FileName);
                if (roomDB == null) writeLog("Unable to load roomdb");
            }
        }

        private void butExecute_Click(object sender, EventArgs e)
        {
            if (image == null || st == null || roomDB == null)
            {
                writeLog("Image or setting or roomdb is not set");
                return;
            }
            if (executer.IsBusy) return;
            butExecute.Enabled = false;
            executer.RunWorkerAsync();
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            if (executer.IsBusy) executer.CancelAsync();
            butExecute.Enabled = true;
        }

        private void executer_DoWork(object sender, DoWorkEventArgs e)
        {
            writeLog("Start processing...");

            RectangleF imgRect1 = new RectangleF(st.Std1PictureLocation.X,
                st.Std1PictureLocation.Y, st.PictureSize.X, st.PictureSize.Y);
            RectangleF imgRect2 = new RectangleF(st.Std2PictureLocation.X,
                st.Std2PictureLocation.Y, st.PictureSize.X, st.PictureSize.Y);
            Font fontID = new Font(st.IDFontFamily, st.IDFontSize);
            Font fontName = new Font(st.NameFontFamily, st.NameFontSize);
            SolidBrush brushID = new SolidBrush(st.IDFontColor);
            SolidBrush brushName = new SolidBrush(st.NameFontColor);

            foreach (RoomInfo ri in roomDB)
            {
                if (e.Cancel) return;
                System.GC.Collect();

                Bitmap img1, img2; SizeF siz1, siz2;
                Bitmap result = (Bitmap)image.Clone();
                Graphics g = Graphics.FromImage(result);
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                writeLog("Get Image of " + ri.Std1.ID);
                img1 = getPicture(ri.Std1.ID);
                g.DrawImage(img1, imgRect1);
                siz1 = g.MeasureString(ri.Std1.ID, fontID);
                g.DrawString(ri.Std1.ID, fontID, brushID,
                    st.Std1IDLocation.X - siz1.Width / 2, st.Std1IDLocation.Y - siz1.Height / 2);
                siz1 = g.MeasureString(ri.Std1.Name, fontName);
                g.DrawString(ri.Std1.Name, fontName, brushName,
                    st.Std1NameLocation.X - siz1.Width / 2, st.Std1NameLocation.Y - siz1.Height / 2);

                writeLog("Get Image of " + ri.Std2.ID);
                img2 = getPicture(ri.Std2.ID);
                g.DrawImage(img2, imgRect2);
                siz2 = g.MeasureString(ri.Std2.ID, fontID);
                g.DrawString(ri.Std2.ID, fontID, brushID,
                    st.Std2IDLocation.X - siz2.Width / 2, st.Std2IDLocation.Y - siz2.Height / 2);
                siz2 = g.MeasureString(ri.Std1.Name, fontName);
                g.DrawString(ri.Std2.Name, fontName, brushName,
                    st.Std2NameLocation.X - siz2.Width / 2, st.Std2NameLocation.Y - siz2.Height / 2);

                result.Save(ri.Std1.ID + "_" + ri.Std2.ID + ".png");
                writeLog("Made file of " + ri.Std1.ID + " and " + ri.Std2.ID);
            }
            writeLog("Finished");
        }

        private void executer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            butExecute.Enabled = true;   
        }

        private void textLog_TextChanged(object sender, EventArgs e)
        {
            textLog.SelectionStart = textLog.Text.Length;
            textLog.ScrollToCaret();
        }
    }
}
