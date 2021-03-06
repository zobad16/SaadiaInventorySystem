﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public interface IViewModel
    {
        string VMName();
        bool Activate();
        bool Deactivate();
        Task GetAll();
        Task Get();
        Task<bool> AddAsync();
        Task<bool> UpdateAsync();
        Task<bool> DeleteAsync();
        
    }
}
