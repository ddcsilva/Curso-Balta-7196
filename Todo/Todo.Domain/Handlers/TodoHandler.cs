using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable, IHandler<CriarTarefaCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CriarTarefaCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Gera a Tarefa
            var tarefa = new Tarefa(command.Titulo, command.Data, command.Usuario);

            // Salva no banco
            _repository.Inserir(tarefa);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa inserida", tarefa);
        }
    }
}
