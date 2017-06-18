using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tenorchem.Models;

namespace tenorchem.Controllers
{
    public class PurchaseRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRecordsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PurchaseRecords
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaseRecords.Include(p => p.Product).Include(p => p.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRecord = await _context.PurchaseRecords
                .Include(p => p.Product)
                .Include(p => p.Supplier)
                .SingleOrDefaultAsync(m => m.PurchaseRecordId == id);
            if (purchaseRecord == null)
            {
                return NotFound();
            }

            return View(purchaseRecord);
        }

        // GET: PurchaseRecords/Create
        public IActionResult Create()
        {
            var products = _context.Products;
            foreach (var product in products){
                product.Name = product.Name +'('+ product.Purity+')';
            }
            ViewData["ProductId"] = new SelectList(products, "ProductId", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName");
            return View();
        }

        // POST: PurchaseRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseRecordId,SupplierId,PurchaseDate,PricePerTon,Quantity,TotalPaidPrice,PaidBackPerTon,TotalPaidBack,comment,ProductId")] PurchaseRecord purchaseRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var products = _context.Products;
            foreach (var product in products){
                product.Name = product.Name +'('+ product.Purity+')';
            }
            ViewData["ProductId"] = new SelectList(products, "ProductId", "Name", purchaseRecord.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", purchaseRecord.SupplierId);
            return View(purchaseRecord);
        }

        // GET: PurchaseRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRecord = await _context.PurchaseRecords.SingleOrDefaultAsync(m => m.PurchaseRecordId == id);
            if (purchaseRecord == null)
            {
                return NotFound();
            }
            var products = _context.Products;
            foreach (var product in products){
                product.Name = product.Name +'('+ product.Purity+')';
            }
            ViewData["ProductId"] = new SelectList(products, "ProductId", "Name", purchaseRecord.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", purchaseRecord.SupplierId);
            return View(purchaseRecord);
        }

        // POST: PurchaseRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseRecordId,SupplierId,PurchaseDate,PricePerTon,Quantity,TotalPaidPrice,PaidBackPerTon,TotalPaidBack,comment,ProductId")] PurchaseRecord purchaseRecord)
        {
            if (id != purchaseRecord.PurchaseRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseRecordExists(purchaseRecord.PurchaseRecordId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            var products = _context.Products;
            foreach (var product in products){
                product.Name = product.Name +'('+ product.Purity+')';
            }
            ViewData["ProductId"] = new SelectList(products, "ProductId", "Name", purchaseRecord.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", purchaseRecord.SupplierId);
            return View(purchaseRecord);
        }

        // GET: PurchaseRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRecord = await _context.PurchaseRecords
                .Include(p => p.Product)
                .Include(p => p.Supplier)
                .SingleOrDefaultAsync(m => m.PurchaseRecordId == id);
            if (purchaseRecord == null)
            {
                return NotFound();
            }

            return View(purchaseRecord);
        }

        // POST: PurchaseRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseRecord = await _context.PurchaseRecords.SingleOrDefaultAsync(m => m.PurchaseRecordId == id);
            _context.PurchaseRecords.Remove(purchaseRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PurchaseRecordExists(int id)
        {
            return _context.PurchaseRecords.Any(e => e.PurchaseRecordId == id);
        }
    }
}
