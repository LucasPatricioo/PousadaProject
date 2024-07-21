using Dapper;
using MySql.Data.MySqlClient;
using PousadaAPI.Interfaces;

namespace Data.DAO;

public class UsuarioDAO : IUsuarioDAO
{
    private readonly string _connectionString;

    public UsuarioDAO(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void InserirUsuario(Models.Usuario usuario)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Execute(
                "INSERT INTO Usuario (Id, Nome, Email, Senha, DataNascimento, DataCadastro, Ativo) VALUES (@Id, @Nome, @Email, @Senha, @DataNascimento, @DataCadastro, @Ativo)",
                usuario
            );
        }
    }
}

