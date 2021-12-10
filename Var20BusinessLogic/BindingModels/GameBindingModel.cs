using System;
using System.Collections.Generic;
using System.Text;

namespace Var20BusinessLogic.BindingModels
{
    public class GameBindingModel
	{
        public int? Id { get; set; }
        public string NameGame { get; set; }
        public string Creater { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
