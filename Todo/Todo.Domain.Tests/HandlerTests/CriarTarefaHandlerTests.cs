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
        private readonly CriarTarefaCommand _comandoInvalido = new CriarTarefaCommand("", DateTime.Now, "");
        private readonly CriarTarefaCommand _comandoValido = new CriarTarefaCommand("Título da Tarefa", DateTime.Now, "danilosilva");
        private readonly TarefaHandler _handler = new TarefaHandler(new FakeTarefaRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public void Dado_Um_Comando_Invalido_Deve_Interromper_A_Execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_comandoInvalido);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_Um_Comando_Valido_Deve_Criar_A_Tarefa()
        {
            _result = (GenericCommandResult)_handler.Handle(_comandoValido);
            Assert.AreEqual(_result.Success, true);
        }
    }
} 