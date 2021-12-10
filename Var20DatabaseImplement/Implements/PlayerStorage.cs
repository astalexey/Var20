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
	public class PlayerStorage : IPlayerStorage
	{
        public void Delete(PlayerBindingModel model)
        {
            using (var context = new Var20Database())
            {
                Player element = context.Players.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Players.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public PlayerViewModel GetElement(PlayerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Var20Database())
            {
                var player = context.Players
                    .FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
                return player != null ?
                    new PlayerViewModel
                    {
                        Id = player.Id,
                        Name = player.Name,
                        Type = player.Type,
                        Exp = player.Exp,
                        DateDeath = player.DateDeath,
                        GameId = player.GameId
                    } : null;
            }
        }

        public List<PlayerViewModel> GetFilteredList(PlayerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Var20Database())
            {
                return context.Players
                    .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue &&
                    rec.DateDeath.Date == model.DateDeath.Date) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue &&
                    rec.DateDeath.Date >= model.DateFrom.Value.Date && rec.DateDeath.Date <= model.DateTo.Value.Date))
                    .Select(rec => new PlayerViewModel
                    {
                        Id = rec.Id,
                        Name = rec.Name,
                        Type = rec.Type,
                        Exp = rec.Exp,
                        DateDeath = rec.DateDeath,
                        GameId = rec.GameId,
                    })
                    .ToList();
            }
        }

        public List<PlayerViewModel> GetFullList()
        {
            using (var context = new Var20Database())
            {
                return context.Players
                    .Select(rec => new PlayerViewModel
                    {
                        Id = rec.Id,
                        Name = rec.Name,
                        Type = rec.Type,
                        Exp = rec.Exp,
                        DateDeath = rec.DateDeath,
                        GameId = rec.GameId,
                    })
                    .ToList();
            }
        }

        public void Insert(PlayerBindingModel model)
        {
            using (var context = new Var20Database())
            {
                context.Players.Add(CreateModel(model, new Player()));
                context.SaveChanges();
            }
        }

        public void Update(PlayerBindingModel model)
        {
            using (var context = new Var20Database())
            {
                var element = context.Players.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        private Player CreateModel(PlayerBindingModel model, Player player)
        {
            player.Name = model.Name;
            player.Type = model.Type;
            player.Exp = model.Exp;
            player.DateDeath = model.DateDeath;
            player.GameId = model.GameId;
            return player;
        }
    }
}
