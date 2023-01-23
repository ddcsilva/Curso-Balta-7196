using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Todo.Domain.Tests.EntityTests;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Inserir(Tarefa tarefa)
        {

        }

        public void Atualizar(Tarefa tarefa)
        {

        }

        public Tarefa BuscarPorId(Guid id, string usuario)
        {
            return new Tarefa("Título da Tarefa", DateTime.Now, "danilosilva");
        }
    }
}
