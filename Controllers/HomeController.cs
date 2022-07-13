using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Store.Models;
namespace E_Store.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {


            return View(db.Categories.ToList());
        }



        public ActionResult About()
        {
            ViewBag.Message = "Our application is a ASP.NET web app Project.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "lorum posum";

            return View();
        }

        public ActionResult AddToCart(int ID_P)
        {
            var product = db.Products.Find(ID_P);
            if (Session["cart"] == null) {
                List<Cartitem> Cart = new List<Cartitem>();



                Cart.Add(new Cartitem()
                {
                    Product = product,
                    Quantity = 1
                }
                );

                Session["cart"] = Cart;
            }

            else if (Session["cart"] != null)
            {


                List<Cartitem> Cart = (List<Cartitem>)Session["cart"];
                int indexof = isExiste(ID_P);

                if (indexof == -1)
                {
                    Cart.Add(new Cartitem()
                    {
                        Product = product,
                        Quantity = 1
                    });

                }
                else
                    Cart[indexof].Quantity++;

                Session["cart"] = Cart;
            }




            return Redirect(Request.UrlReferrer.ToString());

        }

        public ActionResult RemoveFromCart(int ID_P)
        {
            List<Cartitem> Cart = (List<Cartitem>)Session["cart"];
            int indexof = isExiste(ID_P);
     
                if (indexof != -1)
                {
                    if (Cart[indexof].Quantity == 1)
                    {
                    Cart.RemoveAt(indexof);
                }
                    else
                    Cart[indexof].Quantity--;

                }
            
            Session["cart"] = Cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult ViewCart()
        {
            if (Session["cart"] == null)
            {
            ViewBag.Message = "NO Item has been Selected !!! ";

                return View();
            }
            else

            {
                List<Cartitem> Cart = (List<Cartitem>)Session["cart"];
                ViewBag.cpt = Cart.Count();
                if(Cart.Count() == 0)
                {
                    ViewBag.Message = "NO Item has been Selected !!! ";
                }
                ViewBag.total = 0;
                foreach (Cartitem item in Cart) {
                    ViewBag.total += (item.Quantity * item.Product.Price);

                }

                ViewData["Cart"] = Cart;
                     Session["cart"] = Cart;
;                return View();
            }
         
        }
        
        private int isExiste(int ID_P) {
            List<Cartitem> Cart = (List<Cartitem>)Session["cart"];
            if (Cart.Exists(p => p.Product.ID == ID_P) == true)
            {
                return Cart.FindIndex(p => p.Product.ID == ID_P);
            }
            else return -1;

        }

       

        public ContentResult GetImage()
        {

            return new ContentResult
                    {
                Content = "Hi there! ",
    ContentType = "text/plain; charset=utf-8"
};
        }

    }
}