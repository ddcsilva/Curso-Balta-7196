using System;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateCommandTodo : ICommand
    {
        public CreateCommandTodo() { }

        public CreateCommandTodo(string titulo, DateTime data, string usuario)
        {
            Titulo = titulo;
            Data = data;
            Usuario = usuario;
        }

        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public string Usuario { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}