using Dapper;
using MySql.Data.MySqlClient;
using PousadaAPI.Data.DTO.Modulo;
using PousadaAPI.Interfaces;

namespace PousadaAPI.Data.DAO;

public class ModuloDAO : IModuloDAO
{
    private readonly string _connectionString;

    public ModuloDAO(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void InserirModulo(CreateModuloDTO modulo)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Execute(
                @"INSERT INTO Modulo (Nome, Descricao) 
                  VALUES (@Nome, @Descricao)",
                modulo
            );
        }
    }

    public void AtualizarModulo(UpdateModuloDTO modulo)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Execute(
                 @"UPDATE Modulo
                  SET Nome = @Nome, Descricao = @Descricao, Ativo = @Ativo
                  WHERE Id = @Id",
                 modulo
             );
        }
    }

    public IEnumerable<ReadModuloDTO> BuscarModulos()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            return connection.Query<ReadModuloDTO>(
                @"SELECT Id, Nome, Descricao, DataCriacao, Ativo
                  FROM Modulo"
            );
        }
    }

    public ReadModuloDTO BuscarModuloPorId(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            return connection.QueryFirstOrDefault<ReadModuloDTO>(
                @"SELECT Id, Nome, Descricao, DataCriacao, Ativo 
                  FROM Modulo
                  WHERE Id = @Id",
                new { Id = id }
            );
        }
    }

    public ReadModuloDTO? BuscarModuloPorNome(string nome)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            return connection.QueryFirstOrDefault<ReadModuloDTO>(
                @"SELECT Id, Nome, Descricao
                  FROM Modulo
                  WHERE Nome = @Nome",
                new { Nome = nome }
            );
        }
    }

    public void DeletarModulo(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Execute(
                @"DELETE FROM Modulo
                  WHERE Id = @Id",
                new { Id = id }
            );
        }
    }
}
