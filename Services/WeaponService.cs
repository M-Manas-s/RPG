using System.Security.Claims;
using AutoMapper;
using RPG.Data;
using RPG.Dtos.Character;
using RPG.Dtos.Weapon;
using RPG.Interfaces;
using RPG.Models;

namespace RPG.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            try 
            {
                var character= await _context.Characters.FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId && c.User!.Id == int.Parse(
                    _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!
                ));
                if ( character is null )
                    throw new Exception($"Character with Id '{newWeapon.CharacterId}' not found.");
                
                var weapon = _mapper.Map<Weapon>(newWeapon);
                _context.Weapons.Add(weapon);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);

            }   
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}