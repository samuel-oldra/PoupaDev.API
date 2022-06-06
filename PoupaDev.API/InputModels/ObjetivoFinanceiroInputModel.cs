using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDev.API.Enums;

namespace PoupaDev.API.InputModels
{
    public class ObjetivoFinanceiroInputModel
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public decimal? ValorObjetivo { get; set; }
    }
}