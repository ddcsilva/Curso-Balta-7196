using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public abstract class MarcarTarefaCommand : Notifiable, ICommand
    {
        public MarcarTarefaCommand() { }

        public MarcarTarefaCommand(Guid id, string usuario)
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
