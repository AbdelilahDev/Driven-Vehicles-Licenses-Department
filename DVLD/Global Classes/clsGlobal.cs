using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using Microsoft.Win32;


namespace DVLD.Classes
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;
       static string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD App";
        static string ValueUserName = @"UserName";
        static string ValuePassword = @"Password";



        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
           

       


            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, ValueUserName, Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, ValuePassword, Password, RegistryValueKind.String);



                return true;
            }
            catch (Exception ex)
            {
                return false;
            }








        } 
    

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD App";
            

            try
            {
                
                // Read the value from the Registry
                Password = Registry.GetValue(keyPath, ValuePassword, null) as string;
                Username = Registry.GetValue(keyPath, ValueUserName, null) as string;



                if (Password != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               

            }
            catch (Exception ex)
            {
                return false;
            }




           

        }


        public static void SaveToEventLog(string Message,EventLogEntryType LogType,string SourceName="DVLD")
        {

            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }
            EventLog.WriteEntry(SourceName, Message, LogType);
        }
   
    
    
    
    }
}
