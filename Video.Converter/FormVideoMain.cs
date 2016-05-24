using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NReco.VideoConverter;

namespace Video.Converter
{
    /*
     * Developer        : Gehan Fernando
     * Date             : 08th April 2016
     * Contact          : f.gehan@gmail.com / +94772269625
     * 
     * Application      : This application helps you to convert videos on format to another format. eg: mp4 to mov.
    **/

    // Convert to real meadia, will be release on 2nd version.
    public partial class FormVideoMain : Form
    {
        private List<Extension> _extensions = null;
        private List<VideoFiles> _vFiles = null;

        private int _quality;
        private string _destination;
        private double _process;
        private double _duration;
        private double _percentage;
        public FormVideoMain()
        {
            InitializeComponent();
        }

        private void FormVideoMain_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            _vFiles = new List<VideoFiles>();

            this.SetDestination(string.Empty);
            this.PopulateExtensions();
            this.SetGridTheme(dataGridViewFiles);
            this.FormatGrid(null, null);
            this.Reset();
        }
        private void VideoButtonDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.Reset();
            dialog.Description = "Select destination folder.";
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.ShowNewFolderButton = true;

            DialogResult result = dialog.ShowDialog(this);
            if (result == DialogResult.Cancel) return;

            this.SetDestination(dialog.SelectedPath);
        }
        private void VideoButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Reset();
                dialog.AddExtension = true;
                dialog.AutoUpgradeEnabled = true;
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.Multiselect = false;
                dialog.ReadOnlyChecked = false;
                dialog.ShowHelp = false;
                dialog.ShowReadOnly = false;
                dialog.SupportMultiDottedExtensions = false;
                dialog.Title = this.Text;
                dialog.ValidateNames = true;
                dialog.Filter = "Video Files |*.asf;*.avi;*.flv;*.mkv;*.mov;*.mp4;*.mpeg;*.swf;*.webm"; //*.rm;
                DialogResult result = dialog.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(dialog.FileName);
                    this.AddFiles(new VideoFiles() { IsUsing = false, 
                        FileName = info.Name, 
                        FilePath = dialog.FileName, 
                        Index = info.Extension == ".mp4" ? 0 : 5 });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VideoButtonClear_Click(object sender, EventArgs e)
        {
            _vFiles.Clear();
            VideoLabelCount.Text = string.Format("Files :. {0}", _vFiles.Count.ToString("00"));

            this.FormatGrid(null, null);
            this.Reset();
        }
        private void VideoButtonConvert_Click(object sender, EventArgs e)
        {
            var fileCount = (from v in _vFiles
                             where v.IsUsing == true
                             select v).Count();

            if (_vFiles.Count == 0 || fileCount == 0)
            {
                MessageBox.Show("Select at least one video file to start the convert process.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to start the video converting process.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            var parent = Task.Factory.StartNew
                (() =>
                    {
                        var child = Task.Factory.StartNew(() =>
                        {
                            this.Cursor = Cursors.WaitCursor;
                            this.ButtonStatus(false);
                            this.KillProcess();

                            try
                            {
                                FFMpegConverter converter = new FFMpegConverter();
                                converter.ConvertProgress += Convert_Progess;
                                converter.LogReceived += Convert_Log;

                                VideoProgressBarOverall.Maximum = fileCount;

                                int counter = 0;
                                float? frameTime = 30;
                                string imageFilePath = string.Empty;
                                string videoFilePath = string.Empty;
                                string parameter = string.Empty;

                                List<VideoFiles> files = (from v in _vFiles
                                                          where v.IsUsing == true
                                                          select v).ToList();

                                foreach (var item in files)
                                {
                                    counter += 1;

                                    VideoProgressBarOverall.Value = counter;
                                    VideoProgressBarOverall.Refresh();

                                    converter.FFMpegProcessPriority = ProcessPriorityClass.Normal;

                                    imageFilePath = string.Concat(_destination, _destination.Length == 3 ? string.Empty : @"\", counter.ToString(), ".jpeg");
                                    videoFilePath = string.Concat(_destination, _destination.Length == 3 ? string.Empty : @"\", Path.GetFileNameWithoutExtension(item.FilePath), _extensions[item.Index].FileExtension);

                                    converter.GetVideoThumbnail(item.FilePath, imageFilePath, frameTime);
                                    using (FileStream imageStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
                                    {
                                        pictureBoxThumbnail.BackgroundImageLayout = ImageLayout.Stretch;
                                        Image thumbnail = null;

                                        try
                                        {
                                            thumbnail = Image.FromStream(imageStream);
                                        }
                                        catch (Exception)
                                        {
                                            thumbnail = null;
                                        }

                                        imageStream.Flush();
                                        imageStream.Close();

                                        pictureBoxThumbnail.BackgroundImage = thumbnail;
                                    }

                                    switch (this.GetVideoFormat(_extensions[item.Index].FileExtension))
                                    {
                                        case "swf":
                                            parameter = string.Format(" -qscale:v 1 -b:a 192k -crf {0} -q:a 0 -preset medium -threads 4 -ar 44100 -strict experimental -ab 192k ", _quality);
                                            break;
                                        case "webm":
                                            parameter = string.Format(" -b:v 1000M -crf {0} -c:v libvpx-vp9 -preset medium -c:a libvorbis -strict experimental -ab 128k ", _quality);
                                            break;
                                        case "mpeg":
                                            parameter = string.Format(" -b:v 2500 -b:a 192k -crf {0} -c:v mpeg2video -preset medium -c:a libmp3lame -threads 4 -ar 44100 -strict experimental -ab 192k ", _quality);
                                            break;
                                        //case "rm":
                                        //    parameter = string.Format(" -b:v 2500 -b:a 192k -crf {0} -c:v libx264 -preset medium -c:a libfaac -threads 4 -ar 44100 -strict experimental -ab 192k ", _quality);
                                        //    break;
                                        default:
                                            parameter = string.Format(" -b:v 2500 -b:a 128k -crf {0} -c:v libx264 -preset medium -c:a aac -threads 4 -ar 44100 -strict experimental -ab 128k ", _quality);
                                            break;
                                    }

                                    ConvertSettings setting = new ConvertSettings()
                                    {
                                        AppendSilentAudioStream = false,
                                        CustomOutputArgs = parameter
                                    };
                                    
                                    converter.ConvertMedia(item.FilePath, 
                                        this.GetVideoFormat(new FileInfo(item.FilePath).Extension), 
                                        videoFilePath,
                                        this.GetVideoFormat(_extensions[item.Index].FileExtension), setting);
                                }

                                MessageBox.Show("Video file(s) converted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Process.Start(_destination);
                            }
                            catch (FFMpegException fx)
                            {
                                MessageBox.Show(fx.Message, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            this.KillProcess();
                            this.ButtonStatus(true);
                            this.Reset();
                            this.Cursor = Cursors.Default;

                        });
                },
                TaskCreationOptions.LongRunning
            );
        }

        private void Convert_Log(object sender, FFMpegLogEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine(e.Data);
            }
        }
        private void Convert_Progess(object sender, ConvertProgressEventArgs e)
        {
            _process = 0;
            _duration = 0;
            _percentage = 0;

            _process = e.Processed.TotalMinutes;
            _duration = e.TotalDuration.TotalMinutes;

            _percentage = (_process / _duration) * 100;
            if (_percentage > 100) _percentage = 100.00;

            VideoProgressBarConvert.Value = Convert.ToInt32(_percentage);
            VideoProgressBarConvert.Refresh();

            VideoLabelProcessingOn.Text = string.Concat("Process on.", Environment.NewLine, e.Processed, " / ", e.TotalDuration);
            VideoLabelProcessingOn.Refresh();
        }
        private void VideoTrackBar_ValueChanged()
        {
            _quality = this.SetQuality(VideoTrackBar.Value);
        }

        private void FormatGrid(object datasource, object extension)
        {
            dataGridViewFiles.DataSource = null;
            dataGridViewFiles.Columns.Clear();

            dataGridViewFiles.Refresh();

            this.CheckBoxColumn(dataGridViewFiles,
                new DataGridViewCheckBoxColumn(),
                DataGridViewContentAlignment.MiddleCenter,
                string.Empty, "colIsUsing", string.Empty, "IsUsing", 0,
                DataGridViewAutoSizeColumnMode.NotSet, Color.Black, true, false, 25);

            this.TextBoxColumn(dataGridViewFiles, new DataGridViewTextBoxColumn(),
                DataGridViewContentAlignment.MiddleLeft,
                String.Empty, "colFileName", "File Name", "FileName", 1,
                DataGridViewAutoSizeColumnMode.NotSet, Color.Black, true, true, 200, 255);

            this.TextBoxColumn(dataGridViewFiles, new DataGridViewTextBoxColumn(),
                DataGridViewContentAlignment.MiddleLeft,
                String.Empty, "colFilePath", "File Path", "FilePath", 2,
                DataGridViewAutoSizeColumnMode.Fill, Color.Black, true, true, 250, 255);

            this.ComboBoxColumn(dataGridViewFiles, new DataGridViewComboBoxColumn(), DataGridViewContentAlignment.MiddleLeft,
                string.Empty, "colFileExtension", "Convert To", "Index", 3,
                DataGridViewAutoSizeColumnMode.NotSet, extension, Color.Black, true, false, 100);

            dataGridViewFiles.DataSource = datasource;
            dataGridViewFiles.Refresh();
        }
        private void SetGridTheme(DataGridView gridview)
        {
            gridview.AutoGenerateColumns = false;

            gridview.Font = new Font("Consolas", 9.75f, FontStyle.Regular);

            gridview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(222, 237, 245);
            gridview.AlternatingRowsDefaultCellStyle.Font = new Font("Consolas", 9.75f, FontStyle.Regular);

            gridview.BackgroundColor = SystemColors.AppWorkspace;
            gridview.BorderStyle = BorderStyle.Fixed3D;

            gridview.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            gridview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            gridview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 149, 197);
            gridview.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            gridview.ColumnHeadersDefaultCellStyle.Font = new Font("Consolas", 9.75f, FontStyle.Regular);

            gridview.EnableHeadersVisualStyles = false;

            gridview.GridColor = Color.FromArgb(96, 170, 210);
            gridview.RowHeadersVisible = false;

            gridview.RowsDefaultCellStyle.BackColor = Color.White;
            gridview.RowsDefaultCellStyle.Font = new Font("Consolas", 9.75f, FontStyle.Regular);

            gridview.AllowDrop = false;
            gridview.AllowUserToAddRows = false;
            gridview.AllowUserToDeleteRows = true;
            gridview.AllowUserToOrderColumns = false;
            gridview.AllowUserToResizeColumns = false;
            gridview.AllowUserToResizeRows = false;

            gridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridview.MultiSelect = false;
            gridview.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridview.RowHeadersWidth = 10;
        }
        private void TextBoxColumn(DataGridView grid, DataGridViewTextBoxColumn column, DataGridViewContentAlignment alignment,
                   string cellformat, string colname, string headertext, string propertyname, int orderindex,
                   DataGridViewAutoSizeColumnMode mode,
                   Color color, bool visibile = true, bool isreadonly = false, int width = 100, int maxlength = 32767)
        {
            column.DefaultCellStyle.Alignment = alignment;
            column.HeaderCell.Style.Alignment = alignment;
            column.HeaderCell.Style.ForeColor = color;

            column.SortMode = DataGridViewColumnSortMode.NotSortable;

            column.DefaultCellStyle.Format = cellformat;

            column.Name = colname;
            column.HeaderText = headertext;
            column.Visible = visibile;

            column.MaxInputLength = maxlength;
            column.ReadOnly = isreadonly;
            column.Resizable = DataGridViewTriState.False;

            column.DataPropertyName = propertyname;
            column.AutoSizeMode = mode;
            column.Frozen = false;
            column.MinimumWidth = 5;
            column.Width = width;

            column.DisplayIndex = orderindex;

            grid.Columns.Add(column);
        }
        private void CheckBoxColumn(DataGridView grid, DataGridViewCheckBoxColumn column, DataGridViewContentAlignment alignment,
                                   string cellformat, string colname, string headertext, string propertyname,
                                   int orderindex, DataGridViewAutoSizeColumnMode mode,
                                   Color color, bool visibile = true, bool isreadonly = false, int width = 100)
        {
            column.DefaultCellStyle.Alignment = alignment;
            column.HeaderCell.Style.Alignment = alignment;
            column.HeaderCell.Style.ForeColor = color;

            column.SortMode = DataGridViewColumnSortMode.NotSortable;

            column.DefaultCellStyle.Format = cellformat;

            column.Name = colname;
            column.HeaderText = headertext;
            column.Visible = visibile;

            column.ReadOnly = isreadonly;
            column.Resizable = DataGridViewTriState.False;

            column.DataPropertyName = propertyname;
            column.AutoSizeMode = mode;
            column.Frozen = false;
            column.MinimumWidth = 5;
            column.Width = width;

            column.DisplayIndex = orderindex;

            grid.Columns.Add(column);
        }
        private void ComboBoxColumn(DataGridView grid, DataGridViewComboBoxColumn column, DataGridViewContentAlignment alignment,
                           string cellformat, string colname, string headertext, string propertyname,
                           int orderindex, DataGridViewAutoSizeColumnMode mode, object datasource,
                           Color color, bool visibile = true, bool isreadonly = false, int width = 100)
        {
            column.DefaultCellStyle.Alignment = alignment;
            column.HeaderCell.Style.Alignment = alignment;
            column.HeaderCell.Style.ForeColor = color;
            
            column.SortMode = DataGridViewColumnSortMode.NotSortable;

            column.DefaultCellStyle.Format = cellformat;

            column.Name = colname;
            column.HeaderText = headertext;
            column.Visible = visibile;

            column.ReadOnly = isreadonly;
            column.Resizable = DataGridViewTriState.False;

            column.DataPropertyName = propertyname;
            column.AutoSizeMode = mode;
            column.Frozen = false;
            column.MinimumWidth = 5;
            column.Width = width;

            column.DisplayIndex = orderindex;

            column.ValueMember = "Index";
            column.DisplayMember = "FileExtension";
            column.DataSource = datasource;
            
            grid.Columns.Add(column);
        }
        private void SetDestination(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                _destination = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            else
                _destination = value;

            VideoLabelTargetFolder.Text = string.Format("Target Folder :. {0}", _destination);
            VideoLabelTargetFolder.Refresh();
        }
        private void KillProcess()
        {
            List<Process> pList = (from p in Process.GetProcesses()
                                   where p.ProcessName == "ffmpeg"
                                   select p).ToList();

            if (pList.Count == 0) return;

            foreach (Process process in pList)
            {
                process.Kill();
                process.WaitForExit(100);
            }
        }
        private void PopulateExtensions()
        {
            if (_extensions == null) _extensions = new List<Extension>();
            _extensions.Clear();

            _extensions.Add(new Extension() { Index = 0, FileExtension = ".asf" });
            _extensions.Add(new Extension() { Index = 1, FileExtension = ".avi" });
            _extensions.Add(new Extension() { Index = 2, FileExtension = ".flv" });
            _extensions.Add(new Extension() { Index = 3, FileExtension = ".mkv" });
            _extensions.Add(new Extension() { Index = 4, FileExtension = ".mov" });
            _extensions.Add(new Extension() { Index = 5, FileExtension = ".mp4" });
            _extensions.Add(new Extension() { Index = 6, FileExtension = ".mpeg" });
            //_extensions.Add(new Extension() { Index = 7, FileExtension = ".rm" });
            _extensions.Add(new Extension() { Index = 7, FileExtension = ".swf" });
            _extensions.Add(new Extension() { Index = 8, FileExtension = ".webm" });
        }
        private string GetVideoFormat(string extension)
        {
            string value = string.Empty;

            switch (extension)
            {
                case ".asf":
                    value = Format.asf;
                    break;
                case ".avi":
                    value = Format.avi;
                    break;
                case ".flv":
                    value = Format.flv;
                    break;
                case ".h264":
                    value = Format.h264;
                    break;
                case ".mkv":
                    value = Format.matroska;
                    break;
                case ".mov":
                    value = Format.mov;
                    break;
                case ".mp4":
                    value = Format.mp4;
                    break;
                case ".mpeg":
                    value = Format.mpeg;
                    break;
                //case ".rm":
                //    value = Format.rm;
                //    break;
                case ".swf":
                    value = Format.swf;
                    break;
                case ".webm":
                    value = Format.webm;
                    break;
            }

            return value;
        }
        private void AddFiles(VideoFiles value)
        {
            _vFiles.Add(value);
            this.FormatGrid(_vFiles, _extensions);
            VideoLabelCount.Text = string.Format("Files :. {0}", _vFiles.Count.ToString("00"));
        }
        private void Reset()
        {
            pictureBoxThumbnail.BackgroundImage = null;
            VideoTrackBar.Value = 65;
            VideoProgressBarOverall.Value = 0;
            VideoProgressBarConvert.Value = 0;
            VideoLabelProcessingOn.Text = "Process on.";
        }
        private int SetQuality(int value)
        {
            int maxValue = 50;
            int progressValue = (int)value / 2;
            return maxValue = maxValue - progressValue;
        }
        private void ButtonStatus(bool value)
        {
            VideoButtonDestination.Enabled = value;
            VideoButtonAdd.Enabled = value;
            VideoButtonClear.Enabled = value;
            VideoButtonConvert.Enabled = value;
        }

        private void ambiance_Label1_Click(object sender, EventArgs e)
        {

        }
    }
}