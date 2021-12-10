using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Var20BusinessLogic.BindingModels;
using Var20BusinessLogic.HelperModels;
using Var20BusinessLogic.Interfaces;
using Var20BusinessLogic.ViewModels;

namespace Var20BusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IPlayerStorage _playerStorage;
        private readonly IGameStorage _gameStorage;
        public ReportLogic(IGameStorage gameStorage, IPlayerStorage playerStorage)
        {
            _gameStorage = gameStorage;
            _playerStorage = playerStorage;
        }

        public List<ReportViewModel> GetGame(ReportBindingModel model)
        {
            return _gameStorage.GetFilteredList(new GameBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportViewModel
            {
                NameGame = _gameStorage.GetElement(new GameBindingModel
                {
                    Id = x.Id
                }).NameGame,
                DateStart = x.DateStart,
                Name = _playerStorage.GetElement(new PlayerBindingModel
                {
                    Id = x.Id
                }).Name,
                Exp = _playerStorage.GetElement(new PlayerBindingModel
                {
                    Id = x.Id
                }).Exp,
                DateDeath = _playerStorage.GetElement(new PlayerBindingModel
                {
                    Id = x.Id
                }).DateDeath,
            })
           .ToList();
        }

        [Obsolete]
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            Task.Run(() => SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список игроков по играм",
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                Game = GetGame(model)
            }));
        }
    }
}
