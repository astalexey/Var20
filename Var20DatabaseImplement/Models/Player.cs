using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Var20DatabaseImplement.Models
{
	public class Player
	{
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Exp { get; set; }
        [Required]
        public DateTime DateDeath { get; set; }

        public int? GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
