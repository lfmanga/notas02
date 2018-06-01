using System;

namespace Notas02.Application.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public Cliente()
        {
            
        }

        public Cliente(string nome)
        {
            Nome = nome;
        }
    }
}