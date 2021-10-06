using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductModel
/// </summary>
public class ProductModel
{
    public string InsertProduct(Product product)
    {
        try
        {
            WebShopDBEntities db = new WebShopDBEntities();
            db.Products.Add(product);
            db.SaveChanges();
            return product.Name + "was succesfully inserted.";
        }
        catch(Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateProduct(int id,Product product)
    {
        try
        {
            WebShopDBEntities db = new WebShopDBEntities();
            Product p = db.Products.Find(id);

            p.Name = product.Name;
            p.Price = product.Price;
            p.Image = product.Image;
            p.Description = product.Description;
            p.TypeId = product.TypeId;

            db.SaveChanges();
            return product.Name + "was succesfully updated.";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteProduct(int id)
    {
        try
        {
            WebShopDBEntities db = new WebShopDBEntities();
            Product product = db.Products.Find(id);

            db.Products.Attach(product);
            db.Products.Remove(product);
            db.SaveChanges();

            return product.Name + "was succesfully deleted.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public Product GetProduct(int id)
    {
        try
        {
            using (WebShopDBEntities db = new WebShopDBEntities())
            {
                Product product = db.Products.Find(id);
                return product;
            }
        }
        catch(Exception e)
        {
            return null;
        }
    }

    public List<Product>GetAllProducts()
    {
        try
        {
            using (WebShopDBEntities db = new WebShopDBEntities())
            {
                List<Product> products = (from x in db.Products select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Product>GetProductsByType(int typeId)
    {
        try
        {
            using (WebShopDBEntities db = new WebShopDBEntities())
            {
                List<Product> products = (from x in db.Products
                                          where x.TypeId == typeId
                                          select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
}