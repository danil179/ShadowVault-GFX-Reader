namespace GFXViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Load File...");
            this.pb_color = new System.Windows.Forms.PictureBox();
            this.btn_run = new System.Windows.Forms.Button();
            this.ofd_GFX = new System.Windows.Forms.OpenFileDialog();
            this.nmric_frameNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cod_BGColor = new System.Windows.Forms.ColorDialog();
            this.btn_changeBGColor = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tv_files = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_hnum = new System.Windows.Forms.Label();
            this.lbl_wnum = new System.Windows.Forms.Label();
            this.lbl_fnum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stat_mes = new System.Windows.Forms.StatusStrip();
            this.stat_lbl_type = new System.Windows.Forms.ToolStripStatusLabel();
            this.stat_lbl_message = new System.Windows.Forms.ToolStripStatusLabel();
            this.cms_pic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmi_save = new System.Windows.Forms.ToolStripMenuItem();
            this.sfd_pic = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmric_frameNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.stat_mes.SuspendLayout();
            this.cms_pic.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_color
            // 
            this.pb_color.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pb_color.Location = new System.Drawing.Point(3, 3);
            this.pb_color.Name = "pb_color";
            this.pb_color.Size = new System.Drawing.Size(261, 366);
            this.pb_color.TabIndex = 0;
            this.pb_color.TabStop = false;
            this.pb_color.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_color_MouseDown);
            // 
            // btn_run
            // 
            this.btn_run.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_run.Location = new System.Drawing.Point(6, 52);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(346, 46);
            this.btn_run.TabIndex = 2;
            this.btn_run.Text = "Load GFX/GXL File...";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // ofd_GFX
            // 
            this.ofd_GFX.Filter = "GFX Files (*.gfx) |*.gfx|GFXL Files (*.gxl) |*.gxl| All files |*.*";
            this.ofd_GFX.FilterIndex = 2;
            // 
            // nmric_frameNumber
            // 
            this.nmric_frameNumber.Enabled = false;
            this.nmric_frameNumber.Location = new System.Drawing.Point(232, 107);
            this.nmric_frameNumber.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nmric_frameNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmric_frameNumber.Name = "nmric_frameNumber";
            this.nmric_frameNumber.Size = new System.Drawing.Size(120, 20);
            this.nmric_frameNumber.TabIndex = 3;
            this.nmric_frameNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmric_frameNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmric_frameNumber.ValueChanged += new System.EventHandler(this.nmric_frameNumber_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(109, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Frame number:";
            // 
            // btn_changeBGColor
            // 
            this.btn_changeBGColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_changeBGColor.Location = new System.Drawing.Point(6, 214);
            this.btn_changeBGColor.Name = "btn_changeBGColor";
            this.btn_changeBGColor.Size = new System.Drawing.Size(346, 45);
            this.btn_changeBGColor.TabIndex = 5;
            this.btn_changeBGColor.Text = "Change Image Background Color";
            this.btn_changeBGColor.UseVisualStyleBackColor = true;
            this.btn_changeBGColor.Click += new System.EventHandler(this.btn_changeBGColor_Click);
            // 
            // btn_play
            // 
            this.btn_play.Enabled = false;
            this.btn_play.Location = new System.Drawing.Point(6, 104);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(97, 23);
            this.btn_play.TabIndex = 6;
            this.btn_play.Text = "Play Animation";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv_files);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1664, 535);
            this.splitContainer1.SplitterDistance = 133;
            this.splitContainer1.TabIndex = 9;
            // 
            // tv_files
            // 
            this.tv_files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_files.Location = new System.Drawing.Point(0, 0);
            this.tv_files.Name = "tv_files";
            treeNode1.Name = "FileRoot";
            treeNode1.Text = "Load File...";
            this.tv_files.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tv_files.Size = new System.Drawing.Size(133, 535);
            this.tv_files.TabIndex = 0;
            this.tv_files.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_files_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pb_color);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1159, 535);
            this.panel1.TabIndex = 10;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btn_run);
            this.groupBox1.Controls.Add(this.nmric_frameNumber);
            this.groupBox1.Controls.Add(this.btn_changeBGColor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_play);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(1159, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 535);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(148, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "(C) Danil179/ Dniel888";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_hnum);
            this.groupBox2.Controls.Add(this.lbl_wnum);
            this.groupBox2.Controls.Add(this.lbl_fnum);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 75);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // lbl_hnum
            // 
            this.lbl_hnum.Location = new System.Drawing.Point(208, 53);
            this.lbl_hnum.Name = "lbl_hnum";
            this.lbl_hnum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_hnum.Size = new System.Drawing.Size(130, 13);
            this.lbl_hnum.TabIndex = 5;
            this.lbl_hnum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_wnum
            // 
            this.lbl_wnum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_wnum.Location = new System.Drawing.Point(208, 36);
            this.lbl_wnum.Name = "lbl_wnum";
            this.lbl_wnum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_wnum.Size = new System.Drawing.Size(130, 13);
            this.lbl_wnum.TabIndex = 4;
            this.lbl_wnum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_fnum
            // 
            this.lbl_fnum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_fnum.Location = new System.Drawing.Point(208, 16);
            this.lbl_fnum.Name = "lbl_fnum";
            this.lbl_fnum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_fnum.Size = new System.Drawing.Size(130, 13);
            this.lbl_fnum.TabIndex = 3;
            this.lbl_fnum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Height : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Width : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Frames number : ";
            // 
            // stat_mes
            // 
            this.stat_mes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stat_lbl_type,
            this.stat_lbl_message});
            this.stat_mes.Location = new System.Drawing.Point(0, 538);
            this.stat_mes.Name = "stat_mes";
            this.stat_mes.Size = new System.Drawing.Size(1664, 22);
            this.stat_mes.TabIndex = 10;
            this.stat_mes.Text = "statusStrip1";
            // 
            // stat_lbl_type
            // 
            this.stat_lbl_type.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.stat_lbl_type.Name = "stat_lbl_type";
            this.stat_lbl_type.Size = new System.Drawing.Size(0, 17);
            // 
            // stat_lbl_message
            // 
            this.stat_lbl_message.Name = "stat_lbl_message";
            this.stat_lbl_message.Size = new System.Drawing.Size(0, 17);
            // 
            // cms_pic
            // 
            this.cms_pic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmi_save});
            this.cms_pic.Name = "cms_pic";
            this.cms_pic.Size = new System.Drawing.Size(135, 26);
            // 
            // cmi_save
            // 
            this.cmi_save.Name = "cmi_save";
            this.cmi_save.Size = new System.Drawing.Size(134, 22);
            this.cmi_save.Text = "Save Image";
            this.cmi_save.Click += new System.EventHandler(this.cmi_save_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 560);
            this.Controls.Add(this.stat_mes);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "GFX viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmric_frameNumber)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.stat_mes.ResumeLayout(false);
            this.stat_mes.PerformLayout();
            this.cms_pic.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_color;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.OpenFileDialog ofd_GFX;
        private System.Windows.Forms.NumericUpDown nmric_frameNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog cod_BGColor;
        private System.Windows.Forms.Button btn_changeBGColor;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tv_files;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip stat_mes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_wnum;
        private System.Windows.Forms.Label lbl_fnum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_hnum;
        private System.Windows.Forms.ToolStripStatusLabel stat_lbl_type;
        private System.Windows.Forms.ToolStripStatusLabel stat_lbl_message;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cms_pic;
        private System.Windows.Forms.ToolStripMenuItem cmi_save;
        private System.Windows.Forms.SaveFileDialog sfd_pic;
    }
}

