using AssociationCRMDawanPoe.Entity;
using AssociationCRMDawanPoe.Service;
using System.Web;

namespace ProductManager
{
    public partial class Form1 : Form
    {


        IProductService productService = new ProductServiceImpl();
        List<String> Products;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Products = new();

            TxtPrix.Enabled = false;
            TxtQuantite.Enabled = false;
            btnAjouter.Enabled = false;
            btnSupprimer.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProduits.SelectedItems.Count == 1)
            {
                TxtPrix.Enabled = true;
                TxtQuantite.Enabled = true;
                btnAjouter.Enabled = true;
                btnSupprimer.Enabled = true;

            }
            else
            {
                TxtPrix.Enabled = false;
                TxtQuantite.Enabled = false;
                btnAjouter.Enabled = false;
                btnSupprimer.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxProduits.Items.Add("Kebab");
            listBoxProduits.Items.Add("Frite");
            listBoxProduits.Items.Add("Hamburger");
            listBoxProduits.Items.Add("Coca");
            listBoxProduits.Items.Add("Fanta");
            listBoxProduits.Items.Add("San Pellegrino");
            listBoxProduits.Items.Add("Sprite");
            listBoxProduits.Items.Add("Nuggets");
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                double prix_total = Convert.ToDouble(TxtPrix.Text.Replace('.', ',')) * Convert.ToUInt32(TxtQuantite.Text);

                string? produit = listBoxProduits.SelectedItem?.ToString();

                if (produit is null)
                {
                    throw new Exception("Merci de sélectionner un produit");
                }

                produit += " " + prix_total.ToString() + "€."; // Concaténation de chaine de caractères
                listBoxFacture.Items.Add(produit);
                Products.Add(produit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Etes vous sure de vouloir le supprimer de la Facture");
            listBoxFacture.Items.Remove(listBoxFacture.SelectedItem);

        }
    }
}