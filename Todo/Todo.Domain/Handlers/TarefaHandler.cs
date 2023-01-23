using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TarefaHandler : Notifiable, IHandler<CriarTarefaCommand>, IHandler<AtualizarTarefaCommand>, IHandler<MarcarComoConcluidaCommand>, IHandler<MarcarComoNaoConcluidaCommand>
    {
        private readonly ITarefaRepository _repository;

        public TarefaHandler(ITarefaRepository repository)
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
            var tarefa = _repository.BuscarPorId(command.Id, command.Usuario);

            // Altera o título
            tarefa.AtualizarTitulo(command.Titulo);

            // Atualiza no banco
            _repository.Atualizar(tarefa);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada", tarefa);
        }

        public ICommandResult Handle(MarcarComoConcluidaCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recupera o TodoItem
            var tarefa = _repository.BuscarPorId(command.Id, command.Usuario);

            // Altera o estado
            tarefa.MarcarComoConcluido();

            // Salva no banco
            _repository.Atualizar(tarefa);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada", tarefa);
        }

        public ICommandResult Handle(MarcarComoNaoConcluidaCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recupera o TodoItem
            var tarefa = _repository.BuscarPorId(command.Id, command.Usuario);

            // Altera o estado
            tarefa.MarcarComoConcluido();

            // Salva no banco
            _repository.Atualizar(tarefa);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada", tarefa);
        }
    }
}
