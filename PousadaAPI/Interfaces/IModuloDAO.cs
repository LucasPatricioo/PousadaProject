﻿using PousadaAPI.Data.DTO.Modulo;

namespace PousadaAPI.Interfaces;

public interface IModuloDAO
{
    public void InserirModulo(CreateModuloDTO modulo);
    public void AtualizarModulo(UpdateModuloDTO modulo);
    public void AtualizarPermissoesModulo(UpdatePermissaoModuloDTO permissoes);
    public IEnumerable<ReadModuloDTO> BuscarModulos();
    public ReadModuloDTO BuscarModuloPorId(int id);
    public ReadModuloDTO? BuscarModuloPorNome(string nome);
    public void DeletarModulo(int id);
}
