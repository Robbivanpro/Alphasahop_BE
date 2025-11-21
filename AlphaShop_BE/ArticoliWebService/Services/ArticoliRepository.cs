using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using ArticoliWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticoliWebService.Services
{
    public class ArticoliRepository : IArticoliRepository
    {
        AlphaShopDbContext alphaShopDbContext;

        public ArticoliRepository(AlphaShopDbContext alphaShopDbContext)
        {
            this.alphaShopDbContext =  alphaShopDbContext;
        }

        public async Task<ICollection<Articoli>> SelArticoliByDescrizione(string Descrizione) => 
                await this.alphaShopDbContext.Articoli
                .Where(a => a.Descrizione!.Contains(Descrizione))
                    .Include(a => a.barcode)
                    .Include(a => a.iva)
                    .Include(a => a.famAssort)
                .OrderBy(a => a.Descrizione)
                .ToListAsync();

        public async Task<Articoli> SelArticoloByCodice(string Code) => 
                await this.alphaShopDbContext.Articoli
                    .Where(a => a.CodArt!.Equals(Code))
                        .Include(a => a.barcode)
                        .Include(a => a.iva)
                        .Include(a => a.famAssort)
                    .FirstOrDefaultAsync();

        public async Task<Articoli> SelArticoloByEan(string Ean) => 
                await this.alphaShopDbContext.Barcode
                    .Where(b => b.Barcode!.Equals(Ean))
                        .Include(a => a.articolo!.barcode!)                                
                        .Include(a => a.articolo!.famAssort!)
                        .Include(a => a.articolo!.iva!)
                    .Select(a => a.articolo)
                    .FirstOrDefaultAsync();

        public bool InsArticoli(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }

        public bool DelArticoli(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }

        public bool Salva()
        {
            throw new System.NotImplementedException();
        }

        public bool UpdArticoli(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ArticoloExists(string Code) =>
            await this.alphaShopDbContext.Articoli
                .AnyAsync(c => c.CodArt == Code);
        
    }
}