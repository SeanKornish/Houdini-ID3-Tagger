using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace BigTagEditor
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        List<string> strFound;
        BackgroundWorker bwProcess;
        
        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstView.ListViewItemSorter = lvwColumnSorter;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (btnSelectFolder.Text == "Set Folder")
            {

                FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
                dlgFolder.ShowNewFolderButton = false;
                dlgFolder.Description = "Select the folder to scan.";
                if (dlgFolder.ShowDialog(this) == DialogResult.OK)
                {
                    btnSelectFolder.Text = "Cancel Scan";
                    lstView.Items.Clear();
                    lblFolder.Text = dlgFolder.SelectedPath;

                    Cursor = Cursors.WaitCursor;
                    toolStripStatusLabel1.Text = "Counting Music Files...";
                    Application.DoEvents();

                    strFound = GetAllFileNames(dlgFolder.SelectedPath);

                    toolStripProgressBar1.Value = 0;
                    toolStripProgressBar1.Maximum = strFound.Count;
                    toolStripProgressBar1.Visible = true;
                    toolStripStatusLabel1.Text = "Processing " + strFound.Count.ToString() + " Music Files!";                    
                    Application.DoEvents();

                    bwProcess = new BackgroundWorker();
                    bwProcess.WorkerReportsProgress = true;
                    bwProcess.DoWork += new DoWorkEventHandler(bwProcess_DoWork);
                    bwProcess.ProgressChanged += new ProgressChangedEventHandler(bwProcess_ProgressChanged);
                    bwProcess.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwProcess_RunWorkerCompleted);
                    bwProcess.RunWorkerAsync();

                    Cursor = Cursors.Default;                    
                }
            }
            else
            {
                btnSelectFolder.Enabled = false;
            }
        }

        void bwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SaveList();
            toolStripProgressBar1.Value = 0;
            btnSelectFolder.Enabled = true;
            btnSelectFolder.Text = "Set Folder";
            toolStripStatusLabel1.Text = "Ready";
        }

        void bwProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ListViewItem lvi = (ListViewItem)e.UserState;
            lstView.Items.Add(lvi);
            toolStripStatusLabel1.Text = String.Format("Processing {0} by {1} ...", lvi.SubItems[0].Text, lvi.SubItems[1].Text);
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        void bwProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            int x = 0;
            foreach (string fileName in strFound)
            {
                MusicFile musicFile = new MusicFile(fileName);                
                ListViewItem lvi = new ListViewItem(musicFile.Title);
                lvi.SubItems.Add(musicFile.Artist);
                lvi.SubItems.Add(musicFile.Album);
                lvi.SubItems.Add(musicFile.Genre);
                lvi.SubItems.Add(musicFile.Comments);
                lvi.SubItems.Add(musicFile.HasPicture ? "Yes" : "No");
                lvi.Tag = musicFile.FilePath;

                bwProcess.ReportProgress(x, lvi);
                x++;
            }            
        }

        public List<string> GetAllFileNames(string baseDir)
        {
            List<string> fl = new List<string>();
            Stack<string> directoryStack = new Stack<string>();
            directoryStack.Push(baseDir);

            while (directoryStack.Count > 0)
            {
                string currentDir = directoryStack.Pop();
                foreach (string fileName in Directory.GetFiles(currentDir, "*.mp3"))
                {
                    fl.Add(fileName);
                    lblFolder.Text = String.Format("{0} ({1})", baseDir, fl.Count);
                    Application.DoEvents();
                }

                foreach (string directoryName in Directory.GetDirectories(currentDir))
                {
                    directoryStack.Push(directoryName);
                }
            }

            fl.Sort();
            return fl;
        }

        private void lstView_DoubleClick(object sender, EventArgs e)
        {
            MusicFile music = new MusicFile(lstView.SelectedItems[0].Tag.ToString());            
            frmEdit edit = new frmEdit(music);
            if (edit.ShowDialog(this) == DialogResult.OK)
            {                
                lstView.SelectedItems[0].Text = edit.EditFile.Title;
                lstView.SelectedItems[0].SubItems[1].Text = edit.EditFile.Artist;
                lstView.SelectedItems[0].SubItems[2].Text = edit.EditFile.Album;
                lstView.SelectedItems[0].SubItems[3].Text = edit.EditFile.Genre;
                lstView.SelectedItems[0].SubItems[4].Text = edit.EditFile.Comments;
                lstView.SelectedItems[0].SubItems[5].Text = edit.EditFile.HasPicture ? "Yes" : "No";
                lstView.SelectedItems[0].Tag = edit.EditFile.FilePath;
                Cursor = Cursors.Default;
            }
        }

        private void cboViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("data.xml"))
            {
                LoadCachedData();
            }

            this.Text = string.Format("{0} v{1}", Application.ProductName, Application.ProductVersion);
        }

        private void LoadCachedData()
        {
            //string data = File.ReadAllText("data.xml");
            //List<MusicFile> items = (List<MusicFile>)s.DeserializeObject(data);

            //foreach (MusicFile musicFile in items)
            //{
            //    ListViewItem lvi = new ListViewItem(musicFile.Title);
            //    lvi.SubItems.Add(musicFile.Artist);
            //    lvi.SubItems.Add(musicFile.Album);
            //    lvi.SubItems.Add(musicFile.Genre);
            //    lvi.SubItems.Add(musicFile.Comments);
            //    lvi.SubItems.Add(musicFile.HasPicture ? "Yes" : "No");
            //    lvi.Tag = musicFile.FilePath;
            //    lstView.Items.Add(lvi);
            //}
        }

        private void lstView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            this.lstView.Sort();
        }

        private void SaveList()
        {
            //List<MusicFile> items = new List<MusicFile>();
            //ListView.ListViewItemCollection lvic = lstView.Items;

            //foreach (ListViewItem var in lvic)
            //{
            //    MusicFile mf = new MusicFile(var.Tag.ToString());
            //    items.Add(mf);
            //}
            //string data = s.SerializeObject(items);
            //File.WriteAllText("data.xml", data);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveList();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveList();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            foreach (ListViewItem var in lstView.SelectedItems)
            {
                MusicFile mf = new MusicFile(var.Tag.ToString());
                mf = ClearComments(mf);
                var.SubItems[4].Text = mf.Comments;
            }
            Cursor = Cursors.Default;
        }

        private MusicFile ClearComments(MusicFile file)
        {
            file.Comments = String.Empty;
            file.SaveChanges();
            return file;
        }

        private void normaliseAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<MusicFile> album = new List<MusicFile>();
            foreach (ListViewItem var in lstView.SelectedItems)
            {
                MusicFile mf = new MusicFile(var.Tag.ToString());
                album.Add(mf);
            }

            frmNormaliseDialog nrmlz = new frmNormaliseDialog(album);
            if (nrmlz.ShowDialog(this) == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                foreach (MusicFile song in nrmlz.album)
                {
                    foreach (ListViewItem var in lstView.SelectedItems)
                    {
                        if (var.Tag.ToString() == song.FilePath)
                        {
                            var.Text = song.Title;
                            var.SubItems[1].Text = song.Artist;
                            var.SubItems[2].Text = song.Album;
                            var.SubItems[3].Text = song.Genre;
                            var.SubItems[4].Text = song.Comments;
                            var.SubItems[5].Text = song.HasPicture ? "Yes" : "No";
                            var.Tag = song.FilePath;
                        }
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (lstView.SelectedItems.Count == 0)
                e.Cancel = true;
        }

 
    }
}

