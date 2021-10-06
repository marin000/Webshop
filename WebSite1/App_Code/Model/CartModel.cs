using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartModel
/// </summary>
public class CartModel
{
    public string InsertCart(Cart cart)
    {
        try
        {
            WebShopDBEntities db = new WebShopDBEntities();
            db.Carts.Add(cart);
            db.SaveChanges();
            return "Succesfully inserted.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateCart(int id, Cart cart)
    {
        try
        {
            WebShopDBEntities db = new WebShopDBEntities();
            Cart p = db.Carts.Find(id);

            p.ClientId = cart.ClientId;
            p.ProductId = cart.ProductId;
            p.Amount = cart.Amount;
            p.IsInCart = cart.IsInCart;

            db.SaveChanges();
            return "Succesfully updated.";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteCart(int id)
    {
        try
        {
            WebShopDBEntities db = new WebShopDBEntities();
            Cart cart = db.Carts.Find(id);

            db.Carts.Attach(cart);
            db.Carts.Remove(cart);
            db.SaveChanges();

            return "Succesfully deleted.";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public List<Cart>GetOrdersInCart(string userId)
    {
        WebShopDBEntities db = new WebShopDBEntities();
        List<Cart> orders = (from x in db.Carts
                             where x.ClientId == userId
                             && x.IsInCart
                             select x).ToList();
        return orders;
    }

    public int GetAmountOfOrders(string userId)
    {
        try
        {
            WebShopDBEntities db = new WebShopDBEntities();
            int amount= (from x in db.Carts
                         where x.ClientId == userId
                         && x.IsInCart
                         select x.Amount).Sum();
            return amount;
        }
        catch
        {
            return 0;
        }

    }

    public void UpdateQuantity(int id,int quantity)
    {
        WebShopDBEntities db = new WebShopDBEntities();
        Cart cart = db.Carts.Find(id);
        cart.Amount = quantity;
        db.SaveChanges();
    }

    public void MarkOrderAsPaid(List<Cart>carts)
    {
        WebShopDBEntities db = new WebShopDBEntities();
        if(carts!=null)
        {
            foreach(Cart cart in carts)
            {
                Cart oldCart = db.Carts.Find(cart.id);
                oldCart.IsInCart = false;
            }
            db.SaveChanges();
        }
    }
}