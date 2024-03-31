using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProcessamentoController : ControllerBase
{
    private readonly ProcessamentoInteligente _processamentoInteligente;

    public ProcessamentoController(ProcessamentoInteligente processamentoInteligente)
    {
        _processamentoInteligente = processamentoInteligente;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessarEntrada([FromBody] string entrada)
    {
        if (string.IsNullOrEmpty(entrada))
        {
            return BadRequest("A entrada do usuário não pode estar vazia.");
        }

        try
        {
            var resposta = await _processamentoInteligente.ProcessarEntradaComLUIS(entrada);
            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro ao processar a entrada: {ex.Message}");
        }
    }
}