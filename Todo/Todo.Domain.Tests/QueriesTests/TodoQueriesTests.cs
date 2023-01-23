using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<Tarefa> _tarefas;

        public TodoQueriesTests()
        {
            _tarefas = new List<Tarefa>();
            _tarefas.Add(new Tarefa("Tarefa 1", DateTime.Now, "usuarioA"));
            _tarefas.Add(new Tarefa("Tarefa 2", DateTime.Now, "usuarioB"));
            _tarefas.Add(new Tarefa("Tarefa 3", DateTime.Now, "danilosilva"));
            _tarefas.Add(new Tarefa("Tarefa 4", DateTime.Now, "usuarioA"));
            _tarefas.Add(new Tarefa("Tarefa 5", DateTime.Now, "danilosilva"));
        }

        [TestMethod]
        public void Dada_A_Consulta_Deve_Retornar_Tarefas_Apenas_Do_Usuario_danilosilva()
        {
            var result = _tarefas.AsQueryable().Where(TodoQueries.RetornarTodas("danilosilva"));
            Assert.AreEqual(2, result.Count());
        }
    }
}
