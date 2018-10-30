using ImageProcess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamsDocApp
{
    public partial class frm_dataEntry : Form
    {
        public frm_dataEntry()
        {
            InitializeComponent();
        }
        private int curtskindx=0;
        private void box_process_img_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void box_process_img_MouseMove(object sender, MouseEventArgs e)
        {

        }

        Rectangle DrawCurr;
        private void LoadCurrentTask(int task_index,PictureBox box_page, int FldNo)
        {
            pnl_displuPage.VerticalScroll.Value = 0;
            pnl_displuPage.VerticalScroll.Value = 0;
            box_page1.Image = null;
            string tiffPath = HelperClass.Lst_DocData[task_index].doc_Path.ToString();
            int imgindex = 0;
            List<Image> images = new List<Image>();
            images = HelperClass.GetAllPages(tiffPath);
            string FldRec="";
            switch (FldNo)
            {
                case 1:
                    FldRec = HelperClass.Lst_DocData[task_index].Fld1_XYCrds.ToString();
                    imgindex = 0;
                    break;
                case 2:
                    FldRec = HelperClass.Lst_DocData[task_index].Fld2_XYCrds.ToString();
                    imgindex = 0;
                    break;
                case 3:
                    FldRec = HelperClass.Lst_DocData[task_index].Fld3_XYCrds.ToString();
                    imgindex = 1;
                    break;
            }
            


            string[] strSplitArr;
            char[] separator = new char[] { ',' };
            strSplitArr = FldRec.Split(separator);
            Rectangle rec = new Rectangle(Int32.Parse(strSplitArr[0]), Int32.Parse(strSplitArr[1]), Int32.Parse(strSplitArr[2]), Int32.Parse(strSplitArr[3]));
            DrawCurr = rec;
            box_page1.Image = images[imgindex];
            try
            {
                pnl_displuPage.VerticalScroll.Value = rec.X - 50;
                pnl_displuPage.VerticalScroll.Value = rec.Y - 50;
                // CropImage(images[imgindex], rec, box_page);
            }catch
            {

            }
        }

        private void CropImage(Image img,Rectangle Rec, PictureBox box)
        {
            try
            {
                box.Image = null;
               
                Image imge = new Bitmap(1, 1);
                Graphics drawing = Graphics.FromImage(imge);
                imge.Dispose();
                drawing.Dispose();
                imge = new Bitmap(img.Width, img.Height);

                drawing = Graphics.FromImage(imge);
                drawing.DrawImage(img, 0, 0, img.Width, img.Height);
                //drawing.DrawRectangle(Pens.Red, Rec.X, Rec.Y , Rec.Width, Rec.Height);
                drawing.Save();
                drawing.Dispose();
                box.Image = imge;

                pnl_displuPage.VerticalScroll.Value = Rec.X - 50;
                pnl_displuPage.VerticalScroll.Value = Rec.Y - 50;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }








        }

        private void frm_dataEntry_Load(object sender, EventArgs e)
        {
            // load data 
            GetImages2Process(pnl_QueueImgs);
            LoadCurrentTask(curtskindx, box_page1,1);
            txt_field1.Focus();
        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            Image img = box_page1.Image;
            Rectangle cropRect = new Rectangle(200, 100, 60, 60);
            Bitmap src = (Bitmap)img;
            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }
           // pictureBox1.Image = src;
            // box_process_img.Refresh();
        }


        private void GetImages2Process(MonoFlat.MonoFlat_Panel pnl)
        {
            int picLeft = 0;
            // select some images with status not proccessed 
            //and not currently proccessed by other users 

            SqlConnection MyConn = new SqlConnection(HelperClass.DbConnectionStr);
            string comm = "SELECT doc_id,doc_path,field1_Rec,field2_Rec,field3_Rec FROM tbl_documents WHERE doc_processed='" + 0 + "' AND doc_inuse='" + 0 + "' ";
            SqlDataAdapter da = new SqlDataAdapter(comm, MyConn);
            DataSet ds = new DataSet();
            MyConn.Open();
            da.Fill(ds);
            MyConn.Close();

            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            {
                string TiffFilePath = ds.Tables[0].Rows[x].ItemArray[1].ToString();
                HelperClass.Document doc = new HelperClass.Document
                {
                    doc_Id = Int32.Parse(ds.Tables[0].Rows[x].ItemArray[0].ToString().Trim()),
                    doc_Path = ds.Tables[0].Rows[x].ItemArray[1].ToString(),
                    Fld1_XYCrds = ds.Tables[0].Rows[x].ItemArray[2].ToString(),
                    Fld2_XYCrds = ds.Tables[0].Rows[x].ItemArray[3].ToString(),
                    Fld3_XYCrds = ds.Tables[0].Rows[x].ItemArray[4].ToString(),

                };

                HelperClass.Lst_DocData.Add(doc);

                // disply images in Que 
                //List<Image> images = new List<Image>();
                //images = HelperClass.GetAllPages(TiffFilePath);

                //for (int R = 0; R < images.Count; R++)
                //{
                //    PictureBox pic = new PictureBox();
                //    pic.Image = images[R];
                //    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                //    pic.Width = 200;
                //    pic.Height = 150;
                //    pic.Left = picLeft;
                //    pic.Top = 5;
                //    //  pic.MouseClick += new MouseEventHandler(imgPage_mouseClick);
                //    pnl_QueueImgs.Controls.Add(pic);
                //    picLeft += 210;

                //}


            }


            
            

        }








        Font font = new Font("Times New Roman", 15.0f);
        private void box_process_img_Paint(object sender, PaintEventArgs e)
        {
            if (DrawCurr != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(Pens.Red, DrawCurr);
                e.Graphics.FillEllipse(Brushes.Red, DrawCurr.X - 5, DrawCurr.Y - 5, 11, 11);
                
                switch (Curr_txtfiled)
                {
                    case 1:
                        e.Graphics.DrawString(txt_field1.Text, font, Brushes.Red, DrawCurr);
                        break;
                    case 2:
                        e.Graphics.DrawString(txt_field2.Text, font, Brushes.Red, DrawCurr);
                        break;
                    case 3:
                        e.Graphics.DrawString(txt_field3.Text, font, Brushes.Red, DrawCurr);
                        break;
                }
             
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetImages2Process(pnl_QueueImgs);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadCurrentTask(0, box_page1,2);
        }
        int Curr_txtfiled = 1;
        private void txt_field1_TextChanged(object sender, EventArgs e)
        {
           
          
            Curr_txtfiled = 1;
            box_page1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            box_page1 .Left = 200 ;
            box_page1 .Top = 50 ;
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            HelperClass.loginstate = false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pnl_displuPage.VerticalScroll.Value = 500;
            pnl_displuPage.HorizontalScroll.Value = 200;
        }

        private void txt_field2_Enter(object sender, EventArgs e)
        {
            Curr_txtfiled = 2;
            LoadCurrentTask(curtskindx, box_page1, 2);
            txt_field2.Focus();
        }

        private void txt_field3_Enter(object sender, EventArgs e)
        {
            Curr_txtfiled = 3;
            LoadCurrentTask(curtskindx, box_page1, 3);
        }

        private void txt_field2_TextChanged(object sender, EventArgs e)
        {
            Curr_txtfiled = 2;
            box_page1.Refresh();
        }

        private void txt_field3_TextChanged(object sender, EventArgs e)
        {
            Curr_txtfiled = 3;
            box_page1.Refresh();
        }

        private void txt_field1_Enter(object sender, EventArgs e)
        {
            Curr_txtfiled = 1;
            LoadCurrentTask(curtskindx, box_page1, 1);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (curtskindx < HelperClass.Lst_DocData .Count )
            {
                curtskindx += 1;
                LoadCurrentTask(curtskindx, box_page1, 1);
                txt_field1.Focus();
            }
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (curtskindx > 0)
            {
                curtskindx -= 1;
                LoadCurrentTask(curtskindx, box_page1, 1);
                txt_field1.Focus();
            }

        }

        private void txt_field1_Leave(object sender, EventArgs e)
        {
            if (txt_field1.Text .Length <=0 )
            {
               laberr.Text =("enter Filed data");
              //  txt_field1.Focus();
            }
        }

        private void txt_field2_Leave(object sender, EventArgs e)
        {
            if (txt_field2.Text.Length <= 0)
            {
                laberr.Text = ("enter Filed data");
               // txt_field2.Focus();
            }

        }

        private void txt_field3_Leave(object sender, EventArgs e)
        {
            if (txt_field3.Text.Length <= 0)
            {
                laberr.Text = ("enter Filed data");
               // txt_field3.Focus();
            }
        }


        private void SavedDocmentData()
        {
            try
            {
                SqlConnection MyConn = new SqlConnection(HelperClass.DbConnectionStr);
                string query = "UPDATE tbl_documents SET field1_data=@field1_data,field2_data=@field2_data,field3_data=@field3_data WHERE doc_id =" + HelperClass.Lst_DocData[curtskindx].doc_Id + "";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@field1_data", txt_field1.Text.Trim());
                cmd.Parameters.AddWithValue("@field2_data", txt_field2.Text.Trim());
                cmd.Parameters.AddWithValue("@field3_data", txt_field3.Text.Trim());
                cmd.Connection = MyConn;
                MyConn.Open();
                cmd.ExecuteNonQuery();
                MyConn.Close();
                MessageBox.Show("Document Data saved");

                txt_field1.Text = "";
                txt_field2.Text = "";
                txt_field3.Text = "";

                if (curtskindx < HelperClass.Lst_DocData.Count)
                {
                    curtskindx += 1;
                    LoadCurrentTask(curtskindx, box_page1, 1);
                    txt_field1.Focus();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SavedDocmentData();
         
        }

        private void txt_field3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                SavedDocmentData();
            }
        }
    }
}
