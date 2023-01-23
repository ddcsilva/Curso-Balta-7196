using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITarefaRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Inserir(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public void Atualizar(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Tarefa BuscarPorId(Guid id, string usuario)
        {
            return _context
                .Tarefas
                .FirstOrDefault(x => x.Id == id && x.Usuario == usuario);
        }

        public IEnumerable<Tarefa> RetornarTodas(string usuario)
        {
            return _context.Tarefas
                .AsNoTracking()
                .Where(TarefaQueries.RetornarTodas(usuario))
                .OrderBy(x => x.Data);
        }

        public IEnumerable<Tarefa> RetornarTodasConcluidas(string usuario)
        {
            return _context.Tarefas
                .AsNoTracking()
                .Where(TarefaQueries.RetornarTodasConcluidas(usuario))
                .OrderBy(x => x.Data);
        }

        public IEnumerable<Tarefa> RetornarTodasNaoConcluidas(string usuario)
        {
            return _context.Tarefas
                .AsNoTracking()
                .Where(TarefaQueries.RetornarTodasNaoConcluidas(usuario))
                .OrderBy(x => x.Data);
        }

        public IEnumerable<Tarefa> RetornarTodasPorPeriodo(string usuario, DateTime data, bool concluido)
        {
            return _context.Tarefas
                .AsNoTracking()
                .Where(TarefaQueries.RetornarTodasPorPeriodo(usuario, data, concluido))
                .OrderBy(x => x.Data);
        }
    }
}
