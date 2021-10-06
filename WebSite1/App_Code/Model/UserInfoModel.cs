using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfoModel
/// </summary>
public class UserInfoModel
{ 
    public UserInformation GetUserInformatio(string guid)
    {
        WebShopDBEntities db = new WebShopDBEntities();
        UserInformation info = (from x in db.UserInformations
                                where x.GUID == guid
                                select x).FirstOrDefault();
        return info;
    }

    public void InsertUserInformation(UserInformation info)
    {
        WebShopDBEntities db = new WebShopDBEntities();
        db.UserInformations.Add(info);
        db.SaveChanges();
    }

}