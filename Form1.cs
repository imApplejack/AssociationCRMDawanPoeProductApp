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

        }



        void FillDataGridProduct()
        {
            ProductDatagrid.DataSource = ProductService.GetAll();
        }

    }
}