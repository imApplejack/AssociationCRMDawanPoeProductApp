using AssociationCRMDawanPoe.Entity;
using AssociationCRMDawanPoe.Persistance;
using AssociationCRMDawanPoe.Service;
using System.Configuration;
using System.Web;

namespace ProductManager
{
    public partial class Form1 : Form
    {


        IProductService ProductService = new ProductServiceImpl();
        List<String> Products;

        public Form1()
        {


            //  ProductRepository pr = new ProductRepository(ConfigurationManager.ConnectionStrings["chConnexion"].ConnectionString);

            //   List<Product> listProduct =   pr.GetAll();

            this.ProductService = new ProductServiceImpl() { ProductRepository = new ProductRepository(ConfigurationManager.ConnectionStrings["chConnexion"].ConnectionString) };


            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            FillDataGridProduct();


            this.ProductService.RemoveProductById(1);

        }



        void FillDataGridProduct()
        {
            ProductDatagrid.DataSource = ProductService.GetAll();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                int SelectedIdProduct = (int)this.ProductDatagrid.SelectedRows[0].Cells[2].Value;
                this.ProductService.RemoveProductById(SelectedIdProduct);
            }
            catch (Exception)
            {

            }
            finally
            {
                FillDataGridProduct();
            }
        }
    }
}