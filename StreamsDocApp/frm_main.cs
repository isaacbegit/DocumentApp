using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamsDocApp
{
    public partial class frm_main : Form
    {

        private bool _canDraw;
        private int _startX, _startY;
        private Rectangle _rect;
        private string[] rectdata = new string[3];
        public frm_main()
        {
            InitializeComponent();
        }


       
        int pictop = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public Graphics panel;
        public Bitmap drawing;

        private void boxImg_MouseDown(object sender, MouseEventArgs e)
        {
            //The system is now allowed to draw rectangles
            _canDraw = true;
            //Initialize and keep track of the start position
            _startX = e.X;
            _startY = e.Y;


            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void boxImg_MouseUp(object sender, MouseEventArgs e)
        {
            //The system is no longer allowed to draw rectangles
            _canDraw = false;

            if (optF1.Checked == true)
            {
                txt_field1.Text = _rect.X + "," + _rect.Y;
                rectdata[0] = _rect.X + "," + _rect.Y + "," + _rect.Width + "," + _rect.Height;
                txt_field1.ForeColor = Color.Lime;
            }

            if (optF2.Checked == true)
            {
                txt_field2.Text = _rect.X + "," + _rect.Y;
                rectdata[1] = _rect.X + "," + _rect.Y + "," + _rect.Width + "," + _rect.Height;
                txt_field2.ForeColor = Color.Lime;
            }

            if (optF3.Checked == true)
            {
                txt_field3.Text = _rect.X + "," + _rect.Y;
                rectdata[2] = _rect.X + "," + _rect.Y + "," + _rect.Width + "," + _rect.Height;
                txt_field3.ForeColor = Color.Lime;
            }
            boxImg.Cursor = Cursors.Default;

        }

        private void boxImg_MouseMove(object sender, MouseEventArgs e)
        {
            


            // pan

            if (e.Button == System.Windows.Forms.MouseButtons.Right )
            {
                boxImg.Cursor = Cursors.SizeAll;
                boxImg .Left = e.X + boxImg .Left - MouseDownLocation.X;
                boxImg .Top = e.Y + boxImg.Top - MouseDownLocation.Y;
            }
            else
            {

                //If we are not allowed to draw, simply return and disregard the rest of the code
                if (!_canDraw) return;
                boxImg.Cursor = Cursors.Cross;
                //The x-value of our rectangle should be the minimum between the start x-value and the current x-position
                int x = Math.Min(_startX, e.X);
                //The y-value of our rectangle should also be the minimum between the start y-value and current y-value
                int y = Math.Min(_startY, e.Y);

                //The width of our rectangle should be the maximum between the start x-position and current x-position minus
                //the minimum of start x-position and current x-position
                int width = Math.Max(_startX, e.X) - Math.Min(_startX, e.X);

                //For the hight value, it's basically the same thing as above, but now with the y-values:
                int height = Math.Max(_startY, e.Y) - Math.Min(_startY, e.Y);
                _rect = new Rectangle(x, y, width, height);
                //Refresh the form and draw the rectangle

            }

            Refresh();
            
        }
        

        private void boxImg_Paint(object sender, PaintEventArgs e)
        {
            //Create a new 'pen' to draw our rectangle with, give it the color red and a width of 2
            using (Pen pen = new Pen(Color.Red, 2))
            {
                //Draw the rectangle on our form with the pen
                e.Graphics.DrawRectangle(pen, _rect);
            }
        }

        private void btn_openDoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Images (*.TIF)|*.TIF";
            DialogResult dr = openFile.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string TiffFilePath = openFile.FileName;
                link_path.Text = openFile.FileName.ToString();
                List<Image> images = new List<Image>();
                images = HelperClass . GetAllPages(TiffFilePath);

                for (int x = 0; x < images.Count; x++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Image = images[x];
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Width = 200;
                    pic.Height = 200;
                    pic.Top = pictop;
                    pic.Left = 5;
                    pic.MouseClick += new MouseEventHandler(imgPage_mouseClick);
                    pnl_allPages.Controls.Add(pic);
                    pictop += 210;

                }
                btn_SaveData.Enabled = true;

            }

        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            for (int x=0;x<rectdata .Length;x++)
            {
                if (rectdata [x]==null)
                {
                    new_note.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error;
                    new_note.Text = "please draw Loarion for Field" + x + 1;
                    new_note.Show();
                    return;
                }
            }

            try
            {
                
                

                SqlConnection MyConn = new SqlConnection(HelperClass.DbConnectionStr);
                string sql = "INSERT INTO tbl_documents(doc_path,field1_cordinates,field2_cordinates,field3_cordinates,field1_Rec,field2_Rec,field3_Rec,doc_processed,doc_inuse)" +
                        " VALUES(@doc_path,@field1_cordinates,@field2_cordinates,@field3_cordinates,@field1_Rec,@field2_Rec,@field3_Rec,@doc_processed,@doc_inuse)";

                SqlCommand cmd = new SqlCommand(sql, MyConn);
                cmd.Parameters.Add("@doc_path", SqlDbType.NVarChar, 100).Value = link_path.Text.Trim();
                cmd.Parameters.Add("@field1_cordinates", SqlDbType.NVarChar, 100).Value = txt_field1.Text.Trim();
                cmd.Parameters.Add("@field2_cordinates", SqlDbType.VarChar, 100).Value = txt_field2.Text.Trim();
                cmd.Parameters.Add("@field3_cordinates", SqlDbType.VarChar, 100).Value = txt_field3.Text.Trim();

                cmd.Parameters.Add("@field1_Rec", SqlDbType.NVarChar, 100).Value = rectdata[0].ToString();
                cmd.Parameters.Add("@field2_Rec", SqlDbType.NVarChar, 100).Value = rectdata[1].ToString();
                cmd.Parameters.Add("@field3_Rec", SqlDbType.NVarChar, 100).Value = rectdata[2].ToString();
                cmd.Parameters.Add("@doc_processed", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@doc_inuse", SqlDbType.Int).Value = 0;
                MyConn.Open();
                cmd.ExecuteNonQuery();
                MyConn.Close();
                new_note.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Success;
                new_note.Text = "document Data Saved";
                new_note.Show();
                // Clear all Fileds 
                ClearAllControls();

            }
            catch (Exception ex)
            {
                new_note.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error;
                new_note.Text = ex.Message;
                new_note.Show();
            }

        }

        private void  ClearAllControls()
        {
            for (int x = 0; x < rectdata.Length; x++)
            {
                rectdata[x] = null;
            }

            
                pnl_allPages.Controls.Clear ();
            
            pnl_allPages.Refresh();
            txt_field1.Text = "None";
            txt_field1.ForeColor = Color.Red;
            txt_field2.Text = "None";
            txt_field2.ForeColor = Color.Red;
            txt_field3.Text = "None";
            txt_field3.ForeColor = Color.Red;
            link_path.Text = "";
            optF1.Checked = true;
            boxImg.Image = null;
            pictop = 0;
        }

        private void optF1_Click(object sender, EventArgs e)
        {
            new_note.Hide();
        }

        private Point MouseDownLocation;

        
        private void timer1_Tick(object sender, EventArgs e)
        {
           

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            HelperClass.loginstate = false;
            this.Hide();

        }

        private void imgPage_mouseClick(object sender, MouseEventArgs e)
        {
            
           
            PictureBox img;
            img = ((PictureBox)(sender));
            boxImg.Image = img.Image;
            boxImg.Refresh();
        }
    }
}
