using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallet.Api.Data;
using Wallet.Api.Entities;

namespace Wallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletAddressesController : ControllerBase
    {
        private readonly WalletApiContext _context;

        public WalletAddressesController(WalletApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<string> PostWalletAddress(WalletAddress walletAddress)
        {
            try
            {
                if (_context.WalletAddress.Any(x => x.Name == walletAddress.Name))
                    return "ERROR: This wallet address already exist";

                _context.WalletAddress.Add(walletAddress);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }

            return "SUCCESS";
        }
    }
}
