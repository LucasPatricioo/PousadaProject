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

    public void AtualizarPermissoesModulo(UpdatePermissaoModuloDTO permissoes)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Execute(
                @"UPDATE PERMISSAO_MODULO
                  SET Leitura = @Leitura, Escrita = @Escrita, Edicao = @Edicao, Exclusao = @Exclusao
                  WHERE Id_Modulo = @IdModulo AND Id_Permissao = @IdPermissao",
                permissoes
            );
        }
    }

    public IEnumerable<ReadModuloDTO> BuscarModulos()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            return connection.Query<ReadModuloDTO>(
                @"SELECT M.Id, M.Nome, M.Descricao, M.DataCriacao, M.Ativo,
                    PM.Leitura, PM.Escrita, PM.Edicao, PM.Exclusao 
                  FROM Modulo M
                    INNER JOIN PERMISSAO_MODULO PM ON M.Id = PM.Id_Modulo"
            );
        }
    }

    public ReadModuloDTO BuscarModuloPorId(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            return connection.QueryFirstOrDefault<ReadModuloDTO>(
                @"SELECT M.Id, M.Nome, M.Descricao, M.DataCriacao, M.Ativo, 
                    PM.Leitura, PM.Escrita, PM.Edicao, PM.Exclusao 
                  FROM Modulo M 
                    INNER JOIN PERMISSAO_MODULO PM ON M.Id = PM.Id_Modulo
                  WHERE M.Id = @Id",
                new { Id = id }
            );
        }
    }

    public ReadModuloDTO? BuscarModuloPorNome(string nome)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            return connection.QueryFirstOrDefault<ReadModuloDTO>(
                @"SELECT M.Id, M.Nome, M.Descricao, M.DataCriacao, M.Ativo
                    PM.Leitura, PM.Escrita, PM.Edicao, PM.Exclusao
                  FROM Modulo M
                    INNER JOIN PERMISSAO_MODULO PM ON M.Id = PM.Id_Modulo
                  WHERE M.Nome = @Nome",
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
