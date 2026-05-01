using CasosDeUsos.InterfacesCU.AuditoriaCU;
using CasosDeUsos.InterfacesCU.EquipoCU;
using CasosDeUsos.InterfacesCU.MetodoDePagoCU;
using CasosDeUsos.InterfacesCU.PagoCU;
using CasosDeUsos.InterfacesCU.TipoDeGastoCU;
using CasosDeUsos.InterfacesCU.UsuarioCU;
using LogicaDeAccesoADatos;
using LogicaDeAccesoADatos.Repositorios;
using LogicaDeAplicacion.CasosDeUso.CUAuditoria;
using LogicaDeAplicacion.CasosDeUso.CUEquipo;
using LogicaDeAplicacion.CasosDeUso.CULogin;
using LogicaDeAplicacion.CasosDeUso.CUMetodoDePago;
using LogicaDeAplicacion.CasosDeUso.CUPago;
using LogicaDeAplicacion.CasosDeUso.CUTiposDeGasto;
using LogicaDeAplicacion.CasosDeUso.CUUsuario;
using LogicaDeNegocio.InterfacesDeRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<ICULoginDeUsuario, CULoginDeUsuario>();
            builder.Services.AddScoped<IRepositorioPago, RepositorioPagoEF>();
            builder.Services.AddScoped<ICUBuscarPago, CUBuscarPago>();
            builder.Services.AddScoped<ICUGetPagosUsuarioByMail, CUGetPagosUsuarioByMail>();
            builder.Services.AddScoped<IRepositorioTipoDeGasto, RepositorioTipoDeGastoEF>();
            builder.Services.AddScoped<ICUModificarContrasenia, CUModificarContrasenia>();
            builder.Services.AddScoped<ICUListarUsuarios, CUListarUsuarios>();
            builder.Services.AddScoped<ICUFiltrarPagoPorMonto, CUFiltrarPagoPorMonto>();
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipoEF>();
            builder.Services.AddScoped<ICUListarEquipo, CUListarEquipo>();
            builder.Services.AddScoped<ICUFiltrarPagoUnicoPorMonto, CUFiltrarPagoUnicoPorMonto>();
            builder.Services.AddScoped<ICUAgregarPago, CUAgregarPago>();
            builder.Services.AddScoped<ICUListadoTipoDeGasto, CUListadoTipoDeGasto>();
            builder.Services.AddScoped<ICUObtenerEnum, CUObtenerMetodosDePago>();
            builder.Services.AddScoped<ICUListarAuditoria, CUListarAuditoria>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoriaEF>();


            ////Comienza JWT////
            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            //Para probar token desde Swagger

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Ingrese el token JWT con la palabra Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
});
            });

            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //-------------------------------------------------------

            string conexion = builder.Configuration.GetConnectionString("CadenaConexion");
            builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(conexion));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
