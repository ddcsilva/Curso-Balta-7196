using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Inserir(Item item);
        void Atualizar(Item item);
    }
}
