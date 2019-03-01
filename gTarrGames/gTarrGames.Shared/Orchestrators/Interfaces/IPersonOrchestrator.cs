﻿using gTarrGames.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gTarrGames.Shared.Orchestrators.Interfaces
{
    public interface IPersonOrchestrator
    {
        Task<int> CreatePerson(PersonViewModel person);
        Task<bool> UpdatePerson(PersonViewModel person);
        //Task<bool> Search(PersonViewModel person);
        Task<PersonViewModel> SearchPersonAsync(string searchString);
        List<PersonViewModel> GetAllPersons();
    }
}