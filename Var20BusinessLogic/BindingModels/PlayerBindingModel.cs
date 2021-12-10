using System;
using System.Collections.Generic;
using System.Text;

namespace Var20BusinessLogic.BindingModels
{
	public class PlayerBindingModel
	{
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Exp { get; set; }
        public DateTime DateDeath { get; set; }
        public int? GameId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
