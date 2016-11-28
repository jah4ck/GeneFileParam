using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeneFileParam
{
    class Program
    {
        static void Main(string[] args)
        {
            string codeappli = "GeneFileParam.exe";
            Object Guid = Registry.GetValue(@"HKEY_USERS\.DEFAULT\Software\CtrlPc\Version", "GUID", null);
            DateTime datetraitement = DateTime.Now;
            ReferenceWSCtrlPc.WSCtrlPc ws = new ReferenceWSCtrlPc.WSCtrlPc();
            try
            {
                datetraitement = DateTime.Now;
                ws.TraceLog(Guid.ToString(), datetraitement, codeappli, 2, "Génération du planning.csv");
                string planning = ws.GetPlanning(Guid.ToString());
                StreamWriter write = new StreamWriter(@"C:\ProgramData\CtrlPc\PLANNING\Planning.csv");
                write.WriteLine(planning);
                write.Close();

            }
            catch (Exception err)
            {
                datetraitement = DateTime.Now;
                ws.TraceLog(Guid.ToString(), datetraitement, codeappli, 1,"Erreur lors de la génération de Planning.csv --> "+ err.Message);

                
            }
            try
            {
                datetraitement = DateTime.Now;
                ws.TraceLog(Guid.ToString(), datetraitement, codeappli, 2, "Génération du arr.flg");
                string arret = ws.GetArret(Guid.ToString());
                StreamWriter write = new StreamWriter(@"C:\ProgramData\CtrlPc\FLAG\arr.flg");
                write.WriteLine(arret);
                write.Close();

            }
            catch (Exception err) 
            {
                datetraitement = DateTime.Now;
                ws.TraceLog(Guid.ToString(), datetraitement, codeappli, 1, "Erreur lors de la génération du arr.flg -->"+err.Message);
            }
            
        }
    }
}
