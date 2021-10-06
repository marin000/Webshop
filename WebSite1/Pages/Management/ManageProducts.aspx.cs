using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetImages();

            //check if url contains id
            if(!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                FillPage(id);
            }
        }
    }

    private void FillPage(int id)
    {
        //get selected product from db
        ProductModel productModel = new ProductModel();
        Product product = productModel.GetProduct(id);

        txtDescription.Text = product.Description;
        txtName.Text = product.Name;
        txtPrice.Text = product.Price.ToString();

        ddlImage.SelectedValue = product.Image;
        ddlType.SelectedValue = product.TypeId.ToString();

    }

    private void GetImages()
    {
        try
        {
            string[] images = Directory.GetFiles(Server.MapPath("~/Images/Products/"));

            var imageList = new List<string>();
            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                imageList.Add(imageName);
            }

            ddlImage.DataSource = imageList;
            ddlImage.AppendDataBoundItems = true;
            ddlImage.DataBind();

        }
        catch(Exception e)
        {
            lblResult.Text = e.ToString();
        }
    }

    private Product createProduct()
    {
        Product product = new Product();

        product.Name = txtName.Text;
        product.Price = Convert.ToInt32(txtPrice.Text);
        product.TypeId = Convert.ToInt32(ddlType.SelectedValue);
        product.Description = txtDescription.Text;
        product.Image = ddlImage.SelectedValue;

        return product;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductModel productModel = new ProductModel();
        Product product = createProduct();

        //check if url contains id
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            //id exist-update
            int id = Convert.ToInt32(Request.QueryString["id"]);
            lblResult.Text = productModel.UpdateProduct(id, product);
        }
        else
        {
            lblResult.Text = productModel.InsertProduct(product);
        }
    }
}