namespace PousadaAPI.Exceptions
{
    public class PermissaoException : Exception
    {
        public PermissaoException(string mensagem) : base(mensagem)
        {
        }
        
        public PermissaoException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }

    public class PermissaoNaoEncontradaException : PermissaoException
    {
        public PermissaoNaoEncontradaException(string mensagem = "Permissão não encontrada") : base(mensagem)
        {
        }

        public PermissaoNaoEncontradaException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }

    public class PermissaoJaExisteException : PermissaoException
    {
        public PermissaoJaExisteException(string mensagem = "Permissão informada já existe") : base(mensagem)
        {
        }

        public PermissaoJaExisteException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }

    public class PermissaoInvalidaException : PermissaoException
    {
        public PermissaoInvalidaException(string mensagem = "Permissão informada é inválida") : base(mensagem)
        {
        }

        public PermissaoInvalidaException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }

    public class PermissaoNomeInvalidoException : PermissaoException
    {
        public PermissaoNomeInvalidoException(string mensagem = "Nome inválido") : base(mensagem)
        {
        }

        public PermissaoNomeInvalidoException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }

    public class PermissaoDescricaoInvalidaException : PermissaoException
    {
        public PermissaoDescricaoInvalidaException(string mensagem = "Descrição inválida") : base(mensagem)
        {
        }

        public PermissaoDescricaoInvalidaException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }
}
