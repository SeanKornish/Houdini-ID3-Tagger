using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BigTagEditor
{
    public partial class frmEdit : Form
    {
        private MusicFile editfile;
        public MusicFile EditFile
        {
            get { return editfile; }
            set { editfile = value; }
        }	

        public frmEdit(MusicFile editFile)
        {
            InitializeComponent();
            this.editfile = editFile;
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            txtAlbum.Text = editfile.Album;
            txtArtist.Text = editfile.Artist;
            txtComments.Text = editfile.Comments;
            txtComposer.Text = editfile.Composer;
            txtGenre.Text = editfile.Genre;
            txtLyrics.Text = editfile.Lyrics;
            txtSong.Text = editfile.Title;

            if (editfile.TrackNo > 0)
                txtTrackNum.Text = editfile.TrackNo.ToString();

            if (editfile.Year > 0)
                txtYear.Text = editfile.Year.ToString();

            lblFilePath.Text = editfile.FilePath;
            if (editfile.PictureData != null)
                picAlbumArt.Image = Image.FromHbitmap(editfile.PictureData.GetHbitmap());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            Cursor = Cursors.WaitCursor;
            editfile.Album = txtAlbum.Text;
            editfile.Artist = txtArtist.Text;
            editfile.Comments = txtComments.Text;
            editfile.Composer = txtComposer.Text;
            editfile.Genre = txtGenre.Text;
            editfile.Lyrics = txtLyrics.Text;
            editfile.Title = txtSong.Text;

            if (!String.IsNullOrEmpty(txtTrackNum.Text))
                editfile.TrackNo = Convert.ToInt16(txtTrackNum.Text);

            if (!String.IsNullOrEmpty(txtYear.Text))
                editfile.Year = Convert.ToInt16(txtYear.Text);

            if (editfile.HasPictureChanges)
            {
                editfile.UpdateAlbum(new Bitmap(picAlbumArt.Image));
                editfile.HasPicture = true;
            }

            editfile.SaveChanges();
        }

        private void picAlbumArt_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Image Files|*.jpg;*.bmp;*.png|All Files|*.*";
            FileInfo fi = new FileInfo(editfile.FilePath);
            dlgOpen.InitialDirectory = fi.Directory.FullName;
            dlgOpen.Multiselect = false;
            dlgOpen.Title = "Select Image for Cover";

            if (dlgOpen.ShowDialog(this) == DialogResult.OK)
            {
                picAlbumArt.Image = Image.FromFile(dlgOpen.FileName);
                editfile.HasPictureChanges = true;
            }
        }
    }
}