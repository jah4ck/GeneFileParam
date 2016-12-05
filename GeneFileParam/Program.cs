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

            //génération du planning
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
                string NameDate = datetraitement.ToString("yyyyMMdd");
                string Date = datetraitement.ToString("dd/MM/yyyy HH:mm:ss");
                using (StreamWriter writer = File.AppendText(@"C:\ProgramData\CtrlPc\LOG\JOURNAL_ERREUR_" + NameDate + ".log"))
                {
                    writer.WriteLine(Date + "     " + codeappli + "     " + "ERREUR : " + err.Message);
                }
            }

            //génération du flag d'arrêt arr.flg
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
                string NameDate = datetraitement.ToString("yyyyMMdd");
                string Date = datetraitement.ToString("dd/MM/yyyy HH:mm:ss");
                using (StreamWriter writer = File.AppendText(@"C:\ProgramData\CtrlPc\LOG\JOURNAL_ERREUR_" + NameDate + ".log"))
                {
                    writer.WriteLine(Date + "     " + codeappli + "     " + "ERREUR : " + err.Message);
                }
            }

            //génération du flag d'exception nfo.flg
            try
            {
                datetraitement = DateTime.Now;
                ws.TraceLog(Guid.ToString(), datetraitement, codeappli, 2, "Génération du nfo.flg");
                string nfo = ws.GetException(Guid.ToString());
                StreamWriter write = new StreamWriter(@"C:\ProgramData\CtrlPc\FLAG\nfo.flg");
                write.WriteLine(nfo);
                write.Close();
            }
            catch (Exception err)
            {
                datetraitement = DateTime.Now;
                string NameDate = datetraitement.ToString("yyyyMMdd");
                string Date = datetraitement.ToString("dd/MM/yyyy HH:mm:ss");
                using (StreamWriter writer = File.AppendText(@"C:\ProgramData\CtrlPc\LOG\JOURNAL_ERREUR_" + NameDate + ".log"))
                {
                    writer.WriteLine(Date + "     " + codeappli + "     " + "ERREUR : " + err.Message);
                }
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
