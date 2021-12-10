using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Var20BusinessLogic.ViewModels
{
    [DataContract]
    public class GameViewModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DisplayName("Название")]
        [DataMember]
        public string NameGame { get; set; }
        [DisplayName("Ведущий")]

        public string Creater { get; set; }
        [DisplayName("Дата проведения")]
        [DataMember]
        public DateTime DateStart { get; set; }
    }
}
