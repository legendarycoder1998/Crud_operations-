using Demo_Crud_operations.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Crud_operations.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        categoryEntities dbobj = new categoryEntities();
        public ActionResult Category(Product_list obj)
        {
            
                return View(obj);
           
        }
        [HttpPost]
        public ActionResult AddCategory(Product_list model)
        {
            if (ModelState.IsValid)
            {
                Product_list obj = new Product_list();
                obj.ProductId = model.ProductId;
                obj.ProductName = model.ProductName;
                obj.CategoryId = model.CategoryId;
                obj.CategoryName = model.CategoryName;
                if (model.CategoryId>0)
                {
                    dbobj.Product_list.Add(obj);
                    dbobj.SaveChanges();
                }
                else
                {
                    dbobj.Product_list.Add(obj);
                    dbobj.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("CategoryList");
        }
            public ActionResult CategoryList()
            {
            var res = dbobj.Product_list.ToList();
                return View(res);
            }

        public ActionResult Delete(int Categoryid)
        {
            var res = dbobj.Product_list.Where(x => x.CategoryId == Categoryid).First();
            dbobj.Product_list.Remove(res);
            dbobj.SaveChanges();
           
            var list = dbobj.Product_list.ToList();
            return View("CategoryList",list);
        }
      
        }

    }

        
    
