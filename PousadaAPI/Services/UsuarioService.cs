using Models;
using PousadaAPI.Data.DTO;
using PousadaAPI.Data.Enums;
using PousadaAPI.Exceptions;
using PousadaAPI.Interfaces;
using System.Text.RegularExpressions;

namespace PousadaAPI.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioDAO _usuarioContext;

    public UsuarioService(IUsuarioDAO usuarioDAO)
    {
        _usuarioContext = usuarioDAO;
    }

    public void NovoUsuario(CreateUsuarioDTO usuario)
    {
        try
        {
            if (ValidarUsuario(usuario))
            {
                _usuarioContext.InserirUsuario(usuario);
            }
        }
        catch(UsuarioException uex)
        {
            throw new UsuarioException(uex.Message);
        }
        catch (Exception)
        {
            throw new Exception("Erro não mapeado ao inserir usuário");
        }
    }

    public Usuario BuscarUsuarioPorEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Usuario BuscarUsuarioPorId(int id)
    {
        throw new NotImplementedException();
    }

    private bool ValidarUsuario(CreateUsuarioDTO usuario)
    {
        if (string.IsNullOrEmpty(usuario.Nome))
        {
            throw new UsuarioNomeInvalidoException();
        }

        if (string.IsNullOrEmpty(usuario.Email))
        {
            throw new UsuarioEmailInvalidoException();
        }

        if (string.IsNullOrEmpty(usuario.Senha))
        {
            throw new UsuarioSenhaInvalidaException();
        }

        if(GetForcaDaSenha(usuario.Senha) < ForcaDaSenha.Aceitavel)
        {
            throw new UsuarioSenhaInseguraException();
        }

        if (usuario.DataNascimento == DateTime.MinValue)
        {
            throw new UsuarioDataNascimentoInvalidaException();
        }

        return true;
    }


    #region Checa força da senha

    public int GeraPontosSenha(string senha)
    {
        if (senha == null) return 0;
        int pontosPorTamanho = GetPontoPorTamanho(senha);
        int pontosPorMinusculas = GetPontoPorMinusculas(senha);
        int pontosPorMaiusculas = GetPontoPorMaiusculas(senha);
        int pontosPorDigitos = GetPontoPorDigitos(senha);
        int pontosPorSimbolos = GetPontoPorSimbolos(senha);
        int pontosPorRepeticao = GetPontoPorRepeticao(senha);
        return pontosPorTamanho + pontosPorMinusculas + pontosPorMaiusculas + pontosPorDigitos + pontosPorSimbolos - pontosPorRepeticao;
    }

    private int GetPontoPorTamanho(string senha)
    {
        return Math.Min(10, senha.Length) * 6;
    }

    private int GetPontoPorMinusculas(string senha)
    {
        int rawplacar = senha.Length - Regex.Replace(senha, "[a-z]", "").Length;
        return Math.Min(2, rawplacar) * 5;
    }

    private int GetPontoPorMaiusculas(string senha)
    {
        int rawplacar = senha.Length - Regex.Replace(senha, "[A-Z]", "").Length;
        return Math.Min(2, rawplacar) * 5;
    }

    private int GetPontoPorDigitos(string senha)
    {
        int rawplacar = senha.Length - Regex.Replace(senha, "[0-9]", "").Length;
        return Math.Min(2, rawplacar) * 5;
    }

    private int GetPontoPorSimbolos(string senha)
    {
        int rawplacar = Regex.Replace(senha, "[a-zA-Z0-9]", "").Length;
        return Math.Min(2, rawplacar) * 5;
    }

    private int GetPontoPorRepeticao(string senha)
    {
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(\w)*.*\1");
        bool repete = regex.IsMatch(senha);
        if (repete)
        {
            return 30;
        }
        else
        {
            return 0;
        }
    }

    public ForcaDaSenha GetForcaDaSenha(string senha)
    {
        int placar = GeraPontosSenha(senha);

        if (placar < 50)
            return ForcaDaSenha.Inaceitavel;
        else if (placar < 60)
            return ForcaDaSenha.Fraca;
        else if (placar < 80)
            return ForcaDaSenha.Aceitavel;
        else if (placar < 100)
            return ForcaDaSenha.Forte;
        else
            return ForcaDaSenha.Segura;
    }

    #endregion
}
