using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;


namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
   public IActionResult Index(){

     IEnumerable<Category>objCategoryList =_db.Categories;

    return View(objCategoryList);

   }

   //GET
   public IActionResult Create(){

    return View();

   }

   //POST
   [HttpPost]//This would be a post functionality on this Create Action
   [ValidateAntiForgeryToken]
   public IActionResult Create(Category obj){

    if(ModelState.IsValid){
     _db.Categories.Add(obj);// This line doesnt necessarily save the changes to the database;
     _db.SaveChanges(); //This is what saves the changes to the database
    return RedirectToAction("Index");
    }

    return View(obj);

   }
   
}   