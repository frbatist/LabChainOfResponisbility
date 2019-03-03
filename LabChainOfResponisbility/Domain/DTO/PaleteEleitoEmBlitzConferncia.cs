using System;

namespace LabChainOfResponisbility.Domain.DTO
{
    public class PaleteEleitoEmBlitzConferncia
    {
        private Guid _idPalete;
        private string _nome;
        private decimal _percentualSorteio;

        public PaleteEleitoEmBlitzConferncia(Guid idPalete, string nome, decimal percentualSorteio)
        {
            _idPalete = idPalete;
            _nome = nome;
            _percentualSorteio = percentualSorteio;
        }
    }
}