/*
 * created by dniel888 from XeNTaX
 * (C) dniel888
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;

namespace GFXViewer
{
    public partial class Form1 : Form
    {
        GFX curGfx;
        AUDX curAUDX;
        GFXL lib;
        BCKG curBackground;
        AUDL aulib;
        bool play = false;
        WaveOut waveOut = new WaveOut(); // or WaveOutEvent()

        public Form1()
        {
            InitializeComponent();
        }
        public Byte[] ConvertStringToHex(string asciiString)
        {
            Byte[] res = new Byte[asciiString.Length / 2];
            for (int i = 0; i < res.Length; ++i)
            {
                res[i] = Convert.ToByte(asciiString.Substring(i * 2, 2), 16);
            }
            return res;
        }
        private void Wait(int days, int hours, int minutes, int seconds, int miliseconds)
        {
            DateTime req = DateTime.Now;
            req = req.AddMilliseconds(miliseconds);
            req = req.AddSeconds(seconds);
            req = req.AddMinutes(minutes);
            req = req.AddHours(hours);
            req = req.AddDays(days);
            while (DateTime.Now < req)
            {
                Application.DoEvents();
            }
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            if (ofd_GFX.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(ofd_GFX.FileName);
                if (ext == ".gfx")
                {
                    stat_lbl_type.Text = "Information : ";
                    stat_lbl_message.Text = "GFX Loading (" + Path.GetFileName(ofd_GFX.FileName) + ") ...";
                    Wait(0, 0, 0, 0, 10);

                    curGfx = new GFX(ofd_GFX.FileName);

                    stat_lbl_message.Text = "GFX Processing (" + Path.GetFileName(ofd_GFX.FileName) + ") ...";
                    Wait(0, 0, 0, 0, 10);

                    ShowGFX(curGfx);

                    stat_lbl_message.Text = "GFX loaded (" + Path.GetFileName(ofd_GFX.FileName) + ") and processed successfully !";
                }
                else if (ext == ".gxl")
                {
                    stat_lbl_type.Text = "Information : ";
                    stat_lbl_message.Text = "GXL Loading (" + Path.GetFileName(ofd_GFX.FileName) + ") ...";
                    Wait(0, 0, 0, 0, 10);

                    lib = new GFXL(ofd_GFX.FileName);

                    stat_lbl_message.Text = "Files tree updating (" + Path.GetFileName(ofd_GFX.FileName) + ") ...";
                    Wait(0, 0, 0, 0, 10);

                    tv_files.Nodes[0].Nodes.Clear();
                    tv_files.Nodes[0].Text = Path.GetFileName(ofd_GFX.FileName);
                    for (int i = 0; i < lib.FilesNum; ++i)
                    {
                        tv_files.Nodes[0].Nodes.Add(lib.FilesTree[i].ID.ToString());
                    }

                    stat_lbl_message.Text = "GXL loaded (" + Path.GetFileName(ofd_GFX.FileName) + ") and processed successfully !";
                }
                else if (ext == ".axl")
                {
                    stat_lbl_type.Text = "Information : ";
                    stat_lbl_message.Text = "AXL Loading (" + Path.GetFileName(ofd_GFX.FileName) + ") ...";
                    Wait(0, 0, 0, 0, 10);

                    aulib = new AUDL(ofd_GFX.FileName);

                    stat_lbl_message.Text = "Files tree updating (" + Path.GetFileName(ofd_GFX.FileName) + ") ...";
                    Wait(0, 0, 0, 0, 10);

                    tv_files.Nodes[0].Nodes.Clear();
                    tv_files.Nodes[0].Text = Path.GetFileName(ofd_GFX.FileName);
                    for (int i = 0; i <aulib.FilesNum; ++i)
                    {
                        tv_files.Nodes[0].Nodes.Add(aulib.FilesTree[i].ID.ToString());
                    }

                    stat_lbl_message.Text = "AXL loaded (" + Path.GetFileName(ofd_GFX.FileName) + ") and processed successfully !";
                }
                else if (ext == ".bck")
                {
                    stat_lbl_type.Text = "Information : ";
                    stat_lbl_message.Text = "BCKG Loading (" + Path.GetFileName(ofd_GFX.FileName) + ") ...";
                    Wait(0, 0, 0, 0, 10);

                    curBackground = new BCKG(ofd_GFX.FileName);

                    stat_lbl_message.Text = "Files tree updating (" + Path.GetFileName(ofd_GFX.FileName) + ") ...";
                    Wait(0, 0, 0, 0, 10);

                    tv_files.Nodes[0].Nodes.Clear();
                    tv_files.Nodes[0].Text = Path.GetFileName(ofd_GFX.FileName);
                    for (int i = 0; i < curBackground.TileMapHeight; ++i)
                    {
                        for (int j = 0; j < curBackground.TileMapWidth; ++j)
                        {
                            tv_files.Nodes[0].Nodes.Add(i + " : " + j);
                        }
                    }
                }
            }
        }

        private void nmric_frameNumber_ValueChanged(object sender, EventArgs e)
        {
            pb_color.Image = curGfx.GFXImage[(int)nmric_frameNumber.Value - 1];
        }

        private void btn_changeBGColor_Click(object sender, EventArgs e)
        {
            if (cod_BGColor.ShowDialog() == DialogResult.OK)
            {
                pb_color.BackColor = cod_BGColor.Color;
                this.BackColor = cod_BGColor.Color;
            }
        }
        private void ShowGFX(GFX gfx)
        {
            pb_color.Width = gfx.Width;
            pb_color.Height = gfx.Height;
            pb_color.Image = gfx.GFXImage[0];

            nmric_frameNumber.Value = 1;
            nmric_frameNumber.Maximum = gfx.FramesNumber;
            nmric_frameNumber.Enabled = true;

            btn_play.Enabled = true;
            play = false;

            lbl_fnum.Text = curGfx.FramesNumber.ToString();
            lbl_wnum.Text = curGfx.Width.ToString();
            lbl_hnum.Text = curGfx.Height.ToString();
        }
        private void btn_play_Click(object sender, EventArgs e)
        {
            play = !play;
            while (play)
            {
                nmric_frameNumber.Value = 1 + (nmric_frameNumber.Value % nmric_frameNumber.Maximum);
                pb_color.Image = curGfx.GFXImage[(int)nmric_frameNumber.Value - 1];
                Wait(0, 0, 0, 0, 100);
            }
        }

        private void tv_files_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0 && e.Node.Level > 0)
            {
                stat_lbl_type.Text = "Information : ";
                if (Path.GetExtension(e.Node.Parent.Text) == ".axl")
                {
                    waveOut.Stop();
                    var curSelected = aulib.FilesTree[e.Node.Index];
                    if (curSelected.fileType == 1)
                    { 
                        curAUDX = new AUDX(aulib.GetBytes(curSelected.offset, curSelected.size));
                        waveOut.Init(new WaveFileReader(new MemoryStream(curAUDX.data)));
                    }
                    else if (curSelected.fileType == 2)
                    {
                        var freader = new Mp3FileReader(new MemoryStream(aulib.GetBytes(curSelected.offset+0x272, curSelected.size)));
                        waveOut.Init(freader);
                    }
                    waveOut.Play();
                    return;
                }



                stat_lbl_message.Text = "GFX Loading (" + e.Node.Text + ") ...";
                Wait(0, 0, 0, 0, 10);
                if (Path.GetExtension(e.Node.Parent.Text) == ".gxl")
                {
                    curGfx = new GFX(lib.GetBytes(lib.FilesTree[e.Node.Index].offset, lib.FilesTree[e.Node.Index].size));
                }
                else if (Path.GetExtension(e.Node.Parent.Text) == ".bck")
                {
                    curGfx = new GFX(curBackground.GetBytes(e.Node.Index * 0xC834 + 0x14, 0xC834));
                }
                stat_lbl_message.Text = "GFX Processing (" + e.Node.Text + ") ...";
                Wait(0, 0, 0, 0, 10);
                ShowGFX(curGfx);
                stat_lbl_message.Text = "GFX loaded (" + e.Node.Text + ") and processed successfully !";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pb_color_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && pb_color.Image != null && pb_color.Image != null)
            {
                Point pt = PointToScreen(e.Location);
                cms_pic.Show(pt);
            }
        }

        private void cmi_save_Click(object sender, EventArgs e)
        {
            if (curGfx.FramesNumber == 1)
            {
                sfd_pic.FileName = curGfx.ID + ".png";
            }
            else
            {
                sfd_pic.FileName = curGfx.ID + "_" + nmric_frameNumber.Value + ".png";
            }
            if (sfd_pic.ShowDialog() == DialogResult.OK)
            {
                pb_color.Image.Save(sfd_pic.OpenFile(), System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            String filename = ((String[])e.Data.GetData(DataFormats.FileDrop))[0];
            string ext = Path.GetExtension(filename);
            if (ext == ".gxl")
            {
                stat_lbl_type.Text = "Information : ";
                stat_lbl_message.Text = "GXL Loading (" + Path.GetFileName(filename) + ") ...";
                Wait(0, 0, 0, 0, 10);

                lib = new GFXL(filename);

                stat_lbl_message.Text = "Files tree updating (" + Path.GetFileName(filename) + ") ...";
                Wait(0, 0, 0, 0, 10);

                tv_files.Nodes[0].Nodes.Clear();
                tv_files.Nodes[0].Text = Path.GetFileName(filename);
                for (int i = 0; i < lib.FilesNum; ++i)
                {
                    tv_files.Nodes[0].Nodes.Add(lib.FilesTree[i].ID.ToString());
                }

                stat_lbl_message.Text = "GXL loaded (" + Path.GetFileName(filename) + ") and processed successfully !";
            }
        }
    }
}
