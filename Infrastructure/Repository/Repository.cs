using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using TokenApi.Data;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly ApplicationContext _context;

        public bool _savechanges = true;
        public Repository(ApplicationContext context)
        {
            _context = context;
            _savechanges = true;
        }
        public T Alterar(T objeto)
        {
            _context.Entry(objeto).State = EntityState.Modified;
            if (_savechanges)
            {
                _context.SaveChanges();
            }
            return objeto;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Excluir(T objeto)
        {
            _context.Set<T>().Remove(objeto);
            if (_savechanges)
            {
                _context.SaveChanges();
            }
        }

        public void Excluir(params object[] variavel)
        {
            var obj = SelecionarId(variavel);
            Excluir(obj);
        }

        public T Incluir(T objeto)
        {
            _context.Set<T>().Add(objeto);
            if (_savechanges)
            {
                _context.SaveChanges();
            }
            return objeto;
        }

        public void SaveChanges(T Objeto)
        {
            _context.SaveChanges();
        }

        public T? SelecionarId(params object[] variavel)
        {
            return _context.Set<T>().Find(variavel);
        }

        public IEnumerable<T> SelecionarTodos()
        {
            return _context.Set<T>().ToList();
        }
    }
}
