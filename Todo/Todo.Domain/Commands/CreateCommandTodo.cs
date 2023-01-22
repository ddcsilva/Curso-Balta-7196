using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateCommandTodo : Notifiable, ICommand
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
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Titulo, 3, "Titulo", "Por favor, descreva melhor esta tarefa!")
                    .HasMinLen(Usuario, 6, "Usuario", "Usuário inválido!")  
            );
        }
    }
}