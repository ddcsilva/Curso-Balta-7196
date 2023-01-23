using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable, IHandler<CriarTarefaCommand>, IHandler<AtualizarTarefaCommand>
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

        public ICommandResult Handle(AtualizarTarefaCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recupera a Tarefa (Reidratação)
            var todo = _repository.BuscarPorId(command.Id, command.Usuario);

            // Altera o título
            todo.AtualizarTitulo(command.Titulo);

            // Atualiza no banco
            _repository.Atualizar(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}
