//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;

//namespace BudgetManagementApp.Data
//{
//  class DbBackupRestore
//  {

//    private void Backup()
//    {
     
//        string file;
//        sfd.Filter = "SQL Dump File (*.sql)|*.sql|All files (*.*)|*.*";
//        sfd.FileName = "Database Backup " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".sql";
//        if (sfd.ShowDialog == DialogResult.OK)
//        {
//          file = sfd.FileName;
//          var myProcess = new Process();
//          myProcess.StartInfo.FileName = "cmd.exe";
//          myProcess.StartInfo.UseShellExecute = false;
//          myProcess.StartInfo.WorkingDirectory = @"C:\Program Files\MySQL\MySQL Server 5.1\bin\";
//          myProcess.StartInfo.RedirectStandardInput = true;
//          myProcess.StartInfo.RedirectStandardOutput = true;
//          myProcess.Start();
//          var myStreamWriter = myProcess.StandardInput;
//          var mystreamreader = myProcess.StandardOutput;
//          myStreamWriter.WriteLine("mysqldump -u root --password=yourpassword -h 192.168.1.201 \"databasename\" > \"" + file + "\" ");
//          myStreamWriter.Close();
//          myProcess.WaitForExit();
//          myProcess.Close();
//          MsgBox("Backup Created Successfully!", MsgBoxStyle.Information, "Backup");
//        }
      

//    }

//    private void Restore()
//    {

//        string file;
//        opd.Filter = "SQL Dump File (*.sql)|*.sql|All files (*.*)|*.*";
//        if (opd.ShowDialog == DialogResult.OK)
//        {
//          file = opd.FileName;
//          var myProcess = new Process();
//          myProcess.StartInfo.FileName = "cmd.exe";
//          myProcess.StartInfo.UseShellExecute = false;
//          myProcess.StartInfo.WorkingDirectory = @"C:\Program Files\MySQL\MySQL Server 5.1\bin\";
//          myProcess.StartInfo.RedirectStandardInput = true;
//          myProcess.StartInfo.RedirectStandardOutput = true;
//          myProcess.Start();
//          var myStreamWriter = myProcess.StandardInput;
//          var mystreamreader = myProcess.StandardOutput;
//          myStreamWriter.WriteLine("mysql -u root --password=yourpassword -h 192.168.1.201 \"databasename\" < \"" + file + "\" ");
//          myStreamWriter.Close();
//          myProcess.WaitForExit();
//          myProcess.Close();
//          MsgBox("Database Restoration Successfully!", MsgBoxStyle.Information, "Restore");
//        }
      

//    }
//  }
//}
