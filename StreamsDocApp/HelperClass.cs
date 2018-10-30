using StreamsDocApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


public class HelperClass
{



    // database connection string 
    public static string DbConnectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\db\Streamsdb.mdf;Integrated Security=True;Connect Timeout=30";
    public static string username = "";
    public static string userid="0";
    public static bool loginstate = false;

    public struct Document
    {
        public int doc_Id;
        public string doc_Path;
        public string Fld1_XYCrds;
        public string Fld2_XYCrds;
        public string Fld3_XYCrds;
        public string Fld1_data;
        public string Fld2_data;
        public string Fld3_data;
        public int doc_prosdstate;
        
    }
    public static List<Document> Lst_DocData = new List<Document >();
   

    // password 
    public static int[] ValidatePassword(string password)
    {
        
        int [] Chkpwrd = new int [4];
        if (password.Length < 8)
        {
            Chkpwrd[0] = 0;
        }
        else
        {
            Chkpwrd[0] = 1;
        }
        if (Regex.IsMatch(password , "[A-Z]"))
        {
            Chkpwrd[1] = 1;

        }
        else
        {
            Chkpwrd[1] = 0;
        }
        if (Regex.IsMatch(password, "[a-z]"))
        {
            Chkpwrd[2] = 1;

        }
        else
        {
            Chkpwrd[2] = 0;
        }

        if (Regex.IsMatch(password , @"\d"))
        {
            Chkpwrd[3] = 1;

        }
        else
        {
            Chkpwrd[3] = 0;
        }


        return Chkpwrd;


    }

    // check special Charaters
    public static bool HasSpecialChar(string input)
    {
        string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,* ";
        foreach (var item in specialChar)
        {
            if (input.Contains(item)) return true;
        }

        return false;
    }

    // Handel Email address
    public static bool emailIsValid(string email)
    {
        string expresion;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, string.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }


    // Center Form 
    public static  void CenterToScreen(Form frm)
    {
        Screen screen = Screen.FromControl(frm);

        Rectangle workingArea = screen.WorkingArea;
        frm.Location = new Point()
        {
            X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - frm.Width) / 2),
            Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - frm.Height) / 2)
        };
    }

    public static string Decrypt(string cipherText, string passPhrase)
    {
        string str;
        byte[] numArray = Convert.FromBase64String(cipherText);
        byte[] array = numArray.Take<byte>(32).ToArray<byte>();
        byte[] array1 = numArray.Skip<byte>(32).Take<byte>(32).ToArray<byte>();
        byte[] numArray1 = numArray.Skip<byte>(64).Take<byte>((int)numArray.Length - 64).ToArray<byte>();
        using (Rfc2898DeriveBytes rfc2898DeriveByte = new Rfc2898DeriveBytes(passPhrase, array, 1000))
        {
            byte[] bytes = rfc2898DeriveByte.GetBytes(32);
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.BlockSize = 256;
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Padding = PaddingMode.PKCS7;
                using (ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(bytes, array1))
                {
                    using (MemoryStream memoryStream = new MemoryStream(numArray1))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
                        {
                            byte[] numArray2 = new byte[(int)numArray1.Length];
                            int num = cryptoStream.Read(numArray2, 0, (int)numArray2.Length);
                            memoryStream.Close();
                            cryptoStream.Close();
                            str = Encoding.UTF8.GetString(numArray2, 0, num);
                        }
                    }
                }
            }
        }
        return str;
    }

    // Extract Pages from Tiff File 
    public static List<Image> GetAllPages(string file)
    {

        if (!File.Exists(file))
        {
            Image img = Resources.imgenone;
            List<Image> imagess = new List<Image>();
            imagess.Add(img);
            return imagess;
        }

            List<Image> images = new List<Image>();
            Bitmap bitmap = (Bitmap)Image.FromFile(file);
            int count = bitmap.GetFrameCount(FrameDimension.Page);
            for (int idx = 0; idx < count; idx++)
            {
                // save each frame to a bytestream
                bitmap.SelectActiveFrame(FrameDimension.Page, idx);
                MemoryStream byteStream = new MemoryStream();
                bitmap.Save(byteStream, ImageFormat.Tiff);

                // and then create a new Image from it
                images.Add(Image.FromStream(byteStream));
            }
            return images;
        }
    


    private static byte[] Generate256BitsOfRandomEntropy()
    {
        byte[] numArray = new byte[32];
        using (RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider())
        {
            rNGCryptoServiceProvider.GetBytes(numArray);
        }
        return numArray;
    }


    public static string Encrypt(string plainText, string passPhrase)
    {
        string base64String;
        byte[] numArray = Generate256BitsOfRandomEntropy();
        byte[] numArray1 = Generate256BitsOfRandomEntropy();
        byte[] bytes = Encoding.UTF8.GetBytes(plainText);
        using (Rfc2898DeriveBytes rfc2898DeriveByte = new Rfc2898DeriveBytes(passPhrase, numArray, 1000))
        {
            byte[] bytes1 = rfc2898DeriveByte.GetBytes(32);
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.BlockSize = 256;
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Padding = PaddingMode.PKCS7;
                using (ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(bytes1, numArray1))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(bytes, 0, (int)bytes.Length);
                            cryptoStream.FlushFinalBlock();
                            byte[] array = numArray.Concat<byte>(numArray1).ToArray<byte>();
                            array = array.Concat<byte>(memoryStream.ToArray()).ToArray<byte>();
                            memoryStream.Close();
                            cryptoStream.Close();
                            base64String = Convert.ToBase64String(array);
                        }
                    }
                }
            }
        }
        return base64String;
    }

}
