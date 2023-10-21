using Barbearia.Dominio.Entidades;
using Barbearia.Dominio.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Infraestrutura.Repositorios
{
    public class RepositorioPagamento : IRepositorioPagamento
    {
        private HttpClient httpClient;
        public RepositorioPagamento(IConfiguration configuration)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(configuration["UrlPagamento"] ?? "")
            };

            httpClient.DefaultRequestHeaders.Add("access_token", configuration["AsaasKey"]);
        }

        public async Task<string> CriarClienteAsync(Usuario cliente)
        {
            StringContent jsonContent = new(
            JsonConvert.SerializeObject(new
            {
                name = cliente.Nome,
                cpfCnpj = cliente.Cpf
            }),
            Encoding.UTF8,
            "application/json");

            HttpResponseMessage response = await httpClient.PostAsync("v3/customers", jsonContent);

            dynamic json = JsonConvert.DeserializeObject(response?.Content?.ReadAsStringAsync()?.Result ?? "") ?? new object();

            return json?.id.ToString() ?? "";
        }

        public async Task<string> CriarCobrancaAsync(string idCliente, decimal valor)
        {
            StringContent jsonContent = new(
            JsonConvert.SerializeObject(new
            {
                customer = idCliente,
                billingType = "PIX",
                value = valor,
                dueDate = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")
            }),
            Encoding.UTF8,
            "application/json");

            HttpResponseMessage response = await httpClient.PostAsync("v3/payments", jsonContent);

            dynamic json = JsonConvert.DeserializeObject(response?.Content?.ReadAsStringAsync()?.Result ?? "") ?? new object();

            return json?.id.ToString() ?? "";
        }

        public async Task<string?> ObterClienteAsync(Usuario cliente)
        {

            HttpResponseMessage response = await httpClient.GetAsync($@"v3/customers?cpfCnpj={cliente.Cpf}");

            dynamic? json = JsonConvert.DeserializeObject(response?.Content?.ReadAsStringAsync()?.Result ?? "");

            var data = json.data;

            if (json?.data.Count == 0)
                return null;

            dynamic jsonData = JsonConvert.DeserializeObject(json.data[0].ToString() ?? "") ?? new object();

            return jsonData?.id.ToString() ?? "";
        }

        public async Task<string> ObterPixPagamentoAsync(string idCobranca)
        {

            HttpResponseMessage response = await httpClient.GetAsync($@"v3/payments/{idCobranca}/pixQrCode");

            dynamic json = JsonConvert.DeserializeObject(response?.Content?.ReadAsStringAsync()?.Result ?? "") ?? new object();

            return json?.payload.ToString() ?? "";
        }
    }
}
