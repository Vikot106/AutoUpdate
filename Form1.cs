using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace AutoUpdate {
    public partial class Form1 : Form {
        public string file = "";

        public Form1() {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选“HMCL.exe”";
            dialog.Filter = "HMCL Launcher(*.exe)|*.exe";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                this.file = dialog.FileName;
                textBox1.Text = this.file;
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            string path = "";
            if (this.file.Equals("")) {
                MessageBox.Show("你还没选择启动器文件路径呢");
            }else {
                var strArray = this.file.Split('\\');
                for(int i = 0; i < strArray.Length - 1; i++) {
                    path = path + strArray[i] + '\\';
                }
                string cfgPath = path + ".minecraft\\versions\\1.16.5\\CustomSkinLoader";
                string modPath = path + ".minecraft\\versions\\1.16.5\\mods";
                try {
                    if (File.Exists(cfgPath + "\\CustomSkinLoader.json")) {
                        File.Delete(cfgPath + "\\CustomSkinLoader.json");
                    }
                    byte[] buff1 = Properties.Resources.CustomSkinLoader;
                    File.WriteAllBytes(cfgPath + "\\CustomSkinLoader.json", buff1);
                    if (checkBox2.Checked) {
                        byte[] buff2 = Properties.Resources.XaerosWorldMap_1_11_11_2_Forge_1_16_5;
                        File.WriteAllBytes(modPath + "\\XaerosWorldMap_1.11.11.2_Forge_1.16.5.jar", buff2);
                    }
                    if (checkBox3.Checked) {
                        byte[] buff3 = Properties.Resources.inventoryprofiles_forge_1_16_2_0_4_2;
                        File.WriteAllBytes(modPath + "\\inventoryprofiles-forge-1.16.2-0.4.2.jar", buff3);
                    }
                    if (checkBox4.Checked) {
                        byte[] buff4 = Properties.Resources.forgeautofish_2_0_3_1_16_x;
                        File.WriteAllBytes(modPath + "\\forgeautofish-2.0.3-1.16.x.jar", buff4);
                    }
                    MessageBox.Show("更新完了 溜了");
                    System.Environment.Exit(0);
                }
                catch (Exception) {
                    MessageBox.Show("更新失败，请检查路径或文件占用情况");
                }
            }
        }
    }
}
