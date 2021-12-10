using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Var20BusinessLogic.ViewModels
{
    [DataContract]
    public class PlayerViewModel
	{
        [DataMember]
        public int? Id { get; set; }
        [DisplayName("Название")]
        [DataMember]
        public string Name { get; set; }
        [DisplayName("Тип персонажа")]
        [DataMember]
        public string Type { get; set; }
        [DisplayName("Очки")]
        [DataMember]
        public int Exp { get; set; }
        [DisplayName("Дата смерти")]
        [DataMember]
        public DateTime DateDeath { get; set; }
        public int? GameId { get; set; }
    }
}
