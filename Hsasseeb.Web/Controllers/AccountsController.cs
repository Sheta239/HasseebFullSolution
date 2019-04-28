﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hasseeb.Application.Domain;
using Hsasseeb.Web.Data;
using Hasseeb.Application.Service;

namespace Hsasseeb.Web.Controllers
{
    public class AccountsController : Controller
    {
      
            private readonly IAccountManager _accountAppService;


            public AccountsController(IAccountManager accountAppService)
            {
                _accountAppService = accountAppService;
            }

        

        // GET: Accounts
        public  IActionResult Index()
        {
            var applicationDbContext = _accountAppService.GetAll();
            return View(applicationDbContext);
        }

        //// GET: Accounts/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var account = await _context.Accounts
        //        .Include(a => a.AccountNature)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(account);
        //}

        //// GET: Accounts/Create
        //public IActionResult Create()
        //{
        //    ViewData["AccountNatureID"] = new SelectList(_context.AccountNatures, "ID", "ID");
        //    return View();
        //}

        //// POST: Accounts/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AccountNatureID,ParentAccountID,AccountSerial,AccountName,AccountDesc,GroupOrder,Active,AddDate,IsMain,ID")] Account account)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(account);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AccountNatureID"] = new SelectList(_context.AccountNatures, "ID", "ID", account.AccountNatureID);
        //    return View(account);
        //}

        //// GET: Accounts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var account = await _context.Accounts.FindAsync(id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["AccountNatureID"] = new SelectList(_context.AccountNatures, "ID", "ID", account.AccountNatureID);
        //    return View(account);
        //}

        //// POST: Accounts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("AccountNatureID,ParentAccountID,AccountSerial,AccountName,AccountDesc,GroupOrder,Active,AddDate,IsMain,ID")] Account account)
        //{
        //    if (id != account.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(account);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AccountExists(account.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AccountNatureID"] = new SelectList(_context.AccountNatures, "ID", "ID", account.AccountNatureID);
        //    return View(account);
        //}

        //// GET: Accounts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var account = await _context.Accounts
        //        .Include(a => a.AccountNature)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(account);
        //}

        //// POST: Accounts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var account = await _context.Accounts.FindAsync(id);
        //    _context.Accounts.Remove(account);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AccountExists(int id)
        //{
        //    return _context.Accounts.Any(e => e.ID == id);
        //}
    }
}
