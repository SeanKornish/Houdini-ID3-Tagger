using System;
using System.Collections.Generic;
using System.Text;
using HundredMilesSoftware.UltraID3Lib;
using System.Drawing;

namespace BigTagEditor
{
    public class MusicFile
    {
        UltraID3 ultra;
        private string title;
        private string artist;
        private string album;
        private short year;
        private string composer;
        private string genre;
        private short trackNo;
        private string lyrics;
        private string comments;
        private string filepath;
        private bool hasPictureChanges;
        private bool hasPicture;

        public bool HasPicture
        {
            get { return hasPicture; }
            set { hasPicture = value; }
        }
	
        public bool HasPictureChanges
        {
            get { return hasPictureChanges; }
            set { hasPictureChanges = value; }
        }
	
        public string FilePath
        {
            get { return filepath; }
            set { filepath = value; }
        }	
     
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }        

        public string Album
        {
            get { return album; }
            set { album = value; }
        }

        public short Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Composer
        {
            get { return composer; }
            set { composer = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public short TrackNo
        {
            get { return trackNo; }
            set { trackNo = value; }
        }

        public string Lyrics
        {
            get { return lyrics; }
            set { lyrics = value; }
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public Bitmap PictureData
        {
            get {
                if (hasPicture)
                {
                    UltraID3 ultra = new UltraID3();
                    ultra.Read(this.filepath);

                    ID3FrameCollection m_PictureFrames = new ID3FrameCollection(ultra.ID3v2Tag);
                    m_PictureFrames = ultra.ID3v2Tag.Frames.GetFrames(CommonMultipleInstanceID3v2FrameTypes.Picture);
                    try
                    {
                        foreach (ID3v23PictureFrame picfr in m_PictureFrames)
                        {
                            switch (picfr.PictureType)
                            {
                                case PictureTypes.Other:
                                case PictureTypes.CoverFront:
                                    return picfr.Picture;
                            }
                        }
                    }
                    catch
                    {
                        foreach (ID3v22PictureFrame picfr in m_PictureFrames)
                        {
                            switch (picfr.PictureType)
                            {
                                case PictureTypes.Other:
                                case PictureTypes.CoverFront:
                                    return picfr.Picture;
                            }
                        }
                    }
                }

                return null;
            }
        }

        public MusicFile(string filePath)
        {
            this.filepath = filePath;
            ultra = new UltraID3();
            ultra.Read(filePath);

            this.album = ultra.Album;
            this.artist = ultra.Artist;
            this.comments = ultra.Comments;
            this.genre = ultra.Genre;

            bool haspic = false;
            ID3FrameCollection m_PictureFrames = new ID3FrameCollection(ultra.ID3v2Tag);
            m_PictureFrames = ultra.ID3v2Tag.Frames.GetFrames(CommonMultipleInstanceID3v2FrameTypes.Picture);
            try
            {
                foreach (ID3v23PictureFrame picfr in m_PictureFrames)
                {
                    switch (picfr.PictureType)
                    {
                        case PictureTypes.Other:
                        case PictureTypes.CoverFront:
                            //this.pictureData = picfr.Picture;
                            haspic = true;
                            break;
                    }
                }
            }
            catch
            {
                foreach (ID3v22PictureFrame picfr in m_PictureFrames)
                {
                    switch (picfr.PictureType)
                    {
                        case PictureTypes.Other:
                        case PictureTypes.CoverFront:
                            //this.pictureData = picfr.Picture;
                            haspic = true;
                            break;
                    }
                }
            }

            this.hasPicture = haspic;
            this.title = ultra.Title;
            if (ultra.TrackNum != null)
                this.trackNo = ultra.TrackNum.Value;
            if (ultra.Year != null)
                this.year = ultra.Year.Value;
        }

        public MusicFile()
        {
        }

        public void SaveChanges()
        {
            ultra.ID3v1Tag.Album = (this.album.Length > 30 ? this.album.Substring(0, 30) : this.album);
            ultra.ID3v2Tag.Album = this.album;

            ultra.ID3v1Tag.Artist = (this.artist.Length > 30 ? this.artist.Substring(0, 30) : this.artist);
            ultra.ID3v2Tag.Artist = this.artist;

            ultra.ID3v1Tag.Comments = String.Empty;
            ultra.ID3v2Tag.Comments = String.Empty;

            ultra.ID3v1Tag.Genre = (byte)GenreInfoCollection.IndexOfName(this.genre);
            ultra.ID3v2Tag.Genre = this.genre;

            ultra.ID3v1Tag.Title = (this.title.Length > 30 ? this.title.Substring(0, 30) : this.title);
            ultra.ID3v2Tag.Title = this.title;

            ultra.Write();
        }

        public void UpdateAlbum(Bitmap bitmap)
        {
            ultra.ID3v2Tag.Frames.Remove(CommonID3v2FrameTypes.Picture);

            try
            {
                ID3v22PictureFrame newPicFr = new ID3v22PictureFrame(bitmap, PictureTypes.CoverFront, "", TextEncodingTypes.ISO88591);
                ultra.ID3v2Tag.Frames.Add(newPicFr);
            }
            catch (Exception)
            {
                ID3v23PictureFrame newPicFr = new ID3v23PictureFrame(bitmap, PictureTypes.CoverFront, "", TextEncodingTypes.ISO88591);
                ultra.ID3v2Tag.Frames.Add(newPicFr);
            }

            ultra.Write();
        }
    }
}

