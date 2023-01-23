using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.Command
{
    [TestClass]
    public class CriarTarefaCommandTests
    {
        // Red, Green, Refactor

        private readonly CriarTarefaCommand _comandoInvalido = new CriarTarefaCommand("", DateTime.Now, "");
        private readonly CriarTarefaCommand _comandoValido = new CriarTarefaCommand("Título da Tarefa", DateTime.Now, "danilosilva");

        public CriarTarefaCommandTests()
        {
            _comandoValido.Validate();
            _comandoInvalido.Validate();
        }

        [TestMethod]
        public void Dado_Um_Comando_Invalido()
        {
            Assert.AreEqual(_comandoInvalido.Valid, false);
        }

        [TestMethod]
        public void Dado_Um_Comando_Valido()
        {
            Assert.AreEqual(_comandoValido.Valid, true);
        }
    }
}
