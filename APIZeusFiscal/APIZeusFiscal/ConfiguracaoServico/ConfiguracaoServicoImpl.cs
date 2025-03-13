using DFe.Classes.Entidades;
using DFe.Classes.Flags;
using DFe.Utils;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Utils;

public class ConfiguracaoServicoImpl : IConfiguracaoServico
{
  private readonly ConfiguracaoServico _configuracao;

  public ConfiguracaoServicoImpl()
  {
    _configuracao = CarregarConfiguracoes();
  }

  private ConfiguracaoServico CarregarConfiguracoes()
  {
    var caminhoArquivoCertificado = "C:\\Users\\BEETHOVEN\\Desktop\\Certificado\\02385669000174 - Fiotec#sbcm1958@.pfx";
    var config = new ConfiguracaoServico
    {
       


    Certificado =
            {
                TipoCertificado = TipoCertificado.A1ByteArray,
                Senha = "Fiotec#sbcm1958@",
                ManterDadosEmCache = false,
                ArrayBytesArquivo  = System.IO.File.ReadAllBytes(caminhoArquivoCertificado),
                Arquivo = null
               
            },
      VersaoNfeStatusServico = VersaoServico.Versao400,
      DiretorioSchemas = "C:\\Users\\BEETHOVEN\\Desktop\\Schemas",
      DiretorioSalvarXml = "C:\\Users\\BEETHOVEN\\Desktop\\SalvarXml",
      cUF = Estado.RJ,
      tpAmb = TipoAmbiente.Homologacao,
      DefineVersaoServicosAutomaticamente = false,
      ModeloDocumento = ModeloDocumento.NFe,
      VersaoLayout = VersaoServico.Versao400,
      TimeOut = 3000,
      SalvarXmlServicos = true,
      ValidarSchemas = true,
      ValidarCertificadoDoServidor = false,
      tpEmis = TipoEmissao.teNormal
    };

    return config;
  }

  public ConfiguracaoServico ObterConfiguracao() => _configuracao;
}