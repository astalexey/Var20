using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Var20BusinessLogic.BindingModels;
using Var20BusinessLogic.Interfaces;
using Var20BusinessLogic.ViewModels;
using Var20DatabaseImplement.Models;

namespace Var20DatabaseImplement.Implements
{
	public class GameStorage : IGameStorage
	{
        public void Delete(GameBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            using (var context = new Var20Database())
            {
                Game element = context.Games.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Games.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public GameViewModel GetElement(GameBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Var20Database())
            {
                var element = context.Games.FirstOrDefault(rec => rec.Id == model.Id);
                return element != null ?
                    new GameViewModel
                    {
                        Id = element.Id,
                        NameGame = element.NameGame,
                        Creater = element.Creater,
                        DateStart = element.DateStart
                    } : null;
            }
        }

        public List<GameViewModel> GetFilteredList(GameBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Var20Database())
            {
                return context.Games
                    .Where(rec => rec.NameGame == model.NameGame)
                    .Select(rec => new GameViewModel
                    {
                        Id = rec.Id,
                        NameGame = rec.NameGame,
                        Creater = rec.Creater,
                        DateStart = rec.DateStart,
                    })
                    .ToList();
            }
        }

        public List<GameViewModel> GetFullList()
        {
            using (var context = new Var20Database())
            {
                return context.Games
                    .Select(rec => new GameViewModel
                    {
                        Id = rec.Id,
                        NameGame = rec.NameGame,
                        Creater = rec.Creater,
                        DateStart = rec.DateStart,
                    })
                    .ToList();
            }
        }

        public void Insert(GameBindingModel model)
        {
            using (var context = new Var20Database())
            {
                context.Games.Add(CreateModel(model, new Game()));
                context.SaveChanges();
            }
        }

        public void Update(GameBindingModel model)
        {
            using (var context = new Var20Database())
            {
                var element = context.Games.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        private Game CreateModel(GameBindingModel model, Game systemBlock)
        {
            systemBlock.NameGame = model.NameGame;
            systemBlock.Creater = model.Creater;
            systemBlock.DateStart = model.DateStart;
            return systemBlock;
        }
    }
}
