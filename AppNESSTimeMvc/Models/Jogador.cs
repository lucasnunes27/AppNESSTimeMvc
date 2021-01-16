using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppNESSTimeMvc.Models
{
    public class Jogador : Entity
    {
        [DisplayName("Time")]
        public Guid TimeId { get; set; }

        [DisplayName("Nome na Camisa")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} pode ter no máximo 20 caracteres")]
        public string Nome { get; set; }

        [DisplayName("Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} pode ter no máximo 200 caracteres")]
        public string NomeCompleto { get; set; }

        [DisplayName("Número do Jogador")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]      
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Idade { get; set; }

        [DisplayName("Titular")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(12, ErrorMessage = "O campo {0} pode ter no máximo 12 caracteres")]
        [DisplayName("Posição em Campo")]
        public string Posicao { get; set; }

        [DisplayName("Jogos pelo Time")]
        public int Jogos { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Gols Marcados")]
        public int Gols { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data de Aquisição")]
        public DateTime Data { get; set; }

        public Time Time { get; set; }

    }
}

