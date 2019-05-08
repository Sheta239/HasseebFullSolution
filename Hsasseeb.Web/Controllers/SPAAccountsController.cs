using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hasseeb.Application.Domain;
using Hasseeb.Application.Service;
using Hasseeb.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReflectionIT.Mvc.Paging;

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
            var geatAll = _accountAppService.GetAll();

            List<Account> Parent = new List<Account>();
            foreach (var item in geatAll)
            {
                Account viewPar = new Account();
                if (item.ParentAccountID == null || item.ParentAccountID == 0)
                {
                    viewPar.AccountDesc = item.AccountDesc;
                    viewPar.ID = item.ID;
                    viewPar.AccountName = item.AccountName;
                    viewPar.AccountNatureID = item.AccountNatureID;
                    viewPar.AccountSerial = item.AccountSerial;
                    viewPar.Active = item.Active;
                    viewPar.AddDate = item.AddDate;
                    viewPar.GroupOrder = item.GroupOrder;
                    viewPar.IsMain = item.IsMain;
                    viewPar.ParentAccountID = item.ParentAccountID;
                    Parent.Add(viewPar);

                }

            }
            return View(Parent);
        }
        public JsonResult GetSubMenu(string pid)
        {
            System.Threading.Thread.Sleep(5000);
            var geatAll = _accountAppService.GetAll();
            List<Account> Child = new List<Account>();
            int pID = 0;
            int.TryParse(pid, out pID);

            foreach (var item in geatAll)
            {
                Account viewPar = new Account();
                if (item.ParentAccountID == pID)
                {
                    viewPar.AccountDesc = item.AccountDesc;
                    viewPar.ID = item.ID;
                    viewPar.AccountName = item.AccountName;
                    viewPar.AccountNatureID = item.AccountNatureID;
                    viewPar.AccountSerial = item.AccountSerial;
                    viewPar.Active = item.Active;
                    viewPar.AddDate = item.AddDate;
                    viewPar.GroupOrder = item.GroupOrder;
                    viewPar.IsMain = item.IsMain;
                    viewPar.ParentAccountID = item.ParentAccountID;
                    Child.Add(viewPar);
                }
            }

            return Json(Child);
            ////return new JsonResult { Data = Child, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult AccountNatures()
        {
            return Json(_accNatureAppService.GetAll());
        }

        #region SPA Accounts 

        public IActionResult GetAccounts(int pageNumber = 1, int pageSize = 20)
        {
            var list = _accountAppService.GetAll();

            var pagedData = Pagination.PagedResult(list, pageNumber, pageSize);
            return Json(pagedData);

        }


        public IActionResult GetAccountByID(int id)
        {
            var account = _accountAppService.GetID(id);
            return Json(account);

        }

      
        [HttpPost]
        public JsonResult Save(Account account)
        {
            account.AddDate = DateTime.Now;
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
           
            return Json(account);
        }
        
        [HttpPost]
        public JsonResult DeleteAccount(int ID)
        {
            bool status = false;

           status = _accountAppService.Delete(ID);
            return Json(new { status = status });

        }
        #endregion
    }
}