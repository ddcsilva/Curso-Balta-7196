
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasTarefas([FromServices] ITarefaRepository repository)
        {
            return repository.RetornarTodas("danilosilva");
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult CriarTarefa([FromBody] CriarTarefaCommand command, [FromServices] TarefaHandler handler)
        {
            command.Usuario = "danilosilva";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
