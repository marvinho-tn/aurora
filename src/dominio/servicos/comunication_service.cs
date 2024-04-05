using Aurora.Data;
using Aurora.Domain.Models;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        Dialog StartComunication(string input);
    }

    public class ComunicationService(IDialogRepository repository) : IComunicationService
    {
        private readonly IDialogRepository _repository = repository;

        public Dialog StartComunication(string input)
        {
            return _repository.AddComunicationToDialog(input);
        }
    }
}