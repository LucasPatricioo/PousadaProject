using Dapper;
using MySql.Data.MySqlClient;
using PousadaAPI.Data.DTO.Usuario;
using PousadaAPI.Interfaces;

namespace Data.DAO;

public class UsuarioDAO : IUsuarioDAO
{
    private readonly string _connectionString;

    public UsuarioDAO(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void InserirUsuario(CreateUsuarioDTO usuario)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Execute(
                @"INSERT INTO Usuario (Nome, Email, Senha, DataNascimento) 
                  VALUES (@Nome, @Email, @Senha, @DataNascimento)",
                usuario
            );
        }
    }

    public void AtualizarUsuario(UpdateUsuarioDTO usuario)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Execute(
                 @"UPDATE Usuario
                  SET Nome = @Nome, Email = @Email, Senha = @Senha, Ativo = @Ativo
                  WHERE Id = @Id",
                 usuario
             );
        }
    }

    public IEnumerable<ReadUsuarioDTO> BuscarUsuarios()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            return connection.Query<ReadUsuarioDTO>(
                @"SELECT Id, Nome, Email, Senha, DataNascimento, DataCadastro, Ativo
                  FROM Usuario"
            );
        }
    }

    public ReadUsuarioDTO BuscarUsuarioPorId(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            return connection.QueryFirstOrDefault<ReadUsuarioDTO>(
                @"SELECT Id, Nome, Email, Senha, DataNascimento, DataCadastro, Ativo
                  FROM Usuario
                  WHERE Id = @Id",
                new { Id = id }
            );
        }
    }

    public void DeletarUsuario(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Execute(
                @"DELETE FROM Usuario
                  WHERE Id = @Id",
                new { Id = id }
            );
        }
    }

}

