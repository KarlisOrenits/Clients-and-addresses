using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clients_and_addresses.Data;
using Clients_and_addresses.Models;

namespace Clients_and_addresses.Controllers
{
    public class AddressesController : Controller
    {
        private readonly CustomerContext _context;

        public AddressesController(CustomerContext context)
        {
            _context = context;
        }

        // GET: Addresses

        public async Task<IActionResult> Index()
        {
            var addressList = _context.Address.Include(a => a.Country).Include(a => a.Customer)
            .Select(address => new AddressDTO
            {
                ID = address.ID,
                CustomerID = address.CustomerID,
                CountryID = address.CountryID,
                Customer = address.Customer,
                StreetAddress = address.StreetAddress,
                City = address.City,
                Zip = address.Zip,
                Country = address.Country,
                Name = address.Country.Name
               // Name = address.Country
            }).ToList();
            return View(addressList.ToList());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .Include(a => a.Country)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["CountryID"] = new SelectList(_context.Country, "CountryID", "Name");
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "FullName");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CustomerID,CountryID,StreetAddress,City,Zip,Type")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryID"] = new SelectList(_context.Country, "CountryID", "Name", address.CountryID);
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "FullName", address.CustomerID);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["CountryID"] = new SelectList(_context.Country, "CountryID", "Name", address.CountryID);
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "FullName", address.CustomerID);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CustomerID,CountryID,StreetAddress,City,Zip,Type")] Address address)
        {
            if (id != address.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryID"] = new SelectList(_context.Country, "CountryID", "", address.CountryID);
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "FullName", address.CustomerID);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .Include(a => a.Country)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Address.FindAsync(id);
            _context.Address.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.ID == id);
        }
    }
}
