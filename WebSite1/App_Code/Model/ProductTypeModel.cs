using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductTypeType
/// </summary>
public class ProductTypeModel
{
    public string InsertProductType(ProductType productType)
    {
        try
        {
            WebShopDBEntities db = new WebShopDBEntities();
            db.ProductTypes.Add(productType);
            db.SaveChanges();
            return productType.Name + "was succesfully inserted.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateProductType(int id, ProductType productType)
    {
        try
        {
            WebShopDBEntities db = new WebShopDBEntities();
            ProductType p = db.ProductTypes.Find(id);

            p.Name = productType.Name;
           
            db.SaveChanges();
            return productType.Name + "was succesfully updated.";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteProductType(int id)
    {
        try
        {
            WebShopDBEntities db = new WebShopDBEntities();
            ProductType productType = db.ProductTypes.Find(id);

            db.ProductTypes.Attach(productType);
            db.ProductTypes.Remove(productType);
            db.SaveChanges();

            return productType.Name + "was succesfully deleted.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public ProductType GetType(int typeid)
    {
        WebShopDBEntities db = new WebShopDBEntities();
        ProductType productType = db.ProductTypes.Find(typeid);
        return productType;
    }
}