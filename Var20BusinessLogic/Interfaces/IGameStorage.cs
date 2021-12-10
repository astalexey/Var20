using System;
using System.Collections.Generic;
using System.Text;
using Var20BusinessLogic.BindingModels;
using Var20BusinessLogic.ViewModels;

namespace Var20BusinessLogic.Interfaces
{
	public interface IGameStorage
	{
        List<GameViewModel> GetFullList();
        List<GameViewModel> GetFilteredList(GameBindingModel model);
        GameViewModel GetElement(GameBindingModel model);
        void Insert(GameBindingModel model);
        void Update(GameBindingModel model);
        void Delete(GameBindingModel model);
    }
}
