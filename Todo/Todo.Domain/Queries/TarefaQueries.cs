using System.Linq.Expressions;
using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TarefaQueries
    {
        public static Expression<Func<Tarefa, bool>> RetornarTodas(string usuario)
        {
            return x => x.Usuario == usuario;
        }

        public static Expression<Func<Tarefa, bool>> RetornarTodasConcluidas(string usuario)
        {
            return x => x.Usuario == usuario && x.Concluido == true;
        }

        public static Expression<Func<Tarefa, bool>> RetornarTodasNaoConcluidas(string usuario)
        {
            return x => x.Usuario == usuario && x.Concluido == false;
        }

        public static Expression<Func<Tarefa, bool>> RetornarTodasPorPeriodo(string usuario, DateTime data, bool concluido)
        {
            return x =>
                x.Usuario == usuario &&
                x.Concluido == concluido &&
                x.Data.Date == data.Date;
        }
    }
}
