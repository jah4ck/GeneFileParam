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
            Trace MyTrace = new Trace(); 
            string codeappli = "GeneFileParam.exe";
            Object Guid = Registry.GetValue(@"HKEY_USERS\.DEFAULT\Software\CtrlPc\Version", "GUID", null);
            DateTime datetraitement = DateTime.Now;
            ReferenceWSCtrlPc.WSCtrlPc ws = new ReferenceWSCtrlPc.WSCtrlPc();

            //génération du planning
            try
            {
                datetraitement = DateTime.Now;
                MyTrace.WriteLog("Génération du planning.csv", 2, codeappli);
                string planning = ws.GetPlanning(Guid.ToString());
                StreamWriter write = new StreamWriter(@"C:\ProgramData\CtrlPc\PLANNING\Planning.csv");
                write.WriteLine(planning);
                write.Close();

            }
            catch (Exception err)
            {
                MyTrace.WriteLog("Erreur de génération du planning : => "+err.Message, 1, codeappli);
            }

            //génération du flag d'arrêt arr.flg
            try
            {
                datetraitement = DateTime.Now;
                MyTrace.WriteLog("Génération arr.flg", 2, codeappli);
                string arret = ws.GetArret(Guid.ToString());
                StreamWriter write = new StreamWriter(@"C:\ProgramData\CtrlPc\FLAG\arr.flg");
                write.WriteLine(arret);
                write.Close();

            }
            catch (Exception err) 
            {
                MyTrace.WriteLog("Erreur de génération du arr.flg => "+err.Message, 1, codeappli);
            }

            //génération du flag d'exception nfo.flg
            try
            {
                datetraitement = DateTime.Now;
                MyTrace.WriteLog("Génération du nfo.flg", 2, codeappli);
                string nfo = ws.GetException(Guid.ToString());
                StreamWriter write = new StreamWriter(@"C:\ProgramData\CtrlPc\FLAG\nfo.flg");
                write.WriteLine(nfo);
                write.Close();
            }
            catch (Exception err)
            {
                MyTrace.WriteLog("Erreude génération du nfo.flg => "+err.Message, 2, codeappli);
            }

            //génération du fichier RemLog.nfo
            try
            {

            }
            catch (Exception err)
            {

            }
            
        }
    }
}
