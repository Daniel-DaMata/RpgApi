using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuariosController(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> UsuarioExistente(string Username)
        {
            if(await _context.Usuario.AnyAsync(x => x.Username.ToLower() == Username.ToLower()))
            {
                return true;
            }
            return false;
        }
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistarUsuario(Usuario user)
        {
        try
        {
            if(await UsuarioExistente(user.Username))
                throw new System.Exception("Nome de usuário já existente");
            
            Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            await _context.Usuario.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user.Id);
        }
        catch (System.Exception ex)
        {
            return BadRequest (ex.Message);
        }
        }


        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuario
                .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado. ");
                }
                else if (!Criptografia
                    .VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta. ");
                }
                else
                {
                    return Ok(usuario.Id);
                }

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}