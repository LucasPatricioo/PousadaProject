namespace PousadaAPI.Exceptions;

public class UsuarioException : Exception
{
    public UsuarioException(string mensagem) : base(mensagem)
    {
    }

    public UsuarioException(string mensagem, Exception innerException) : base(mensagem, innerException)
    {
    }
}

public class UsuarioNaoEncontradoException : UsuarioException
{
    public UsuarioNaoEncontradoException(string mensagem = "Usuário não encontrado") : base(mensagem)
    {
    }

    public UsuarioNaoEncontradoException(string mensagem, Exception innerException) : base(mensagem, innerException)
    {
    }
}

public class UsuarioJaExisteException : UsuarioException
{
    public UsuarioJaExisteException(string mensagem = "Usuário informado já existe") : base(mensagem)
    {
    }

    public UsuarioJaExisteException(string mensagem, Exception innerException) : base(mensagem, innerException)
    {
    }
}

public class UsuarioInvalidoException : UsuarioException
{
    public UsuarioInvalidoException(string mensagem = "Usuário informado é inválido") : base(mensagem)
    {
    }

    public UsuarioInvalidoException(string mensagem, Exception innerException) : base(mensagem, innerException)
    {
    }
}

public class UsuarioSenhaInvalidaException : UsuarioException
{
    public UsuarioSenhaInvalidaException(string mensagem = "Senha inválida") : base(mensagem)
    {
    }

    public UsuarioSenhaInvalidaException(string mensagem, Exception innerException) : base(mensagem, innerException)
    {
    }
}

public class UsuarioEmailInvalidoException : UsuarioException
{
    public UsuarioEmailInvalidoException(string mensagem = "E-mail inválido") : base(mensagem)
    {
    }

    public UsuarioEmailInvalidoException(string mensagem, Exception innerException) : base(mensagem, innerException)
    {
    }
}

public class UsuarioNomeInvalidoException : UsuarioException
{
    public UsuarioNomeInvalidoException(string mensagem = "Nome inválido") : base(mensagem)
    {
    }

    public UsuarioNomeInvalidoException(string mensagem, Exception innerException) : base(mensagem, innerException)
    {
    }
}

public class UsuarioDataNascimentoInvalidaException : UsuarioException
{
    public UsuarioDataNascimentoInvalidaException(string mensagem = "Data nascimento inválido") : base(mensagem)
    {
    }

    public UsuarioDataNascimentoInvalidaException(string mensagem, Exception innerException) : base(mensagem, innerException)
    {
    }
}

public class UsuarioSenhaInseguraException : UsuarioException
{
    public UsuarioSenhaInseguraException(string mensagem = "Senha insegura informada") : base(mensagem)
    {
    }

    public UsuarioSenhaInseguraException(string mensagem, Exception innerException) : base(mensagem, innerException)
    {
    }
}

public class UsuarioNaoTemPermissaoException : UsuarioException
{
    public UsuarioNaoTemPermissaoException(string mensagem = "O usuário não possui permissão") : base(mensagem)
    {
    }

    public UsuarioNaoTemPermissaoException(string mensagem, Exception innerException) : base(mensagem, innerException)
    {
    }
}