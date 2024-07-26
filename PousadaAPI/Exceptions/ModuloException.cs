namespace PousadaAPI.Exceptions
{
    public class ModuloException : Exception
    {
        public ModuloException(string mensagem) : base(mensagem)
        {
        }

        public ModuloException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }

    public class ModuloNaoEncontradoException : ModuloException
    {
        public ModuloNaoEncontradoException(string mensagem = "Módulo não encontrado") : base(mensagem)
        {
        }

        public ModuloNaoEncontradoException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }

    public class ModuloJaExisteException : ModuloException
    {
        public ModuloJaExisteException(string mensagem = "Módulo informado já existe") : base(mensagem)
        {
        }

        public ModuloJaExisteException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }

    public class ModuloInvalidoException : ModuloException
    {
        public ModuloInvalidoException(string mensagem = "Módulo informado é inválido") : base(mensagem)
        {
        }

        public ModuloInvalidoException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }

    public class ModuloDescricaoInvalidaException : ModuloException
    {
        public ModuloDescricaoInvalidaException(string mensagem = "Descrição inválida") : base(mensagem)
        {
        }

        public ModuloDescricaoInvalidaException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }

    public class ModuloNomeInvalidoException : ModuloException
    {
        public ModuloNomeInvalidoException(string mensagem = "Nome inválido") : base(mensagem)
        {
        }

        public ModuloNomeInvalidoException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }


    
}
