using Dapper;
using MySql.Data.MySqlClient;
using PousadaAPI.Data.DTO;
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
}

