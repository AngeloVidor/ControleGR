using ControleGR.API.Domain.Enums;

namespace ControleGR.API.Application.Commands;

public record CreateCategoriaCommand(string Descricao, Finalidade Finalidade);
