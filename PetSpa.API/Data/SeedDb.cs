using PetSpa.API.Data.Entities;
using PetSpa.API.Helpers;
using PetSpa.Common.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PetSpa.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckPetTypesAsync();
            await CheckBreedsAsync();
            await CheckDocumentTypesAsync();
            await CheckTreatmentsAsync();
            await CheckRolesASync();
            await CheckUserAsync("1010", "brayan", "bedoya", "brayan@yopmail.com", "300 789 9380", "Calle 1l", UserType.admin);
            await CheckUserAsync("2020", "camila", "toro", "camila@yopmail.com", "320 143 4567", "Calle Luna Calle Sol", UserType.User);
        }

        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User 
                {
                    Address = address,
                    Document =document,
                    DocumentType= _context.DocumentTypes.FirstOrDefault(x => x.Description == "Cédula"),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                    
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

            }
        }

        private async Task CheckRolesASync()
        {
            await _userHelper.CheckRoleAsync(UserType.admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

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
