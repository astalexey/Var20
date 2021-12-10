using System;
using System.Collections.Generic;
using System.Text;

namespace Var20BusinessLogic.BindingModels
{
	public class ReportBindingModel
	{
		public string NameGame { get; set; }
		public DateTime DateStart { get; set; }
		public string Name { get; set; }
		public int Exp { get; set; }
		public DateTime DateDeath { get; set; }
		public string FileName { get; set; }
		public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
