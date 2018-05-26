using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechChallengeIgor.Test
{
    [TestClass]
    public class WebApiTest
    {
        private readonly IContainer container;
        public WebApiTest()
        {
            container = ContainerConfig.Configure();
        }
        [TestMethod]
        public async Task ConsultaArquivosWebApiTestAsync()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var usuario = await TestHelper.LogarAPIAsync();

                var baseAddress = new Uri("http://cloud02.prima.net.br:26074");
                
                using (var client = new HttpClient() { BaseAddress = baseAddress })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("token", "123");
                    cookieContainer.Add(baseAddress, new Cookie("ASP.NET_SessionId", usuario.CookieSistema));

                    var response = await client.GetAsync($"sg_mobile/ClienteService.svc/GetListaArquivosAluno?codigo={55}&datainicial=01/01/2016&dataFinal=31/12/2018&qc=0&turma=0");

                    var json = await response.Content.ReadAsStringAsync();
                    IList<DisciplinaArquivo> arquivos = JsonConvert.DeserializeObject<IList<DisciplinaArquivo>>(await response.Content.ReadAsStringAsync());

                    Assert.AreNotEqual(0, arquivos.Count);
                }
            }
        }
    }
}
