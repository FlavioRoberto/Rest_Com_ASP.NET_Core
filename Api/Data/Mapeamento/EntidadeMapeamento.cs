﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamento
{
    public abstract class EntidadeMapeamento<T> where T : class
    {
        protected EntityTypeBuilder<T> builder;

        public EntidadeMapeamento(EntityTypeBuilder<T> builder)
        {
            this.builder = builder;
        }

        public abstract EntidadeMapeamento<T> Map();
    }
}
