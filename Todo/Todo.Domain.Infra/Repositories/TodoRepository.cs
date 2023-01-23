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
    public class TodoRepository : ITodoRepository
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
            throw new NotImplementedException();
        }

        public IEnumerable<Tarefa> RetornarTodas(string usuario)
        {
            return _context.Tarefas
                .AsNoTracking()
                .Where(TodoQueries.RetornarTodas(usuario))
                .OrderBy(x => x.Data);
        }

        public IEnumerable<Tarefa> RetornarTodasConcluidas(string usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tarefa> RetornarTodasNaoConcluidas(string usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tarefa> RetornarTodasPorPeriodo(string usuario, DateTime data, bool concluido)
        {
            throw new NotImplementedException();
        }
    }
}
