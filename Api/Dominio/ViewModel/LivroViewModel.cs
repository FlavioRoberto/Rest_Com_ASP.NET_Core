﻿using System;

namespace Dominio.ViewModel
{
    public class LivroViewModel
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
