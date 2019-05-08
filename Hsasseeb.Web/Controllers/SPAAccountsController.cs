using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hasseeb.Application.Domain;
using Hasseeb.Application.Service;
using Hasseeb.Application.ViewModels;
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

        public JsonResult AllAccounts()
        {
            var list = _accountAppService.GetAll();

            return Json(list);

        }

        public IActionResult GetAccountByID(int id)
        {
            var account = _accountAppService.GetID(id);
            var ParentAccount = new Account();
            var accountNature = new AccountNature();
            if (account.ParentAccountID != null)
            {
                 ParentAccount = _accountAppService.GetID((int)account.ParentAccountID);
            }
            if (account.AccountNatureID != null)
            {
                accountNature = _accNatureAppService.GetID((int)account.AccountNatureID);
            }
            AccountViewModel model = new AccountViewModel();
            model.ID = account.ID;
            model.AccountDesc = account.AccountDesc;
            model.AccountName = account.AccountName;
            model.AccountNatureID = account.AccountNatureID;
            model.AccountNatureName = accountNature.AccountNatureName;
            model.AccountSerial = account.AccountSerial;
            model.Active = account.Active;
            model.GroupOrder = account.GroupOrder;
            model.IsMain = account.IsMain;
            model.ParentAccountID = account.ParentAccountID;
            model.ParentAccountName = ParentAccount.AccountName;
            return Json(model);

        }

      
        [HttpPost]
        public JsonResult Save(Account account)
        {
            account.AddDate = DateTime.Now;
            var newAccount = _accountAppService.GetID(account.ID);
            if (ModelState.IsValid)
            {

                if (newAccount == null)
                {
                    _accountAppService.Insert(account);


                }
                else
                {
                    _accountAppService.Update(account);

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