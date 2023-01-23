using System;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITarefaRepository
    {
        void Inserir(Tarefa tarefa);
        void Atualizar(Tarefa tarefa);
        Tarefa BuscarPorId(Guid id, string usuario);
        IEnumerable<Tarefa> RetornarTodas(string usuario);
        IEnumerable<Tarefa> RetornarTodasConcluidas(string usuario);
        IEnumerable<Tarefa> RetornarTodasNaoConcluidas(string usuario);
        IEnumerable<Tarefa> RetornarTodasPorPeriodo(string usuario, DateTime data, bool concluido);
    }
}
