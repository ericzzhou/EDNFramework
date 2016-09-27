using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DotNet.Framework.JobDeploymentTool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public string InstancePath { get; set; }
        public string ServiceName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string InstanceNamespace { get; set; }
        private Dictionary<string, string> context = new Dictionary<string, string>();
        private void btnChooseInstancePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            InstancePath = path.SelectedPath;
            this.txtInstancePath.Text = InstancePath;

            if (!string.IsNullOrWhiteSpace(InstancePath))
            {
                ActivityDeployment();
            }

        }

        private void ActivityDeployment()
        {
            this.btnDeployment.Enabled = true;
            this.gbBase.Enabled = true;
            this.gbContextPanel.Enabled = true;
        }

        private bool CanDeployment()
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text) || string.IsNullOrWhiteSpace(txtInstanceNamespace.Text))
            {
                return false;
            }

            this.ServiceName = txtServiceName.Text;
            this.DisplayName = txtDisplayName.Text;
            this.Description = txtDescription.Text;
            this.InstanceNamespace = txtInstanceNamespace.Text;

            if (string.IsNullOrWhiteSpace(InstanceNamespace) || !this.InstanceNamespace.Contains(","))
            {
                return false;
            }

            var s = this.gvContext.DataSource;

            var dataRows = this.gvContext.Rows;
            if (dataRows != null && dataRows.Count > 0)
            {
                for (int i = 0; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Cells != null && dataRows[i].Cells.Count > 0 && !dataRows[i].IsNewRow)
                    {
                        string ContextName = dataRows[i].Cells["ContextName"].Value.ToString();
                        string ContextValue = dataRows[i].Cells["ContextValue"].Value.ToString();
                        if (!context.ContainsKey(ContextName) && !string.IsNullOrWhiteSpace(ContextName) && !string.IsNullOrWhiteSpace(ContextValue))
                        {
                            context.Add(ContextName, ContextValue);
                        }
                    }
                }
            }
            return true;
        }

        private void btnDeployment_Click(object sender, EventArgs e)
        {
            if (CanDeployment())
            {
                //修改 *.exe.config 文件名
                ModifyExeConfigName();

                //生成Install.bat he UnInstall.bat
                GenerateInstallBat();
                GenerateStartBat();
                //生成 setting.config 文件
                GenerateSettingConfig();

                //Copy 安装文件到目录
                CopyDeploymentFiles();

               
                //C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe
                MessageBox.Show("部署完成");
            }
        }

        private void GenerateStartBat()
        {
            string start = @"
@ECHO OFF

REM The following directory is for .NET 4.0
set DOTNETFX4=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX4%

net start ""{0}"" 
";

            string stop = @"
@ECHO OFF

REM The following directory is for .NET 4.0
set DOTNETFX4=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX4%

net stop ""{0}""
";

            start = string.Format(start, this.ServiceName);
            stop = string.Format(stop, this.ServiceName);

            SaveFile(start, "start.bat");
            SaveFile(stop, "stop.bat");
        }

        private void CopyDeploymentFiles()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\DeploymentFiles";
            string[] files = System.IO.Directory.GetFiles(filePath, "*");
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                File.Copy(file, this.InstancePath + "/" + fileName, true);
            }
        }

        private void GenerateInstallBat()
        {
            string install = @"
@ECHO OFF

REM The following directory is for .NET 4.0
set DOTNETFX4=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX4%

echo %~dp0
echo Installing {0}...
echo ---------------------------------------------------
InstallUtil.exe  %~dp0\DotNet.Framework.JobHost.exe
net start ""{0}"" 
echo ---------------------------------------------------
echo Done.
pause
";

            string unInstall = @"
@ECHO OFF
REM The following directory is for .NET 4.0
set DOTNETFX4=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX4%
echo %~dp0
echo UnInstalling {0}...
echo ---------------------------------------------------
net stop ""{0}""
InstallUtil.exe -u  %~dp0\DotNet.Framework.JobHost.exe
echo ---------------------------------------------------
echo Done.
pause
";

            install = string.Format(install, this.ServiceName);
            unInstall = string.Format(unInstall, this.ServiceName);

            SaveFile(install, "install.bat");
            SaveFile(unInstall, "uninstall.bat");
        }

        private void GenerateSettingConfig()
        {

            StringBuilder sbr = new StringBuilder();

            sbr.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sbr.AppendLine("<jobSetting>");
            sbr.AppendFormat("  <serviceName>{0}</serviceName>              ", this.ServiceName);
            sbr.AppendLine();
            sbr.AppendFormat("  <displayName>{0}</displayName>              ", this.DisplayName);
            sbr.AppendLine();
            sbr.AppendFormat("  <description>{0}</description>              ", this.Description);
            sbr.AppendLine();
            sbr.AppendFormat("  <instanceNamespace>{0}</instanceNamespace>  ", this.InstanceNamespace);
            sbr.AppendLine();
            foreach (var item in context)
            {
                sbr.AppendFormat("  <context name=\"{0}\" value=\"{1}\" />", item.Key, item.Value);
                sbr.AppendLine();
            }

            sbr.AppendLine("</jobSetting>");

            SaveFile(sbr.ToString(), "settings.config");
            //throw new NotImplementedException();
        }

        private void ModifyExeConfigName()
        {
            if (System.IO.File.Exists(InstancePath + "/app.config"))
            {
                string oldName = InstancePath + "/app.config";
                string newName = InstancePath + "/DotNet.Framework.JobHost.exe.config";
                System.IO.File.Move(oldName, newName);
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="fileName"></param>
        private void SaveFile(string fileContent, string fileName)
        {
            string filePath = this.InstancePath + "/" + fileName;
            //如果文件txt存在就打开，不存在就新建 .append 是追加写
            FileStream fst = new FileStream(filePath, FileMode.Create);
            //写数据到txt
            StreamWriter swt = new StreamWriter(fst, System.Text.Encoding.GetEncoding("utf-8"));
            //写入
            swt.WriteLine(fileContent);
            swt.Close();
            fst.Close();
        }
    }
}
