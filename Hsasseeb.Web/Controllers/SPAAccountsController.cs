using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hasseeb.Application.Domain;
using Hasseeb.Application.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hsasseeb.Web.Controllers
{
    public class SPAAccountsController : Controller
    { 


    private readonly IAccountManager _accountAppService;
    private readonly IAccountNatureManager _accNatureAppService;


    public SPAAccountsController(IAccountManager accountAppService, IAccountNatureManager accNatureAppService)
    {
        _accountAppService = accountAppService;
        _accNatureAppService = accNatureAppService;
    }
    public IActionResult Index()
        {

            return View();
        }

        public JsonResult AccountNatures()
        {
            return Json(_accNatureAppService.GetAll());
        }

        #region SPA Accounts 

        public IActionResult GetAccounts()
        {
            var list = _accountAppService.GetAll();
            return Json(list);
           
        }


        public IActionResult GetAccountByID(int id)
        {
            var account = _accountAppService.GetID(id);
            return Json(account);

        }

      
        [HttpPost]
        public ActionResult Save(Account account)
        {
            var newAccount = _accountAppService.GetID(account.ID);
            if (ModelState.IsValid)
            {

                if (newAccount != null)
                {
                    _accountAppService.Update(account);

                }
                else
                {
                    _accountAppService.Insert(account);
                }

            }
           
            return View(account);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteAccount(int ID)
        {
            bool status = false;

            _accountAppService.Delete(ID);
            return Json(new { status = status });

        }
        #endregion
    }
}