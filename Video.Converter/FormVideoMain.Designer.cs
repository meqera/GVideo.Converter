namespace Video.Converter
{
    partial class FormVideoMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVideoMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.VideoThemeContainer = new Ambiance_ThemeContainer();
            this.ambiance_Label1 = new Ambiance_Label();
            this.VideoButtonConvert = new Ambiance_Button_2();
            this.VideoLabelTargetFolder = new Ambiance_Label();
            this.VideoLabelProcessingOn = new Ambiance_Label();
            this.VideoProgressBarConvert = new Ambiance_ProgressBar();
            this.VideoLabelVideoProgress = new Ambiance_Label();
            this.VideoProgressBarOverall = new Ambiance_ProgressBar();
            this.VideoLabelOverallProgress = new Ambiance_Label();
            this.VideoTrackBar = new Ambiance_TrackBar();
            this.VideoLabelQuality = new Ambiance_Label();
            this.pictureBoxThumbnail = new System.Windows.Forms.PictureBox();
            this.VideoLabelThumbnail = new Ambiance_Label();
            this.VideoSeperatorLine = new Ambiance_Separator();
            this.VideoLabelCount = new Ambiance_Label();
            this.VideoButtonClear = new Ambiance_Button_2();
            this.VideoButtonAdd = new Ambiance_Button_2();
            this.VideoButtonDestination = new Ambiance_Button_2();
            this.dataGridViewFiles = new System.Windows.Forms.DataGridView();
            this.VideoLabelHeader = new Ambiance_Label();
            this.VideoControlBox = new Ambiance_ControlBox();
            this.VideoThemeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoThemeContainer
            // 
            this.VideoThemeContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.VideoThemeContainer.Controls.Add(this.ambiance_Label1);
            this.VideoThemeContainer.Controls.Add(this.VideoButtonConvert);
            this.VideoThemeContainer.Controls.Add(this.VideoLabelTargetFolder);
            this.VideoThemeContainer.Controls.Add(this.VideoLabelProcessingOn);
            this.VideoThemeContainer.Controls.Add(this.VideoProgressBarConvert);
            this.VideoThemeContainer.Controls.Add(this.VideoLabelVideoProgress);
            this.VideoThemeContainer.Controls.Add(this.VideoProgressBarOverall);
            this.VideoThemeContainer.Controls.Add(this.VideoLabelOverallProgress);
            this.VideoThemeContainer.Controls.Add(this.VideoTrackBar);
            this.VideoThemeContainer.Controls.Add(this.VideoLabelQuality);
            this.VideoThemeContainer.Controls.Add(this.pictureBoxThumbnail);
            this.VideoThemeContainer.Controls.Add(this.VideoLabelThumbnail);
            this.VideoThemeContainer.Controls.Add(this.VideoSeperatorLine);
            this.VideoThemeContainer.Controls.Add(this.VideoLabelCount);
            this.VideoThemeContainer.Controls.Add(this.VideoButtonClear);
            this.VideoThemeContainer.Controls.Add(this.VideoButtonAdd);
            this.VideoThemeContainer.Controls.Add(this.VideoButtonDestination);
            this.VideoThemeContainer.Controls.Add(this.dataGridViewFiles);
            this.VideoThemeContainer.Controls.Add(this.VideoLabelHeader);
            this.VideoThemeContainer.Controls.Add(this.VideoControlBox);
            resources.ApplyResources(this.VideoThemeContainer, "VideoThemeContainer");
            this.VideoThemeContainer.Name = "VideoThemeContainer";
            this.VideoThemeContainer.RoundCorners = true;
            this.VideoThemeContainer.Sizable = true;
            this.VideoThemeContainer.SmartBounds = true;
            this.VideoThemeContainer.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            // 
            // ambiance_Label1
            // 
            resources.ApplyResources(this.ambiance_Label1, "ambiance_Label1");
            this.ambiance_Label1.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label1.ForeColor = System.Drawing.Color.Silver;
            this.ambiance_Label1.Name = "ambiance_Label1";
            this.ambiance_Label1.Click += new System.EventHandler(this.ambiance_Label1_Click);
            // 
            // VideoButtonConvert
            // 
            this.VideoButtonConvert.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.VideoButtonConvert, "VideoButtonConvert");
            this.VideoButtonConvert.Image = null;
            this.VideoButtonConvert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VideoButtonConvert.Name = "VideoButtonConvert";
            this.VideoButtonConvert.TextAlignment = System.Drawing.StringAlignment.Center;
            this.VideoButtonConvert.Click += new System.EventHandler(this.VideoButtonConvert_Click);
            // 
            // VideoLabelTargetFolder
            // 
            resources.ApplyResources(this.VideoLabelTargetFolder, "VideoLabelTargetFolder");
            this.VideoLabelTargetFolder.BackColor = System.Drawing.Color.Transparent;
            this.VideoLabelTargetFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.VideoLabelTargetFolder.Name = "VideoLabelTargetFolder";
            // 
            // VideoLabelProcessingOn
            // 
            resources.ApplyResources(this.VideoLabelProcessingOn, "VideoLabelProcessingOn");
            this.VideoLabelProcessingOn.BackColor = System.Drawing.Color.Transparent;
            this.VideoLabelProcessingOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.VideoLabelProcessingOn.Name = "VideoLabelProcessingOn";
            // 
            // VideoProgressBarConvert
            // 
            this.VideoProgressBarConvert.BackColor = System.Drawing.Color.Transparent;
            this.VideoProgressBarConvert.DrawHatch = true;
            resources.ApplyResources(this.VideoProgressBarConvert, "VideoProgressBarConvert");
            this.VideoProgressBarConvert.Maximum = 100;
            this.VideoProgressBarConvert.Minimum = 0;
            this.VideoProgressBarConvert.Name = "VideoProgressBarConvert";
            this.VideoProgressBarConvert.ShowPercentage = true;
            this.VideoProgressBarConvert.Value = 0;
            this.VideoProgressBarConvert.ValueAlignment = Ambiance_ProgressBar.Alignment.Right;
            // 
            // VideoLabelVideoProgress
            // 
            resources.ApplyResources(this.VideoLabelVideoProgress, "VideoLabelVideoProgress");
            this.VideoLabelVideoProgress.BackColor = System.Drawing.Color.Transparent;
            this.VideoLabelVideoProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.VideoLabelVideoProgress.Name = "VideoLabelVideoProgress";
            // 
            // VideoProgressBarOverall
            // 
            this.VideoProgressBarOverall.BackColor = System.Drawing.Color.Transparent;
            this.VideoProgressBarOverall.DrawHatch = true;
            resources.ApplyResources(this.VideoProgressBarOverall, "VideoProgressBarOverall");
            this.VideoProgressBarOverall.Maximum = 100;
            this.VideoProgressBarOverall.Minimum = 0;
            this.VideoProgressBarOverall.Name = "VideoProgressBarOverall";
            this.VideoProgressBarOverall.ShowPercentage = true;
            this.VideoProgressBarOverall.Value = 0;
            this.VideoProgressBarOverall.ValueAlignment = Ambiance_ProgressBar.Alignment.Right;
            // 
            // VideoLabelOverallProgress
            // 
            resources.ApplyResources(this.VideoLabelOverallProgress, "VideoLabelOverallProgress");
            this.VideoLabelOverallProgress.BackColor = System.Drawing.Color.Transparent;
            this.VideoLabelOverallProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.VideoLabelOverallProgress.Name = "VideoLabelOverallProgress";
            // 
            // VideoTrackBar
            // 
            this.VideoTrackBar.DrawValueString = true;
            this.VideoTrackBar.JumpToMouse = false;
            resources.ApplyResources(this.VideoTrackBar, "VideoTrackBar");
            this.VideoTrackBar.Maximum = 100;
            this.VideoTrackBar.Minimum = 0;
            this.VideoTrackBar.Name = "VideoTrackBar";
            this.VideoTrackBar.Value = 0;
            this.VideoTrackBar.ValueDivison = Ambiance_TrackBar.ValueDivisor.By1;
            this.VideoTrackBar.ValueToSet = 0F;
            this.VideoTrackBar.ValueChanged += new Ambiance_TrackBar.ValueChangedEventHandler(this.VideoTrackBar_ValueChanged);
            // 
            // VideoLabelQuality
            // 
            resources.ApplyResources(this.VideoLabelQuality, "VideoLabelQuality");
            this.VideoLabelQuality.BackColor = System.Drawing.Color.Transparent;
            this.VideoLabelQuality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.VideoLabelQuality.Name = "VideoLabelQuality";
            // 
            // pictureBoxThumbnail
            // 
            resources.ApplyResources(this.pictureBoxThumbnail, "pictureBoxThumbnail");
            this.pictureBoxThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            this.pictureBoxThumbnail.TabStop = false;
            // 
            // VideoLabelThumbnail
            // 
            resources.ApplyResources(this.VideoLabelThumbnail, "VideoLabelThumbnail");
            this.VideoLabelThumbnail.BackColor = System.Drawing.Color.Transparent;
            this.VideoLabelThumbnail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.VideoLabelThumbnail.Name = "VideoLabelThumbnail";
            // 
            // VideoSeperatorLine
            // 
            resources.ApplyResources(this.VideoSeperatorLine, "VideoSeperatorLine");
            this.VideoSeperatorLine.Name = "VideoSeperatorLine";
            // 
            // VideoLabelCount
            // 
            resources.ApplyResources(this.VideoLabelCount, "VideoLabelCount");
            this.VideoLabelCount.BackColor = System.Drawing.Color.Transparent;
            this.VideoLabelCount.ForeColor = System.Drawing.Color.Silver;
            this.VideoLabelCount.Name = "VideoLabelCount";
            // 
            // VideoButtonClear
            // 
            this.VideoButtonClear.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.VideoButtonClear, "VideoButtonClear");
            this.VideoButtonClear.Image = null;
            this.VideoButtonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VideoButtonClear.Name = "VideoButtonClear";
            this.VideoButtonClear.TextAlignment = System.Drawing.StringAlignment.Center;
            this.VideoButtonClear.Click += new System.EventHandler(this.VideoButtonClear_Click);
            // 
            // VideoButtonAdd
            // 
            this.VideoButtonAdd.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.VideoButtonAdd, "VideoButtonAdd");
            this.VideoButtonAdd.Image = null;
            this.VideoButtonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VideoButtonAdd.Name = "VideoButtonAdd";
            this.VideoButtonAdd.TextAlignment = System.Drawing.StringAlignment.Center;
            this.VideoButtonAdd.Click += new System.EventHandler(this.VideoButtonAdd_Click);
            // 
            // VideoButtonDestination
            // 
            this.VideoButtonDestination.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.VideoButtonDestination, "VideoButtonDestination");
            this.VideoButtonDestination.Image = null;
            this.VideoButtonDestination.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VideoButtonDestination.Name = "VideoButtonDestination";
            this.VideoButtonDestination.TextAlignment = System.Drawing.StringAlignment.Center;
            this.VideoButtonDestination.Click += new System.EventHandler(this.VideoButtonDestination_Click);
            // 
            // dataGridViewFiles
            // 
            this.dataGridViewFiles.AllowUserToAddRows = false;
            this.dataGridViewFiles.AllowUserToDeleteRows = false;
            this.dataGridViewFiles.AllowUserToResizeColumns = false;
            this.dataGridViewFiles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.dataGridViewFiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFiles.BackgroundColor = System.Drawing.Color.Gray;
            this.dataGridViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFiles.EnableHeadersVisualStyles = false;
            this.dataGridViewFiles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            resources.ApplyResources(this.dataGridViewFiles, "dataGridViewFiles");
            this.dataGridViewFiles.Name = "dataGridViewFiles";
            this.dataGridViewFiles.RowHeadersVisible = false;
            this.dataGridViewFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // VideoLabelHeader
            // 
            resources.ApplyResources(this.VideoLabelHeader, "VideoLabelHeader");
            this.VideoLabelHeader.BackColor = System.Drawing.Color.Transparent;
            this.VideoLabelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.VideoLabelHeader.Name = "VideoLabelHeader";
            // 
            // VideoControlBox
            // 
            this.VideoControlBox.BackColor = System.Drawing.Color.Transparent;
            this.VideoControlBox.EnableMaximize = false;
            resources.ApplyResources(this.VideoControlBox, "VideoControlBox");
            this.VideoControlBox.Name = "VideoControlBox";
            // 
            // FormVideoMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.VideoThemeContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVideoMain";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.FormVideoMain_Load);
            this.VideoThemeContainer.ResumeLayout(false);
            this.VideoThemeContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ambiance_ThemeContainer VideoThemeContainer;
        private Ambiance_ControlBox VideoControlBox;
        private Ambiance_Label VideoLabelHeader;
        private System.Windows.Forms.DataGridView dataGridViewFiles;
        private Ambiance_Button_2 VideoButtonDestination;
        private Ambiance_Button_2 VideoButtonClear;
        private Ambiance_Button_2 VideoButtonAdd;
        private Ambiance_Label VideoLabelCount;
        private Ambiance_Separator VideoSeperatorLine;
        private System.Windows.Forms.PictureBox pictureBoxThumbnail;
        private Ambiance_Label VideoLabelThumbnail;
        private Ambiance_TrackBar VideoTrackBar;
        private Ambiance_Label VideoLabelQuality;
        private Ambiance_ProgressBar VideoProgressBarOverall;
        private Ambiance_Label VideoLabelOverallProgress;
        private Ambiance_ProgressBar VideoProgressBarConvert;
        private Ambiance_Label VideoLabelVideoProgress;
        private Ambiance_Label VideoLabelProcessingOn;
        private Ambiance_Label VideoLabelTargetFolder;
        private Ambiance_Button_2 VideoButtonConvert;
        private Ambiance_Label ambiance_Label1;
    }
}

