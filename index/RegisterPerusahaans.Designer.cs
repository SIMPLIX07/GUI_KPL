namespace index
{
    partial class RegisterPerusahaans
    {
        // Komponen UI yang digunakan dalam form
        private System.ComponentModel.IContainer komponen = null;
        
        /// <summary>
        /// Membersihkan resource yang digunakan
        /// </summary>
        /// <param name="disposing">
        /// true - membersihkan resource yang dikelola
        /// false - hanya membersihkan resource tidak dikelola
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (komponen != null))
            {
                komponen.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kode yang di-generate oleh Windows Form Designer

        /// <summary>
        /// Method untuk inisialisasi komponen UI
        /// </summary>
        private void InisialisasiKomponen()
        {
            this.komponen = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form Pendaftaran Perusahaan";
        }

        #endregion
    }
}