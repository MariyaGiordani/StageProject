using System.Collections.Generic;
using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel;
using StageProject.StageProject.Model.Enumeradores;

namespace StageProject.Business
{
    public interface ITelefoneBusiness
    {
        Telefone DatabaseModelParse(TelefoneViewModel telefoneBusiness);
        TelefoneViewModel ModelParse(Telefone telefone);
        List<TelefoneViewModel> Get();
        TelefoneViewModel Find(int? id);
        TelefoneViewModel CreateNew(Telefone telefone);
    }
}