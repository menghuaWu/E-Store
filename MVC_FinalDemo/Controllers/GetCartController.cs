﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_FinalDemo.Models;

namespace MVC_FinalDemo.Controllers
{
    public class GetCartController : ApiController
    {
        dbEStoreEntities db = new dbEStoreEntities();
        // GET: api/GetCart
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetCart/5
        public IEnumerable<tCart> Get(string cName)
        {
            var carts = db.tCart.Where(m=>m.fCustomerName == cName).ToList();
            return carts;
        }

        // POST: api/GetCart
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetCart/5
        public bool Put(int id, string cName, string pName)
        {
            var cart = db.tCart.Where(m => m.fCustomerName == cName && m.fProductName == pName).FirstOrDefault();
            var price = cart.fProductPrice;
            int k = 0;
            if (id == 0)
            {
                try
                {
                    
                    cart.fProductCount++;
                    cart.fTotalPrice = cart.fProductCount * cart.fProductPrice;
                    k = db.SaveChanges();
                }
                catch (Exception)
                {
                    k = 0;
                }
                
                if (k != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    if (cart.fProductCount == 1)
                    {
                        return false;
                    }
                    cart.fProductCount--;
                    cart.fTotalPrice = cart.fProductCount * cart.fProductPrice;
                    k = db.SaveChanges();
                    
                }
                catch (Exception)
                {
                    k = 0;
                }
                if (k != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // DELETE: api/GetCart/5
        public bool Delete(string cName, string pName)
        {
            int k = 0;
            try
            {
                var cart = db.tCart.Where(m => m.fCustomerName == cName && m.fProductName == pName).FirstOrDefault();
                db.tCart.Remove(cart);
                k = db.SaveChanges();
            }
            catch (Exception)
            {
                k = 0;
            }

            if (k != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}