using controleEstoque.Domain.DTOs.Categoria;
using controleEstoque.Domain.DTOs.Login;
using controleEstoque.Domain.DTOs.Materiais;
using controleEstoque.Domain.DTOs.Movimentacoes;
using controleEstoque.Domain.DTOs.Usuario;
using controleEstoque.Domain.entidades;
using controleEstoque.Domain.Entidades;
using controleEstoque.Domain.Enum;
using controleEstoque.Domain.Extensions;
using controleEstoque.Infra.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Controle de Estoque",
        Version = "v1",
        Description = "API para gerenciar o controle de estoque, incluindo categorias, materiais, movimentações e usuários.",
    });

    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"<b>JWT Autorização</b> <br/> 
                          Digite 'Bearer' [espaço] e em seguida colar seu token na caixa de texto abaixo.
                          <br/> <br/>
                          <b>Exemplo:</b> 'bearer 123456abcdefg...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
    });

builder.Services.AddDbContext<EstoqueContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "gerenciamento.estoque",
        ValidAudience = "gerenciamento.estoque",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("{68a60669-f584-4470-ad36-e77cc33cfee1}"))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod() 
.AllowAnyHeader());

#region Endpoints Categoria

app.MapPost("Categoria/adicionar", (EstoqueContext context, CategoriaAdicionarDTO categoriaDTO) =>
{
    var categoria = new Categoria
    {
        Id = Guid.NewGuid(),
        Nome = categoriaDTO.Nome,

    };

    context.CategoriasSet.Add(categoria);
    context.SaveChanges();
    return Results.Created("Created", "Categoria registrada com sucesso");
}).RequireAuthorization().WithTags("Categoria");

app.MapGet("Categoria/listar", (EstoqueContext context) =>
{
    var categorias = context.CategoriasSet.Select(categoria => new CategoriaListarDTO
    {
        Id = categoria.Id,
        Nome = categoria.Nome
    }).ToList();
    return Results.Ok(categorias);
}).RequireAuthorization().WithTags("Categoria");

app.MapPut("Categoria/atualizar", (EstoqueContext context, CategoriaAtualizarDto categoriaDTO) =>
{
    var categoria = context.CategoriasSet.Find(categoriaDTO.Id);
    if (categoria == null)
    {
        return Results.NotFound("Categoria não encontrada");
    }
    categoria.Nome = categoriaDTO.Nome;
    context.SaveChanges();
    return Results.Ok("Categoria atualizada com sucesso");
}).RequireAuthorization().WithTags("Categoria");

app.MapDelete("Categoria/remover/{id:guid}", (EstoqueContext context, Guid id) =>
{
    var categoria = context.CategoriasSet.Find(id);
    if (categoria == null)
    {
        return Results.NotFound("Categoria não encontrada");
    }
    context.CategoriasSet.Remove(categoria);
    context.SaveChanges();
    return Results.Ok("Categoria removida com sucesso");
}).RequireAuthorization().WithTags("Categoria");

#endregion

#region Endpoints Materiais

app.MapPost("material/adicionar", (EstoqueContext context, MaterialAdicionarDTO materialDTO) =>
{
    var material = new Material
    {
        Id = Guid.NewGuid(),
        Nome = materialDTO.Nome,
        Descricao = materialDTO.Descricao,
        Quantidade = materialDTO.Quantidade,
        EstoqueMinimo = materialDTO.EstoqueMinimo,
        CategoriaId = materialDTO.CategoriaId,
    };
    context.MateriaisSet.Add(material);
    context.SaveChanges();
    return Results.Created("Created", "Material registrado com sucesso");
}).RequireAuthorization().WithTags("Materiais");

app.MapPut("material/atualizar", (EstoqueContext context, MaterialAtualizarDTO materialDTO) =>
{
    var material = context.MateriaisSet.Find(materialDTO.Id);
    if (material == null)
    {
        return Results.NotFound("Material não encontrado");
    }
    material.Nome = materialDTO.Nome;
    material.Descricao = materialDTO.Descricao;
    material.Quantidade = materialDTO.Quantidade;
    material.EstoqueMinimo = materialDTO.EstoqueMinimo;
    material.CategoriaId = materialDTO.CategoriaId;
    context.SaveChanges();
    return Results.Ok("Material atualizado com sucesso");
}).RequireAuthorization().WithTags("Materiais");

app.MapGet("material/listar", (EstoqueContext context) =>
{
    var materiais = context.MateriaisSet.Select(material => new MaterialListarDTO
    {
        Id = material.Id,
        Nome = material.Nome,
        Descricao = material.Descricao,
        Quantidade = material.Quantidade,
        EstoqueMinimo = material.EstoqueMinimo,
        CategoriaId = material.CategoriaId,
        Categoria = material.Categoria.Nome
    }).ToList();

    return Results.Ok(materiais);
}).RequireAuthorization().WithTags("Materiais");

app.MapDelete("material/remover/{id:guid}", (EstoqueContext context, Guid id) =>
{
    var material = context.MateriaisSet.Find(id);
    if (material == null)
    {
        return Results.NotFound("Material não encontrado");
    }
    context.MateriaisSet.Remove(material);
    context.SaveChanges();
    return Results.Ok("Material removido com sucesso");
}).RequireAuthorization().WithTags("Materiais");

#endregion

