﻿using PousadaAPI.Data.DTO.Permissoes;

namespace PousadaAPI.Interfaces
{
    public interface IPermissaoService
    {
        public void InserirPermissao(CreatePermissaoDTO permissao);
        public void AtualizarPermissao(UpdatePermissaoDTO permissao);
        public IEnumerable<ReadPermissaoDTO> BuscarPermissoes();
        public ReadPermissaoDTO BuscarPermissaoPorId(int id);
        public void DeletarPermissao(int id);
    }
}