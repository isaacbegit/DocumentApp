using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace StreamsDocApp
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 

        /// </summary>
        /// 
       

        private void CLearAllFileds()
        {
            txt_firstName.Text = "";
            txt_lastName.Text = "";
            txt_userName.Text = "";
            txt_eMail.Text = "";
            txt_password.Text = "";
            txt_passwordconfirm.Text = "";
            pnl_checkpwrd.Hide();



        }

        private void btn_create_account_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection MyConn = new SqlConnection(HelperClass.DbConnectionStr);
                string sql = "INSERT INTO tbl_users(user_name,first_name,last_name,user_role,e_mail,password)" +
                        " VALUES(@user_name,@first_name,@last_name,@user_role,@e_mail,@password)";

                SqlCommand cmd = new SqlCommand(sql, MyConn);
                cmd.Parameters.Add("@user_name", SqlDbType.VarChar, 100).Value = txt_userName.Text.Trim();
                cmd.Parameters.Add("@first_name", SqlDbType.VarChar, 100).Value = txt_firstName.Text;
                cmd.Parameters.Add("@last_name", SqlDbType.VarChar, 100).Value = txt_lastName.Text;
                cmd.Parameters.Add("@e_mail", SqlDbType.VarChar, 100).Value = txt_eMail.Text;
                cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = 0;
                //encrypting password before storing int
                string Encrpt_password = HelperClass.Encrypt(txt_password.Text, "Stream&@paswrd");
                // store encryped password into database
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = Encrpt_password;
                 
                MyConn.Open();
                cmd.ExecuteNonQuery();
                MyConn.Close();
               
                signup_note.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Success;
                signup_note.Text = "Thank you for your registration. \n Your account ready to login now";
                signup_note.Show();
                // Clear all Fileds 
                CLearAllFileds();
            }catch (Exception ex)
            {
                signup_note.Show();
                signup_note.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error;
                signup_note.Text = ex.Message;
            }





        }

        private void txt_eMail_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_eMail_Leave(object sender, EventArgs e)
        {
            string currmail = txt_eMail.Text.Trim();
            if (HelperClass.emailIsValid(currmail ) == false)
            {
                
                txt_eMail.Focus();
                new_note.Top = txt_eMail.Top + txt_eMail.Height;
                new_note.Left = txt_eMail.Left;
                new_note.Text = "Enter valid E-mail address";
                new_note.Show();
            }
        }

        private void txt_eMail_TextChanged(object sender, EventArgs e)
        {
            new_note.Hide();
        }

        private void txt_userName_Leave(object sender, EventArgs e)
        {
            if (txt_userName.Text .Length <3)
            {
                txt_userName.Focus();
                new_note.Top = txt_userName.Top + txt_userName.Height;
                new_note.Left = txt_userName.Left;
                new_note.Text = "Enter suitable user name";
                new_note.Show();
                return;

            }

            string CurrUsername = txt_userName.Text.Trim();
            if (HelperClass . HasSpecialChar(CurrUsername )==true  )
            {
                
                txt_userName.Focus();
                
                new_note.Top = txt_userName .Top + txt_userName .Height;
                new_note.Left = txt_userName .Left;
                new_note.Text = "(No special characters or spaces)";
                new_note.Show();
                return;
            }

            SqlConnection MyConn = new SqlConnection(HelperClass.DbConnectionStr);
            string str_username = txt_userName.Text.Trim();
            SqlCommand cmd_username = new SqlCommand();
            cmd_username.CommandText = "SELECT COUNT(*) FROM tbl_users WHERE user_name='" + str_username + "'";
            cmd_username.Connection = MyConn;
            MyConn.Open();
            Int32 count = (Int32)cmd_username.ExecuteScalar();
            MyConn.Close();
            if (count != 0)
            {
                new_note.Show();
                new_note.Top = txt_userName.Top + txt_userName.Height;
                new_note.Left = txt_userName.Left;
                new_note.Text ="already exists,choose a different name";
                txt_userName.Focus();
            }


        }

        private void txt_userName_TextChanged(object sender, EventArgs e)
        {
            new_note.Hide();
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            pnl_checkpwrd.Show();
            string currpassword = txt_password.Text.Trim();
            int [] pwrdvalues = new int[3];
            pwrdvalues  = HelperClass.ValidatePassword(currpassword);
            if (pwrdvalues[0]==0)
            {
                con_8chars.Text = "✗ Not less than 8 characters";
                con_8chars.ForeColor = Color.Red ;
            }
            else
            {
                con_8chars.Text = "✔ Not less than 8 characters";
                con_8chars.ForeColor = Color.Lime;
            }
            //////////////////////////////
            if (pwrdvalues[1] == 0)
            {
                con_1uper.Text = "✗ Contains at least 1 uppercase";
                con_1uper.ForeColor = Color.Red;
            }
            else
            {
                con_1uper.Text = "✔ Contains at least 1 uppercase";
                con_1uper.ForeColor = Color.Lime;
            }
            /////////////////////
            if (pwrdvalues[2] == 0)
            {
                con_lowercase.Text = "✗ 1 Lower case letter";
                con_lowercase.ForeColor = Color.Red;
            }
            else
            {
                con_lowercase.Text = "✔ 1 Lower case letter";
                con_lowercase.ForeColor = Color.Lime;
            }
            /////////////////////////////////////
            if (pwrdvalues[3] == 0)
            {
                con_number.Text = "✗ 1 number";
                con_number.ForeColor = Color.Red;
            }
            else
            {
                con_number.Text = "✔ 1 number";
                con_number.ForeColor = Color.Lime;
            }


            int count = pwrdvalues[0] + pwrdvalues[1] + pwrdvalues[2] + pwrdvalues[3];
            if (count ==4)
            {
                pnl_checkpwrd.Hide();

            }
            
        }
        public string User_Name;
        public string Password;
        public string USerID;
        frm_main  Mfrm = new frm_main ();
        frm_dataEntry Dfrm = new frm_dataEntry();

        
        private void btn_login_Click(object sender, EventArgs e)
        {

            // login to system

          //  try
          //  {

                User_Name = txt_login_username.Text.Trim();
                Password = txt_login_password.Text.Trim();


                if (User_Name.Length == 0)
                {
                    login_notes.Text = "Please enter user name";
                    login_notes.ForeColor = Color.Red;
                    return;
                }

              

                string str_password = txt_login_password.Text;
                string Decrypted_password = HelperClass.Encrypt(str_password, "Stream&@paswrd");


                SqlConnection MyConn = new SqlConnection(HelperClass.DbConnectionStr );
                string comm = "SELECT user_id,password,first_name,user_role FROM tbl_users WHERE user_name='" +
                    User_Name.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(comm, MyConn);
                DataSet ds = new DataSet();
                login_notes.ForeColor = Color.Green;
                MyConn.Open();
                da.Fill(ds);
                

                MyConn.Close();

                if (ds.Tables[0].Rows.Count != 0)
                {
                    string Enrptpaword = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                    string Decryp_pwrd = HelperClass.Decrypt(Enrptpaword.Trim(), "Stream&@paswrd");

                    if (Decryp_pwrd == str_password)
                    {

                    USerID= ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    HelperClass.username = User_Name.ToString();
                    HelperClass.userid = USerID.ToString();
                    int userrole = Int32.Parse(ds.Tables[0].Rows[0].ItemArray[3].ToString().Trim());

                    switch (userrole)
                    {
                        case 0: // Normal User
                            Dfrm.themecontainer.Text = "Welcome " + ds.Tables[0].Rows[0].ItemArray[2].ToString();
                            Dfrm.ShowInTaskbar = true;
                            Dfrm.BringToFront();
                            Dfrm.Show();
                            HelperClass.loginstate = true;
                            timloginstate.Enabled = true;
                            break;
                        case 1: //Admin User
                            Mfrm.themecontainer.Text = "Welcome " + ds.Tables[0].Rows[0].ItemArray[2].ToString();
                            Mfrm.ShowInTaskbar = true;
                            Mfrm.BringToFront();
                            Mfrm.Show();
                            HelperClass.loginstate = true;
                            timloginstate.Enabled = true;
                            break;
                    }
                            this.Hide();
                    }
                    else

                {
                    login_notes.Show();
                    login_notes.Text = "Login Failed, please check your user name and password";

                }
            }
                else
                {
                    login_notes.Show();
                    login_notes.Text = "Login Failed, please check your user name and password";

                }
           // }
          //  catch (Exception ex)

           // {
              //  login_notes.Show();
              //  login_notes.Text = ex.Message ;
                
            //}

        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            HelperClass.CenterToScreen(this);
            labhint.Text = "For Test:"+Environment .NewLine +
                "user name: admin " + Environment.NewLine +
                "password: F4S48Oe2cC" + Environment.NewLine +  
                "user role : adminstration" + Environment.NewLine + 
                "--------------------------"+ Environment.NewLine +
                "user name: user"+ Environment.NewLine +
                "password: F4S48Oe2cC" + Environment.NewLine +
                "user role : Nrmal user";

        }

        private void txt_firstName_Leave(object sender, EventArgs e)
        {
            if (txt_firstName.Text .Length <=1)
            {
                txt_firstName.Focus();
                new_note.Text = "Enter suitable first name";
                new_note.Left = txt_firstName.Left;
                new_note.Top = txt_firstName.Top + txt_firstName.Height;
                new_note.Show();
            }
        }

        private void txt_firstName_TextChanged(object sender, EventArgs e)
        {
            new_note.Hide();
            
        }

        private void txt_lastName_Leave(object sender, EventArgs e)
        {
            if (txt_lastName.Text.Length <= 1)
            {
                txt_lastName.Focus();
                new_note.Text = "Enter suitable last name";
                new_note.Left = txt_lastName.Left;
                new_note.Top = txt_lastName.Top + txt_lastName.Height;
                new_note.Show();
            }
        }

        private void txt_lastName_TextChanged(object sender, EventArgs e)
        {
            new_note.Hide();
        }

        private void txt_password_Leave(object sender, EventArgs e)
        {
            if (pnl_checkpwrd.Visible ==true )
            {
                txt_password.Focus();
            }
        }

        private void txt_passwordconfirm_Leave(object sender, EventArgs e)
        {

            string strpwrd = txt_password.Text;
            string strpwdConfrm = txt_passwordconfirm.Text;
            if (!(strpwrd ==strpwdConfrm))
            {
                txt_passwordconfirm.Focus();
                new_note.Text = "password did not match";
                new_note.Left = txt_passwordconfirm .Left;
                new_note.Top = txt_passwordconfirm.Top + txt_passwordconfirm.Height;
                new_note.Show();

            }

        }

        private void txt_passwordconfirm_TextChanged(object sender, EventArgs e)
        {
            new_note.Hide();
        }

        private void txt_login_username_TextChanged(object sender, EventArgs e)
        {
            login_notes.Hide();
        }

        private void txt_login_password_TextChanged(object sender, EventArgs e)
        {
            login_notes.Hide();
        }

        private void timloginstate_Tick(object sender, EventArgs e)
        {
            if (HelperClass.loginstate ==false )
            {
                this.Show();
                timloginstate.Enabled = false;
            }
        }
    }
}