#region Endpoints Movimentacoes
// Implementar as rotas para movimentações aqui
// Exemplo de rota para adicionar movimentação
app.MapPost("movimentacao/adicionar", (EstoqueContext context, MovimentacaoAdicionarDTO movimentacaoDTO) =>
{
    var material = context.MateriaisSet.Find(movimentacaoDTO.MaterialId);
    if (material == null)
    {
        return Results.NotFound("Material não encontrado");
    }

    // Ajusta o estoque
    if (movimentacaoDTO.Tipo == EnumTipo.Entrada)
    {
        material.Quantidade += movimentacaoDTO.Quantidade;
    }
    else if (movimentacaoDTO.Tipo == EnumTipo.Saida)
    {
        if (material.Quantidade < movimentacaoDTO.Quantidade)
        {
            return Results.BadRequest("Estoque insuficiente em estoque.");
        }
        material.Quantidade -= movimentacaoDTO.Quantidade;
    }

    var movimentacao = new Movimentacoes
    {
        Id = Guid.NewGuid(),
        Data = movimentacaoDTO.Data,
        Quantidade = movimentacaoDTO.Quantidade,
        Tipo = movimentacaoDTO.Tipo,
        MaterialId = movimentacaoDTO.MaterialId,
    };

    context.MovimentacoesSet.Add(movimentacao);
    context.SaveChanges();
    return Results.Created("Created", "Movimentação registrada com sucesso");
}).RequireAuthorization().WithTags("Movimentacoes");

app.MapGet("movimentacao/listar", (EstoqueContext context) =>
{
    var movimentacoes = context.MovimentacoesSet.Select(movimentacao => new MovimentacaoListarDTO
    {
        Id = movimentacao.Id,
        Data = movimentacao.Data,
        Quantidade = movimentacao.Quantidade,
        Tipo = movimentacao.Tipo,
        Material = movimentacao.Material.Nome
    }).ToList();
    return Results.Ok(movimentacoes);
}).RequireAuthorization().WithTags("Movimentacoes");

app.MapGet("movimentacao/listar/{id:guid}", (EstoqueContext context, Guid id) =>
{
var movimentacao = context.MovimentacoesSet
    .Where(m => m.Id == id)
    .Select(m => new MovimentacaoListarDTO
    {
        Id = m.Id,
        Data = m.Data,
        Quantidade = m.Quantidade,
        Tipo = m.Tipo,
        Material = m.Material.Nome
    }).FirstOrDefault();
if (movimentacao == null)
{
    return Results.NotFound("Movimentação não encontrada");
}
return Results.Ok(movimentacao);
}).RequireAuthorization().WithTags("Movimentacoes");

#endregion

#region Endpoints Usuario

app.MapPost("usuario/adicionar", (EstoqueContext context, UsuarioAdicionarDTO usuarioDTO) =>
{
    var usuario = new Usuario
    {
        Id = Guid.NewGuid(),
        Nome = usuarioDTO.Nome,
        Email = usuarioDTO.Email,
        Senha = usuarioDTO.Senha.EncryptPassword()
    };
    context.UsuariosSet.Add(usuario);
    context.SaveChanges();
    return Results.Created("Created", "Usuário registrado com sucesso");
}).RequireAuthorization().WithTags("Usuário");

app.MapGet("usuario/listar", (EstoqueContext context) =>
{
    var usuarios = context.UsuariosSet.Select(usuario => new UsuarioListarDTO
    {
        Id = usuario.Id,
        Nome = usuario.Nome,
        Email = usuario.Email
    }).ToList();
    return Results.Ok(usuarios);
}).RequireAuthorization().WithTags("Usuário");

app.MapPut("usuario/atualizar", (EstoqueContext context, UsuarioAtualizarDTO usuarioDTO) =>
{
    var usuario = context.UsuariosSet.Find(usuarioDTO.Id);
    if (usuario == null)
    {
        return Results.NotFound("Usuário não encontrado");
    }
    usuario.Nome = usuarioDTO.Nome;
    usuario.Email = usuarioDTO.Email;
    context.SaveChanges();
    return Results.Ok("Usuário atualizado com sucesso");
}).RequireAuthorization().WithTags("Usuário");

app.MapDelete("usuario/remover/{id:guid}", (EstoqueContext context, Guid id) =>
{
    var usuario = context.UsuariosSet.Find(id);
    if (usuario == null)
    {
        return Results.NotFound("Usuário não encontrado");
    }
    context.UsuariosSet.Remove(usuario);
    context.SaveChanges();
    return Results.Ok("Usuário removido com sucesso");
}).RequireAuthorization().WithTags("Usuário");
#endregion

#region Endpoints Segurança

app.MapPost("autenticar", (EstoqueContext context, LoginDto loginDto) =>
{
    var usuario = context.UsuariosSet.FirstOrDefault(p => p.Email == loginDto.Email && p.Senha == loginDto.Senha.EncryptPassword());
    if (usuario is null)
        return Results.BadRequest("Usuário ou Senha Inválidos!");

    var claims = new[]
    {
        new Claim("Id", usuario.Id.ToString()),
        new Claim("Nome", usuario.Nome),
        new Claim("Email", usuario.Email),
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("{68a60669-f584-4470-ad36-e77cc33cfee1}"));

    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
        issuer: "gerenciamento.estoque",
        audience: "gerenciamento.estoque",
        claims: claims,
        expires: DateTime.Now.AddHours(3),
        signingCredentials: creds);

    return Results.Ok(
    new JwtSecurityTokenHandler()
    .WriteToken(token));
}).WithTags("Segurança");


#endregion
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();