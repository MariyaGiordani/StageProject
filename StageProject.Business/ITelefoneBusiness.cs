﻿using System.Collections.Generic;
using System.Data.Entity;
using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel;
using StageProject.StageProject.Model.Enumeradores;

namespace StageProject.Business
{
    public interface ITelefoneBusiness
    {
        Telefone DatabaseModelParse(TelefoneViewModel telefoneModel);
        TelefoneViewModel ModelParse(Telefone telefone);
        List<TelefoneViewModel> Get();
        List<TelefoneViewModel> GetTelefone(List<Telefone> telefones);
        TelefoneViewModel Find(int? id);
        void CreateNew(TelefoneViewModel telefone);
        void EditNew(TelefoneViewModel telefone);
        void DeleteExisting(int id);
    }
}