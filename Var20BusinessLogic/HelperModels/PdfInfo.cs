using System;
using System.Collections.Generic;
using System.Text;
using Var20BusinessLogic.ViewModels;

namespace Var20BusinessLogic.HelperModels
{
	class PdfInfo
	{
		public string FileName { get; set; }
		public string Title { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }
		public List<ReportViewModel> Game { get; set; }
	}
}
