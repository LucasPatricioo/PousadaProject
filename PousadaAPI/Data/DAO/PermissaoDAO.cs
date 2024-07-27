using Dapper;
using MySql.Data.MySqlClient;
using PousadaAPI.Data.DTO.Permissoes;
using PousadaAPI.Interfaces;

namespace PousadaAPI.Data.DAO
{
    public class PermissaoDAO : IPermissaoDAO
    {
        private readonly string _connectionString;

        public PermissaoDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InserirPermissao(CreatePermissaoDTO permissao)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(
                    @"INSERT INTO Permissao (Nome, Descricao) 
                      VALUES (@Nome, @Descricao)",
                    permissao
                );
            }
        }

        public void AtualizarPermissao(UpdatePermissaoDTO permissao)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(
                    @"UPDATE Permissao
                      SET Nome = @Nome, Descricao = @Descricao, Ativo = @Ativo
                      WHERE Id = @Id",
                    permissao
                );
            }
        }

        public IEnumerable<ReadPermissaoDTO> BuscarPermissoes()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<ReadPermissaoDTO>(
                    @"SELECT Id, Nome, Descricao, DataCriacao, Ativo
                      FROM Permissao"
                );
            }
        }

        public IEnumerable<ReadPermissaoDTO> BuscarPermissoesPorIdUsuario(int idUsuario)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<ReadPermissaoDTO>(
                    @"SELECT P.Id, P.Nome, P.Descricao, P.DataCriacao, P.Ativo
                      FROM Permissao P
                      JOIN Permissao_Usuario PU ON P.Id = PU.Id_Permissao
                      WHERE PU.Id_Usuario = @IdUsuario",
                    new { IdUsuario = idUsuario }
                );
            }
        }

        public ReadPermissaoDTO BuscarPermissaoPorId(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<ReadPermissaoDTO>(
                    @"SELECT Id, Nome, Descricao, DataCriacao, Ativo
                      FROM Permissao
                      WHERE Id = @Id",
                    new { Id = id }
                );
            }
        }

        public ReadPermissaoDTO BuscarPermissaoPorNome(string nome)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<ReadPermissaoDTO>(
                    @"SELECT Id, Nome, Descricao, DataCriacao, Ativo
                      FROM Permissao
                      WHERE Nome = @Nome",
                    new { Nome = nome }
                );
            }
        }

        public void DeletarPermissao(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(
                    @"DELETE FROM Permissao
                      WHERE Id = @Id",
                    new { Id = id }
                );
            }
        }
    }
}
