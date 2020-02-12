using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashRegister.Data;
using CashRegister.Models;
using CashRegister.Models.DTOs;

namespace CashRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly CashRegisterDataContext _context;

        public ReceiptsController(CashRegisterDataContext context)
        {
            _context = context;
        }

        // GET: api/Receipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipt()
        {
            return await _context.Receipt.ToListAsync();
        }

        // GET: api/Receipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt>> GetReceipt(int id)
        {
            var receipt = await _context.Receipt.FindAsync(id);

            if (receipt == null)
            {
                return NotFound();
            }

            return receipt;
        }

        // PUT: api/Receipts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceipt(int id, Receipt receipt)
        {
            if (id != receipt.ReceiptId)
            {
                return BadRequest();
            }

            _context.Entry(receipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Receipts
        [HttpPost]
        public async Task<ActionResult<Receipt>> PostReceipt(List<ReceiptLineDto> receiptLines)
        {
            var newReceipt = new Receipt
            {
                Timestamp = DateTime.UtcNow
            };

            if (receiptLines.Count < 1)
            {
                return BadRequest("There has to be at least one Receipt line");
            }

            try
            {
                newReceipt.ReceiptLines = receiptLines.Select(rl => new ReceiptLine
                {
                    ReceiptLineId = 0,
                    Product = _context.Product.Find(rl.ProductId),
                    Amount = rl.Amount,
                    TotalPrice = rl.Amount * _context.Product.Find(rl.ProductId).Price
                }).ToList();
            }
            catch(NullReferenceException)
            {
                return BadRequest("This Product doesn't exist");
            }
            

            newReceipt.TotalPrice = newReceipt.ReceiptLines.Sum(rl => rl.TotalPrice);


            _context.Receipt.Add(newReceipt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceipt", new { id = newReceipt.ReceiptId }, receiptLines);
        }

        // DELETE: api/Receipts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Receipt>> DeleteReceipt(int id)
        {
            var receipt = await _context.Receipt.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }

            _context.Receipt.Remove(receipt);
            await _context.SaveChangesAsync();

            return receipt;
        }

        private bool ReceiptExists(int id)
        {
            return _context.Receipt.Any(e => e.ReceiptId == id);
        }
    }
}
