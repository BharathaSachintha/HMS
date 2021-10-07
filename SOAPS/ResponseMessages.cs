using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS
{
    public class ResponseMessages
    {
        public static string InsertSuccess { get { return "Record Successfully Inserted."; } }

        public static string UpdateSuccess { get { return "Record Successfully Updated."; } }

        public static string DeleteSuccess { get { return "Record Successfully Deleted."; } }

        public static string NoData { get { return "No Record(s) Available."; } }

        public static string PasswordResetSuccess { get { return "Password Successfully Resetted."; } }

        public static string AlreadyExists { get { return "Record Already Exists"; } }

        public static string Error { get { return "Error Occured..Please Try Again"; } }

        public static string NewUser { get { return "New User Added.."; } }

        public static string Payment { get { return "Payment Succesfull"; } }
    }
}