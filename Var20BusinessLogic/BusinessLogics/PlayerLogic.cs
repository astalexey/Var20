using System;
using System.Collections.Generic;
using System.Text;
using Var20BusinessLogic.BindingModels;
using Var20BusinessLogic.Interfaces;
using Var20BusinessLogic.ViewModels;

namespace Var20BusinessLogic.BusinessLogics
{
	public class PlayerLogic
	{
        private readonly IPlayerStorage _playerStorage;
        public PlayerLogic(IPlayerStorage playerStorage)
        {
            _playerStorage = playerStorage;
        }
        public List<PlayerViewModel> Read(PlayerBindingModel model)
        {
            if (model == null)
            {
                return _playerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PlayerViewModel> { _playerStorage.GetElement(model) };
            }
            return _playerStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PlayerBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _playerStorage.Update(model);
            }
            else
            {
                _playerStorage.Insert(model);
            }
        }
        public void Delete(PlayerBindingModel model)
        {
            var element = _playerStorage.GetElement(new PlayerBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _playerStorage.Delete(model);
        }
    }
}
