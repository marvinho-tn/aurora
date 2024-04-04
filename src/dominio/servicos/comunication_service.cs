using Aurora.Data;
using Aurora.Domain.Models;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        List<Dialog> StartComunication(string input);
    }

    public class ComunicationService(IDialogRepository repository) : IComunicationService
    {
        private readonly IDialogRepository _repository = repository;

        public List<Dialog> StartComunication(string input)
        {
            _repository.AddComunicationToDialog(input);
            
            return _repository.GetDialogs();
        }
    }
}