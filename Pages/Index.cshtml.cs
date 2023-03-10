using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;

namespace TriggerGradeType.Pages
{
   public class IndexModel : PageModel 
   {
      
      public void OnGet() 
      {
      }

      public void OnPostShowInformation()
      {
         using (OracleConnection con = new OracleConnection("User ID=cs306_avillyani;Password=StudyDatabaseWithDrSparks;Data Source=CSORACLE"))
         {
               con.Open();
               OracleCommand cmd = con.CreateCommand();
               cmd.CommandText = "SELECT * FROM GRADE_TYPE";
               OracleDataAdapter oda = new OracleDataAdapter(cmd);
               DataSet dt = new DataSet();
               oda.Fill(dt);
               ViewData["myStuff"] = dt.Tables[0];
         }
      }
   } 
} 