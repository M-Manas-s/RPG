using RPG.Dtos.Character;
using RPG.Dtos.Weapon;
using RPG.Models;

namespace RPG.Interfaces
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}