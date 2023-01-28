namespace BigTagEditor
{
    partial class frmNormaliseDialog
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboArtist = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAlbum = new System.Windows.Forms.ComboBox();
            this.chkClearComments = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboGenre = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboImgs = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkAlbumArt = new System.Windows.Forms.CheckBox();
            this.chkUpdateArtist = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(264, 115);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(345, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Artist";
            // 
            // cboArtist
            // 
            this.cboArtist.FormattingEnabled = true;
            this.cboArtist.Location = new System.Drawing.Point(12, 25);
            this.cboArtist.Name = "cboArtist";
            this.cboArtist.Size = new System.Drawing.Size(158, 21);
            this.cboArtist.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Album";
            // 
            // cboAlbum
            // 
            this.cboAlbum.FormattingEnabled = true;
            this.cboAlbum.Location = new System.Drawing.Point(200, 25);
            this.cboAlbum.Name = "cboAlbum";
            this.cboAlbum.Size = new System.Drawing.Size(158, 21);
            this.cboAlbum.TabIndex = 2;
            // 
            // chkClearComments
            // 
            this.chkClearComments.AutoSize = true;
            this.chkClearComments.Checked = true;
            this.chkClearComments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearComments.Location = new System.Drawing.Point(570, 27);
            this.chkClearComments.Name = "chkClearComments";
            this.chkClearComments.Size = new System.Drawing.Size(102, 17);
            this.chkClearComments.TabIndex = 3;
            this.chkClearComments.Text = "Clear Comments";
            this.chkClearComments.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Genre";
            // 
            // cboGenre
            // 
            this.cboGenre.FormattingEnabled = true;
            this.cboGenre.Location = new System.Drawing.Point(389, 25);
            this.cboGenre.Name = "cboGenre";
            this.cboGenre.Size = new System.Drawing.Size(158, 21);
            this.cboGenre.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Album Art Finder:";
            // 
            // cboImgs
            // 
            this.cboImgs.FormattingEnabled = true;
            this.cboImgs.Location = new System.Drawing.Point(111, 68);
            this.cboImgs.Name = "cboImgs";
            this.cboImgs.Size = new System.Drawing.Size(561, 21);
            this.cboImgs.TabIndex = 5;
            this.cboImgs.SelectedIndexChanged += new System.EventHandler(this.cboImgs_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // chkAlbumArt
            // 
            this.chkAlbumArt.AutoSize = true;
            this.chkAlbumArt.Location = new System.Drawing.Point(111, 95);
            this.chkAlbumArt.Name = "chkAlbumArt";
            this.chkAlbumArt.Size = new System.Drawing.Size(109, 17);
            this.chkAlbumArt.TabIndex = 7;
            this.chkAlbumArt.Text = "Update Album Art";
            this.chkAlbumArt.UseVisualStyleBackColor = true;
            // 
            // chkUpdateArtist
            // 
            this.chkUpdateArtist.AutoSize = true;
            this.chkUpdateArtist.Location = new System.Drawing.Point(81, 8);
            this.chkUpdateArtist.Name = "chkUpdateArtist";
            this.chkUpdateArtist.Size = new System.Drawing.Size(89, 17);
            this.chkUpdateArtist.TabIndex = 8;
            this.chkUpdateArtist.Text = "Don\'t Update";
            this.chkUpdateArtist.UseVisualStyleBackColor = true;
            this.chkUpdateArtist.CheckedChanged += new System.EventHandler(this.chkUpdateArtist_CheckedChanged);
            // 
            // frmNormaliseDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(685, 153);
            this.ControlBox = false;
            this.Controls.Add(this.chkUpdateArtist);
            this.Controls.Add(this.chkAlbumArt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cboImgs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkClearComments);
            this.Controls.Add(this.cboGenre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboAlbum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboArtist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmNormaliseDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Normalise Album";
            this.Load += new System.EventHandler(this.frmNormaliseDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboArtist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAlbum;
        private System.Windows.Forms.CheckBox chkClearComments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboGenre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboImgs;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkAlbumArt;
        private System.Windows.Forms.CheckBox chkUpdateArtist;
    }
}