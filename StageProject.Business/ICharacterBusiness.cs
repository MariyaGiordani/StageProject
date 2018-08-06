using System.Collections.Generic;
using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel.StarWars;

namespace StageProject.Business
{
    public interface ICharacterBusiness
    {
        void CreateNew(CharacterViewModel character);
        Character DatabaseModelParse(CharacterViewModel characterModel);
        void DeleteExisting(int id);
        void EditNew(CharacterViewModel character);
        CharacterViewModel Find(int? id);
        List<CharacterViewModel> Get();
        CharacterViewModel ModelParse(Character character);
    }
}