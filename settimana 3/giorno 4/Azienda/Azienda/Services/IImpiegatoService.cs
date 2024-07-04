// Services/IImpiegatoService.cs
using Azienda.Models;

namespace Azienda.Services
{
    public interface IImpiegatoService
    {
        IEnumerable<Impiegato> GetImpiegati();
        Impiegato GetImpiegatoById(int id);
        void InsertImpiegato(Impiegato impiegato);
        void UpdateImpiegato(Impiegato impiegato);
        void DeleteImpiegato(int id);
    }
}
