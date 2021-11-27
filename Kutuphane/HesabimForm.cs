using Kutuphane.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class HesabimForm : Form
    {
        private readonly Kullanici kullanici;
        private readonly KutuphaneYoneticisi kutuphaneYoneticisi;
        public HesabimForm(Kullanici kullanici, KutuphaneYoneticisi kutuphaneYoneticisi)
        {
            InitializeComponent();
            this.kullanici = kullanici;
            this.kutuphaneYoneticisi = kutuphaneYoneticisi;

            DataGuncelle();
            BilgileriGoster();
        }

        private void BilgileriGoster()
        {
            lblAdSoyad.Text = $"Ad Soyad: {kullanici.AdSoyad}";
            lblID.Text = $"{kullanici.Id}";
            lblKullaniciAdi.Text = $"{kullanici.KullaniciAdi}";
            lblParola.Text = $"{kullanici.Parola}";
        }

        private void DataGuncelle()
        {
            dgvOduncAlinanKitaplar.DataSource = null;
            dgvOduncAlinanKitaplar.DataSource = kullanici.OduncAlinanKitaplar;
            dgvOduncAlinanKitaplar.Columns[0].Visible = false; //Id
            dgvOduncAlinanKitaplar.Columns[2].Visible = false; 
            dgvOduncAlinanKitaplar.Columns[4].Visible = false;
            dgvOduncAlinanKitaplar.Columns[5].Visible = false;
            dgvOduncAlinanKitaplar.Columns[6].Visible = false;
        }

        private void btnKitapTeslimEt_Click(object sender, EventArgs e)
        {
            if (dgvOduncAlinanKitaplar.SelectedRows.Count > 0)
            {
                Kitap kitap = (Kitap)dgvOduncAlinanKitaplar.SelectedRows[0].DataBoundItem;
                kullanici.OduncAlinanKitaplar.Remove(kitap);
                kutuphaneYoneticisi.KitapTeslimEtme(kitap);
                DataGuncelle();
            }
        }

        private void dgvOduncAlinanKitaplar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOduncAlinanKitaplar.SelectedRows.Count > 0)
            {
                Kitap kitap = (Kitap)dgvOduncAlinanKitaplar.SelectedRows[0].DataBoundItem;
                dtpSonTeslimTarihi.Value = ((DateTime)kitap.AlinmaTarihi).AddDays(14);
            }
        }
    }
}
