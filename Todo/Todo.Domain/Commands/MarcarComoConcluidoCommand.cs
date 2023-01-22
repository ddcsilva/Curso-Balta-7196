using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarcarComoConcluidoCommand : Notifiable, ICommand
    {
        public MarcarComoConcluidoCommand() { }

        public MarcarComoConcluidoCommand(Guid id, string usuario)
        {
            Id = id;
            Usuario = usuario;
        }

        public Guid Id { get; set; }
        public string Usuario { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Usuario, 6, "Usuario", "Usuário inválido!")
            );
        }
    }
}
