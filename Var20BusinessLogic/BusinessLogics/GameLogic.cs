using System;
using System.Collections.Generic;
using System.Text;
using Var20BusinessLogic.BindingModels;
using Var20BusinessLogic.Interfaces;
using Var20BusinessLogic.ViewModels;

namespace Var20BusinessLogic.BusinessLogics
{
	public class GameLogic
	{
        private readonly IGameStorage _gameStorage;
        public GameLogic(IGameStorage gameStorage)
        {
            _gameStorage = gameStorage;
        }
        public List<GameViewModel> Read(GameBindingModel model)
        {
            if (model == null)
            {
                return _gameStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<GameViewModel> { _gameStorage.GetElement(model) };
            }
            return _gameStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(GameBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _gameStorage.Update(model);
            }
            else
            {
                _gameStorage.Insert(model);
            }
        }
        public void Delete(GameBindingModel model)
        {
            var element = _gameStorage.GetElement(new GameBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _gameStorage.Delete(model);
        }
    }
}
