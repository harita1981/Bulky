//using BulkyWeb.Data;
//using BulkyWeb.Models;
using Bulky.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Bulky.Models;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public CompanyController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
            
        }

        //Displaying all Companys
        
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();

            
            return View(objCompanyList);
        }

        //Creating a Company

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            

            //ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"] = CategoryList;

            

            if(id==0 || id == null)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company companyObj = _unitOfWork.Company.Get(u=>u.Id == id);
                return View(companyObj);
            }

            
        }

        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            
            if (ModelState.IsValid)
            {
                


                if(CompanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                }

                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                }
                
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }

            else
            {


                

                return View(CompanyObj);
            }
            

        }

        

        //Deleting a Company


        

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new {data = objCompanyList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.Get(u=>u.Id == id);

            if(CompanyToBeDeleted == null)
            {
                return Json(new {success= false, message="Error while deleting."});
            }

            

            _unitOfWork.Company.Remove(CompanyToBeDeleted); 
            _unitOfWork.Save();


            return Json(new { success = true, message = "Company deleted successfully." });
        }




        #endregion
    }
}
