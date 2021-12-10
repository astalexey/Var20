using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Var20DatabaseImplement.Models
{
	public class Game
	{
        public int Id { get; set; }
        [Required]
        public string NameGame { get; set; }
        [Required]
        public string Creater { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [ForeignKey("GameId")]
        public virtual List<Player> Players { get; set; }
    }
}
