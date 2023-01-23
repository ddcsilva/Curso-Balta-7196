using System.Linq.Expressions;
using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<Tarefa, bool>> RetornarTodasTarefas(string usuario)
        {
            return x => x.Usuario == usuario;
        }

        public static Expression<Func<Tarefa, bool>> RetornarTodasTarefasConcluidas(string usuario)
        {
            return x => x.Usuario == usuario && x.Concluido == true;
        }

        public static Expression<Func<Tarefa, bool>> RetornarTodasTarefasNaoConcluidas(string usuario)
        {
            return x => x.Usuario == usuario && x.Concluido == false;
        }

        public static Expression<Func<Tarefa, bool>> RetornarTodasTarefasPorPeriodo(string usuario, DateTime data, bool concluido)
        {
            return x =>
                x.Usuario == usuario &&
                x.Concluido == concluido &&
                x.Data.Date == data.Date;
        }
    }
}
