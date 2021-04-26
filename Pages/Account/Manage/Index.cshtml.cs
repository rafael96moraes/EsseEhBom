using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using EsseEhBom.Data;
using System;

namespace EsseEhBom.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Primeiro nome")]
            public virtual string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Último nome")]
            public virtual string LateName { get; set; }

            [Required]
            [Display(Name = "Data de nascimento")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
            [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
            public virtual DateTime Birth { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Estado")]
            public virtual string State { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Cidade")]
            public virtual string City { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userInformation = await _userManager.GetUserAsync(User);
            
            Input = new InputModel
            {
                FirstName = userInformation.FirstName,
                LateName = userInformation.LateName,
                Birth = userInformation.Birth,
                State = userInformation.State,
                City = userInformation.City
            };
        }

        private async Task<ApplicationUser> EditUser()
        {
            var userInformation = await _userManager.GetUserAsync(User);
            userInformation.FirstName = Input.FirstName;
            userInformation.LateName = Input.LateName;
            userInformation.Birth = Input.Birth;
            userInformation.State = Input.State;
            userInformation.City = Input.City;

            return userInformation;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o ID do usuário '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o ID do usuário {_userManager.GetUserId(User)}.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userEdited = EditUser().Result;
            var result = await _userManager.UpdateAsync(userEdited);
            if (result.Succeeded)
            {
                StatusMessage = "Sua conta foi alterada com sucesso.";
            }
            else
            {
                StatusMessage = "Erro inesperado! As informações não foram alteradas!";
            }   

            return RedirectToPage();
        }
    }
}