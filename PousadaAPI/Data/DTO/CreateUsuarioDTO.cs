﻿namespace PousadaAPI.Data.DTO;

public class CreateUsuarioDTO
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public DateTime DataNascimento { get; set; }
}
