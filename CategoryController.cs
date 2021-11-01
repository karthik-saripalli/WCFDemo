using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientConsumeData.Models;
using ClientConsumeData.ServiceReference1;
using System.Data.SqlClient;
using System.Data;

namespace ClientConsumeData.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public static List<Category> clist = new List<Category>();
        public ActionResult Index()
        {
            SqlConnection con = new SqlConnection("server=LAPTOP-362TBH8P\\SQLEXPRESS;Integrated Security=True;database=northwind");
            SqlDataAdapter da = new SqlDataAdapter("select * from Categories", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Category c = new Category();
                c.catid =Convert.ToInt32( ds.Tables[0].Rows[i][0]);
                c.catname = ds.Tables[0].Rows[i][1].ToString();
                c.desc = ds.Tables[0].Rows[i][2].ToString();
                clist.Add(c);
            }

            return View(clist);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
       
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category c)
        {
            Service1Client client = new Service1Client();  
            try
            {
                NewCategory c1 = new NewCategory();
                c1.Catname = c.catname;
                c1.desc = c.desc;
                client.AddCategory(c1,"LAPTOP-362TBH8P\\SQLEXPRESS","northwind","","");
                clist.Add(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
