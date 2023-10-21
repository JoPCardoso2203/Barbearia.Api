using Barbearia.Infraestrutura.Repositorios;
using Barbearia.Dominio.Interfaces;
using Barbearia.Dominio.Servicos;

namespace Barbearia.Api.Configuracoes
{
    public static class InjecaoDependencia
    {
        public static void AddInjecaoDependencia(this IServiceCollection services)
        {
            services.AddScoped<IRepositorioBase, RepositorioBase>();

            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddScoped<IRepositorioBarbearia, RepositorioBarbearia>();
            services.AddScoped<IRepositorioAgendamento, RepositorioAgendamento>();
            services.AddScoped<IRepositorioPagamento, RepositorioPagamento>();

            services.AddScoped<IServicoAgendamento, ServicoAgendamento>();
            services.AddScoped<IServicoBarbearia, ServicoBarbearia>();
            services.AddScoped<IServicoUsuario, ServicoUsuario>();
            services.AddScoped<IServicoPagamento, ServicoPagamento>(); 
        }
    }
}
