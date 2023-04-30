using AutoMapper;
using RPG.Dtos.Character;
using RPG.Dtos.Skill;
using RPG.Dtos.Weapon;
using RPG.Models;

namespace RPG
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Character,GetCharacterDto>();
            CreateMap<UpdateCharacterDto, Character>();
            CreateMap<AddWeaponDto, Weapon>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
        }
    }
}