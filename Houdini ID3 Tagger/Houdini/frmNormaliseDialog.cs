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
    public partial class frmNormaliseDialog : Form
    {
        public List<MusicFile> album;

        public frmNormaliseDialog(List<MusicFile> Album)
        {
            InitializeComponent();
            album = Album;
        }

        private void frmNormaliseDialog_Load(object sender, EventArgs e)
        {
            List<string> albums = new List<string>();
            List<string> artists = new List<string>();
            List<string> genre = new List<string>();

            foreach (MusicFile song in album)
            {
                if (!albums.Contains(song.Album))
                    albums.Add(song.Album);

                if (!artists.Contains(song.Artist))
                    artists.Add(song.Artist);

                if (!genre.Contains(song.Genre))
                    genre.Add(song.Genre);

                cboImgs.Items.Clear();
                chkAlbumArt.Enabled = false;
                cboImgs.Items.AddRange(Directory.GetFiles(
                    new FileInfo(song.FilePath).DirectoryName, "*.jpg", SearchOption.AllDirectories));

                cboImgs.Items.AddRange(Directory.GetFiles(
                    new FileInfo(song.FilePath).DirectoryName, "*.bmp", SearchOption.AllDirectories));

                cboImgs.Items.AddRange(Directory.GetFiles(
                    new FileInfo(song.FilePath).DirectoryName, "*.png", SearchOption.AllDirectories));

                if (cboImgs.Items.Count > 0)
                {
                    chkAlbumArt.Enabled = true;
                    chkAlbumArt.Checked = true;
                    cboImgs.SelectedIndex = 0;
                }
            }

            cboAlbum.Items.AddRange(albums.ToArray());
            cboArtist.Items.AddRange(artists.ToArray());
            cboGenre.Items.AddRange(genre.ToArray());

            cboAlbum.SelectedIndex = 0;
            cboArtist.SelectedIndex = 0;
            cboGenre.SelectedText = genre[0];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<MusicFile> newAlbum = new List<MusicFile>();
            foreach (MusicFile song in album)
            {
                MusicFile newSong = song;
                newSong.Album = cboAlbum.Text;

                if (!chkUpdateArtist.Checked)
                    newSong.Artist = cboArtist.Text;
                else
                    newSong.Artist = song.Artist;

                newSong.Genre = cboGenre.Text;

                if (chkClearComments.Checked)
                    newSong.Comments = String.Empty;

                if (chkAlbumArt.Checked)
                {
                    newSong.UpdateAlbum(new Bitmap(pictureBox1.Image));
                    newSong.HasPicture = true;
                }

                newSong.SaveChanges();
                newAlbum.Add(newSong);
            }
            album = newAlbum;
        }

        private void cboImgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(cboImgs.SelectedItem.ToString());
        }

        private void chkUpdateArtist_CheckedChanged(object sender, EventArgs e)
        {
            cboArtist.Enabled = chkUpdateArtist.Checked;
        }
    }
}
