using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CriarTarefaHandlerTests
    {
        [TestMethod]
        public void Dado_Um_Comando_Invalido_Deve_Interromper_A_Execucao()
        {
            var command = new CriarTarefaCommand("", DateTime.Now, "");
            var handler = new TodoHandler(new FakeTodoRepository());
            Assert.Fail();
        }

        [TestMethod]
        public void Dado_Um_Comando_Valido_Deve_Criar_A_Tarefa()
        {
            Assert.Fail();
        }
    }
} 