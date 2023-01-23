using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Inserir(Tarefa tarefa);
        void Atualizar(Tarefa tarefa);
        Tarefa BuscarPorId(Guid id, string usuario);
    }
}
