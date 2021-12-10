using System;
using System.Collections.Generic;
using System.Text;
using Var20BusinessLogic.BindingModels;
using Var20BusinessLogic.ViewModels;

namespace Var20BusinessLogic.Interfaces
{
	public interface IPlayerStorage
	{
        List<PlayerViewModel> GetFullList();
        List<PlayerViewModel> GetFilteredList(PlayerBindingModel model);
        PlayerViewModel GetElement(PlayerBindingModel model);
        void Insert(PlayerBindingModel model);
        void Update(PlayerBindingModel model);
        void Delete(PlayerBindingModel model);
    }
}
