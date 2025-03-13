using CTe.Classes.Servicos.Tipos;
using DFe.Classes.Entidades;
using DFe.Classes.Flags;
using DFe.Utils;
using Microsoft.AspNetCore.Mvc;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Servicos.Tipos;
using NFe.Servicos;
using NFe.Utils;

namespace APIZeusFiscal.Controllers
{
  [ApiController]
  [Route("api/nfe")]
  public class ZeusController : ControllerBase
  {
    private readonly IConfiguracaoServico _configuracaoServico;

    public ZeusController(IConfiguracaoServico configuracaoServico)
    {
      _configuracaoServico = configuracaoServico;
    }

    [HttpGet("consultarStatusServico")]
    public IActionResult ConsultarStatusServico() 
    {
      //var configuracao = CarregarConfiguracoes();
      //var caminhoArquivoCertificado = "C:\\Users\\BEETHOVEN\\Desktop\\Certificado\\02385669000174 - Fiotec#sbcm1958@.pfx";

      //if (!string.IsNullOrWhiteSpace(caminhoArquivoCertificado))
      //{
      //  configuracao.Certificado.ArrayBytesArquivo = System.IO.File.ReadAllBytes(caminhoArquivoCertificado);
      //  configuracao.Certificado.Arquivo = null;
      //}
      var config = _configuracaoServico;
      var servicoNFe = new ServicosNFe(config.ObterConfiguracao());
      var retornoConsulta = servicoNFe.NfeStatusServico();

      return Ok(retornoConsulta.Retorno);
    }

    [HttpGet("nfeDistribuicaoDfe")]
    public IActionResult NfeDistribuicaoDfe(string ufAutor, string cpfCnpj, string ultNSU = "0", string nSU = "0", string chNFE = "")
    {

      var config = _configuracaoServico.ObterConfiguracao();
      config.VersaoNfeStatusServico = VersaoServico.Versao310;
      config.VersaoNFeDistribuicaoDFe = VersaoServico.Versao100;
      config.VersaoLayout = VersaoServico.Versao310;
      config.tpEmis = TipoEmissao.teNormal;


      var servicoNFe = new ServicosNFe(config);

      var resultadoRetorno = servicoNFe.NfeDistDFeInteresse(ufAutor, cpfCnpj, ultNSU, nSU, chNFE);

      return Ok(resultadoRetorno);
    }

    [HttpGet("manifestacaoDestinatario")]
    public IActionResult ManifestacaoDestinatario(int idlote, int sequenciaEvento, string chaveNFe, 
                                                  NFeTipoEvento nFeTipoEventoManifestacaoDestinatario, string cpfcnpj,
                                                  string justificativa = null, DateTimeOffset? dhEvento = null)
    {

      var config = _configuracaoServico.ObterConfiguracao();
      config.VersaoNfeStatusServico = VersaoServico.Versao310;
      config.VersaoNFeDistribuicaoDFe = VersaoServico.Versao100;
      config.VersaoLayout = VersaoServico.Versao310;
      config.tpEmis = TipoEmissao.teNormal;


      var servicoNFe = new ServicosNFe(config);

      //var resultadoRetorno = servicoNFe.RecepcaoEventoManifestacaoDestinatario(int.Parse(idlote), int.Parse(sequenciaEvento), chave, (NFeTipoEvento)int.Parse(codigoEvento), cnpj, justificativa);

      return Ok();
    }


    //private ConfiguracaoServico CarregarConfiguracoes()
    //{
    //  var config = new ConfiguracaoServico();

    //  config.Certificado.TipoCertificado = TipoCertificado.A1ByteArray;
    //  config.Certificado.Senha = "Fiotec#sbcm1958@";
    //  config.Certificado.ManterDadosEmCache = false;
    //  config.VersaoNfeStatusServico = VersaoServico.Versao400;

    //  config.DiretorioSchemas = "C:\\Users\\BEETHOVEN\\Desktop\\Schemas";
    //  config.DiretorioSalvarXml = "C:\\Users\\BEETHOVEN\\Desktop\\SalvarXml";
    //  config.cUF = Estado.RJ;
    //  config.tpAmb = TipoAmbiente.Homologacao;
    //  config.DefineVersaoServicosAutomaticamente = false;
    //  config.ModeloDocumento = ModeloDocumento.NFe;
    //  config.VersaoLayout = VersaoServico.Versao400;
    //  config.TimeOut = 3000;
    //  config.SalvarXmlServicos = true;
    //  config.ValidarSchemas = true;
    //  config.ValidarCertificadoDoServidor = false;
    //  config.tpEmis = TipoEmissao.teNormal;




    //  return config;
    //}

  }
}
