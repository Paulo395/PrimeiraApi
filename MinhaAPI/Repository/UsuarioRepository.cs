using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;
using MinhaAPI.Repository.Interface;

namespace MinhaAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MinhaApiDBContex _dbContext;
        public UsuarioRepository(MinhaApiDBContex minhaApiDBContex)
        {
            _dbContext = minhaApiDBContex;
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            _dbContext.SaveChanges();

            return usuario;// async resolve os probelmas de return
        }

        public async Task<bool> ApagarUsuario(int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId != null)
            {
                throw new Exception("Usuario com o Id " + id + " não encontrado!");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
             await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Usuario> AtualizarUsuario(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId != null)
            {
                throw new Exception("Usuario com o Id " + id +" não encontrado!");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> ListarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
    }
}
