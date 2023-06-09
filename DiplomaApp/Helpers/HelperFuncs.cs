﻿using DiplomaApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiplomaApp.Helpers
{
    public interface IHelperFuncs
    {
        Task<double> CalculatePrice(int glassPaneId);
    }
    public class HelperFuncs : IHelperFuncs
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;


        public HelperFuncs(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _userManager = userManager;
            _httpContext = httpContext;
        }

        public async Task<double> CalculatePrice(int glassPaneId)
        {
            var userId = _userManager.GetUserId(_httpContext.HttpContext.User);

            var glassPane = await _context.GlassPaneParent.Include(a => a.Wings).FirstOrDefaultAsync(s => s.GlassPaneId == glassPaneId);

            var price1 = await GetPrice(glassPane.ProfileTypeMaterial.ToString()); //21.80
            var price2 = 10; // цена за делител 
            var price3 = await GetPrice(glassPane.WindowType.ToString()); //33.60
            var price4 = 30; // обков 
            var price5 = 43; // обков комби
            var price6 = await GetPrice(glassPane.ProfileType.ToString()); // камери
            var profileLenght = 0.0;
            var glassPaneLength = glassPane.Length / 1000;
            var glassPaneHeight= glassPane.Hight / 1000;

            foreach (var krilo in glassPane.Wings)
            {
                if (krilo.IsOpen)
                {
                    profileLenght += ((krilo.Length + krilo.Hight) * 2) / 1000;
                }
            }

            var kasa = (((glassPaneLength + glassPaneHeight) * 2) + profileLenght) * price1;
            var delitel = ((glassPaneHeight * price1) + price2) * (glassPane.WingsCount - 1);
            var djam = ((glassPaneLength * glassPaneHeight) * price3) * 0.95;
            var obkovOtwarqne = glassPane.Wings.Where(a => a.IsOpen == true && a.IsCombined == false).Count() * price4;
            var obkovOtwarqneKombi = glassPane.Wings.Where(a => a.IsOpen == true && a.IsCombined == true).Count() * price5;

            var res = kasa * price6 + delitel * price6 + djam + obkovOtwarqne + obkovOtwarqneKombi;

            glassPane.TotalPrice = Math.Round(res, 2);

            _context.GlassPaneParent.Attach(glassPane);
            await _context.SaveChangesAsync();
            return res;
        }

        private async Task<double> GetPrice(string element) =>
             await _context.Price.Where(a => a.Element == element).Select(a => a.PriceValue).FirstOrDefaultAsync();
        
    }
}
