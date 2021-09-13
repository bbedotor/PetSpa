using PetSpa.API.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PetSpa.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckPetTypesAsync();
            await CheckBreedsAsync();
            await CheckDocumentTypesAsync();
            await CheckTreatmentsAsync();
        }

        private async Task CheckTreatmentsAsync()
        {
            if (!_context.Treatments.Any())
            {
                _context.Treatments.Add(new Treatment { price = 10000, Description = "Baño simple" });
                _context.Treatments.Add(new Treatment { price = 15000, Description = "Baño AntiPulgas" });
                _context.Treatments.Add(new Treatment { price = 20000, Description = "Baño Antipulgas Completo" });
                _context.Treatments.Add(new Treatment { price = 25000, Description = "Peluqueria" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Description = "Cédula" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Tarjeta de Identidad" });
                _context.DocumentTypes.Add(new DocumentType { Description = "NIT" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckBreedsAsync()
        {
            if (!_context.Breeds.Any())
            {
                _context.Breeds.Add(new Breed { Description = "Pastor Aleman" });
                _context.Breeds.Add(new Breed { Description = "Labrador" });
                _context.Breeds.Add(new Breed { Description = "Pitbull" });
                _context.Breeds.Add(new Breed { Description = "Doberman" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPetTypesAsync()
        {
            if (!_context.PetTypes.Any())
            {
                _context.PetTypes.Add(new PetType { Description = "Perro" });
                _context.PetTypes.Add(new PetType { Description = "Gato" });
                _context.PetTypes.Add(new PetType { Description = "Hamnster" });
                await _context.SaveChangesAsync();


            }

        }
    }
}
