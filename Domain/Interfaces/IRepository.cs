namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> SelecionarTodos();
        T? SelecionarId(params object[] variavel);
        T Incluir(T Objeto);
        T Alterar(T Objeto);
        void Excluir(T Objeto);
        void Excluir(params object[] variavel);
        void SaveChanges(T Objeto);
    }

}
