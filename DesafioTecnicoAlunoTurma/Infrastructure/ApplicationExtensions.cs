﻿using DesafioTecnicoAlunoTurma.Commons;
using DesafioTecnicoAlunoTurma.DTO.Mapping;
using DesafioTecnicoAlunoTurma.Interfaces.Repositories;
using DesafioTecnicoAlunoTurma.Interfaces.Services;
using DesafioTecnicoAlunoTurma.Repositories;
using DesafioTecnicoAlunoTurma.Services;
using System.Diagnostics.CodeAnalysis;

namespace DesafioTecnicoAlunoTurma.Infrastructure
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services, string connection)
        {
            services.AddDatabase(connection);
            services.AddRepositories();
            services.AddServices();
            services.AddDTOMapper();
        }

        private static void AddDatabase([NotNull] this IServiceCollection services, string connection)
        {
            services.AddScoped(_ => new DbContext(connection));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        private static void AddRepositories([NotNull] this IServiceCollection services)
        {
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();
        }

        private static void AddServices([NotNull] this IServiceCollection services)
        {
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IAlunoTurmaService, AlunoTurmaService>();
        }
        
        private static void AddDTOMapper([NotNull] this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        }
    }
}
