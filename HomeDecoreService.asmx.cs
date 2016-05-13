using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HomeDecoreServiceApp
{
    /// <summary>
    /// Summary description for HomeDecoreService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HomeDecoreService : System.Web.Services.WebService
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        [WebMethod]
        public DataSet BuyerLogin(string uname, string pass)
        {
            cmd = new SqlCommand("select * from  login where uname='" + uname + "' and pass='" + pass + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet SellerLogin(string uname, string pass)
        {
            cmd = new SqlCommand("select * from  sellerlogin where Uname='" + uname + "' and Password='" + pass + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet ViewIteminCart(string uname)
        {
            cmd = new SqlCommand("select  * from addcart WHERE uname = '" + uname + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet ViewSellecrAdDes(string adcat)
        {
            cmd = new SqlCommand("select  PostAd.adname,PostAd.txtadcategory,PostAd.txtdescription,PostAd.postimageview1,PostAd.txtamount from PostAd WHERE txtadcategory='" + adcat + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet AddSellerItem(string adcat)
        {
            cmd = new SqlCommand("select * from PostAd where txtadcategory='" + adcat + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet ViewAdAuctionad(string adname)
        {
            cmd = new SqlCommand("select AuctionAd.Adtitle,AuctionAd.Adname,AuctionAd.Addescription,AuctionAd.Auctionimageview1,AuctionAd.MinimumBid from AuctionAd where Adname='" + adname + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet AddSubItem(string adname)
        {
            cmd = new SqlCommand("select * from AuctionAd where Adname='" + adname + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet ViewProfile(string uname)
        {
            cmd = new SqlCommand("select   login.fname,login.lname,login.city,login.mobileno,login.Email,login.saddress1,login.saddress2,login.state,login.Pincode from login WHERE uname ='" + uname + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet UpdateSellerProfile(string uname)
        {
            cmd = new SqlCommand("select sellerlogin.Bname,sellerlogin.Btype,sellerlogin.Baddress,sellerlogin.Fname,sellerlogin.MobileNo,sellerlogin.Email  From sellerlogin WHERE uname ='" + uname + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet CheckUSerPass(string oldpass)
        {
            cmd = new SqlCommand("select   login.pass from login WHERE pass= '" + oldpass + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet CheckUSerLogin(string uname, string pass)
        {
            cmd = new SqlCommand("select login.uname,login.pass from  login where uname='" + uname + "' and pass='" + pass + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet VerifySecQues(string uname, string sq1, string sq2)
        {
            cmd = new SqlCommand("select * from  login where uname='" + uname + "' and sqa1='" + sq1 + "' and sqa2='" + sq2 + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public string ForgetPassword(string pass, string cpass, string uname)
        {
            cmd = new SqlCommand("update login set pass='" + pass + "',cpass='" + cpass + "' where login.uname='" + uname + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Success...";
        }

        [WebMethod]
        public string UpdateUserPassword(string pass, string cpass, string uname)
        {
            cmd = new SqlCommand("update login set pass='" + pass + "',cpass='" + cpass + "' where login.uname='" + uname + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Success...";
        }
        [WebMethod]
        public string AddAddUSer(string add1, string add2, string state, string city, string pincode, string uname)
        {
            cmd = new SqlCommand("update login set saddress1='" + add1 + "',saddress2='" + add2 + "',state='" + state + "',City='" + city + "',Pincode='" + pincode + "' where uname='" + uname + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Success...";
        }
        [WebMethod]
        public string DeleteUser(string uname)
        {
            cmd = new SqlCommand("Delete  from  login where uname='" + uname + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Success...";
        }
        [WebMethod]
        public string AddNewUser(string fname, string lname, string uname, string mobileno, string Email, string pass, string cpass, string sqa1, string sqa2)
        {
            cmd = new SqlCommand("insert into login(fname,lname,uname,mobileno,Email,pass,cpass,sqa1,sqa2) values('" + fname + "','" + lname + "','" + uname + "','" + mobileno + "','" + Email + "','" + pass + "','" + cpass + "','" + sqa1 + "','" + sqa2 + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Added...";
        }
        [WebMethod]
        public string AddNewSeller(string Bname, string Btype, string Baddress, string Fname, string Uname, string MobileNo, string Password, string ConfirmPassword)
        {
            cmd = new SqlCommand("insert into sellerlogin(Bname,Btype,Baddress,Fname,Uname,MobileNo,Email,Password,ConfirmPassword) values('" + Bname + "','" + Btype + "','" + Baddress + "','" + Fname + "','" + Uname + "','" + MobileNo + "','" + Password + "','" + ConfirmPassword + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Added...";
        }
        [WebMethod]
        public string PostSellerAdd(string adname, string txtadcategory, string txtdescription, string txtamount, string postimageview1)
        {
            cmd = new SqlCommand("insert into postad(adname,txtadcategory,txtdescription,txtamount,postimageview1) values('" + adname + "','" + txtadcategory + "','" + txtdescription + "','" + txtamount + "','" + postimageview1 + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Added...";
        }
        [WebMethod]
        public string AuctionAd(string Adtitle, string Adname, string txtdescription, string Auctionimageview1, string Minimumbid)
        {
            cmd = new SqlCommand("insert into AuctionAd(Adtitle,Adname,Addescription,Auctionimageview1,Minimumbid) values('" + Adtitle + "','" + Adname + "','" + txtdescription + "','" + Auctionimageview1 + "','" + Minimumbid + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Added...";
        }
        [WebMethod]
        public string AddtoCart(string adname, string txtadcategory, string txtdescription, string txtamount, string postimageview1, string uname)
        {
            cmd = new SqlCommand("insert into postad(adname,txtadcategory,txtdescription,txtamount,postimageview1,uname) values('" + adname + "','" + txtadcategory + "','" + txtdescription + "','" + txtamount + "','" + postimageview1 + "','" + uname + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Added...";
        }
        [WebMethod]
        public string UpdateBuyerProfile(string fname, string lname, string city, string mobno, string email, string sd1, string sd2, string state, string pincode)
        {
            cmd = new SqlCommand("update login set fname='" + fname + "',lname='" + lname + "',City='" + city + "',mobileno='" + mobno + "',Email='" + email + "',saddress1='" + sd1 + "',saddress2='" + sd2 + "',state='" + state + "',Pincode'" + pincode + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Updated...";
        }
    }
}
