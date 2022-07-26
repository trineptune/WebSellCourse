using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using System.Text.Json;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Library_Class.Entities;
using Library_Class.Repository;
using Web_Học_Trực_Tuyến.Models;
namespace Web_Học_Trực_Tuyến.Controllers
{
    public class ShoppingController : Controller
    {
        ChiTietDatHangRepository chitietdathangs=new ChiTietDatHangRepository();
        pdkladykillah_eLearningContext pdkcontext= new pdkladykillah_eLearningContext();
        public IActionResult Index()
        {
            ViewBag.Title = "Shopping Cart";
            
            var sessionId = HttpContext.Session.Id;
            ViewBag.sessionId = sessionId;

            List<ItemCart> items = null;
            //doc session
            var yourcart = HttpContext.Session.GetString("yourcart");
            //chuyen string json --> object
            if (yourcart != null)
            {
                items = (List<ItemCart>)JsonSerializer.Deserialize(yourcart, typeof(List<ItemCart>));

            }
            else
            {
                
                items = new List<ItemCart>();
            }

            ViewBag.Cart = items;

            //total

            decimal total = 0;
            foreach (ItemCart item in items)
            {
                decimal priceall = item.Price - item.giagiam;
                total += priceall * item.Quantity;
            }
            
            ViewBag.Total = total;
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart()
        {
            int id = int.Parse(Request.Form["Id"].ToString());
            int quantity = int.Parse(Request.Form["siQty"].ToString());

            List<ItemCart> items = null;
            //doc session
            var yourcart = HttpContext.Session.GetString("yourcart");
            //chuyen string json --> object
            if (yourcart != null)
            {
                items = (List<ItemCart>)JsonSerializer.Deserialize(yourcart, typeof(List<ItemCart>));

            }
            else
            {

                items = new List<ItemCart>();
            }
            //tim san pham co trong db
            KhoaHocOnline khoahocs = pdkcontext.KhoaHocOnlines.Where(x => x.Id == id).SingleOrDefault();
            //tao item trong gio hang
            
            ItemCart item = new ItemCart()
            {

                Id = id,
                Quantity = quantity,
                Image = khoahocs.LinkHinhAnh,
                Price = (decimal)khoahocs.GiaGoc,
                giagiam = (decimal)khoahocs.GiaGiam,
                Name = khoahocs.TenKhoaHoc
            };
            //bo item vao gio hang
            items.Add(item);
            // luu session
            HttpContext.Session.SetString("yourcart", JsonSerializer.Serialize(items, typeof(List<ItemCart>)));


            return RedirectToAction("Index");
        }
        public IActionResult Dathang(ChiTietDatHang DatHang)
        {
            chitietdathangs.CreateChiTietDatHang(DatHang);


            return RedirectToAction("Index");
        }
    }
}
