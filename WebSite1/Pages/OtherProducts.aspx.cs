using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    private void FillPage()
    {
        //get all products from db
        ProductModel productModel = new ProductModel();
        List<Product> products = productModel.GetAllProducts();

        if (products != null)
        {
            foreach (Product product in products)
            {
                ProductTypeModel type = new ProductTypeModel();
                ProductType typeName = type.GetType(product.TypeId);
                if (typeName.Name != "Laptop")
                {
                    Panel productPanel = new Panel();
                    ImageButton imageButton = new ImageButton();
                    Label lblName = new Label();
                    Label lblPrice = new Label();

                    imageButton.ImageUrl = "~/Images/Products/" + product.Image;
                    imageButton.CssClass = "productImage";
                    imageButton.PostBackUrl = "~/Pages/Product.aspx?id=" + product.id;

                    lblName.Text = product.Name;
                    lblName.CssClass = "productName";

                    lblPrice.Text = "$ " + product.Price;
                    lblPrice.CssClass = "productPrice";

                    productPanel.Controls.Add(imageButton);
                    productPanel.Controls.Add(new Literal { Text = "<br />" });
                    productPanel.Controls.Add(lblName);
                    productPanel.Controls.Add(new Literal { Text = "<br />" });
                    productPanel.Controls.Add(lblPrice);
                    productPanel.Controls.Add(new Literal { Text = "<br />" });

                    pnlProducts.Controls.Add(productPanel);
                }
            }
        }
        else
        {
            pnlProducts.Controls.Add(new Literal { Text = "No products found." });
        }
    }
}