using System;

namespace LabChainOfResponisbility.Application
{
    public class PaleteEstaConforme
    {
        private Guid idPalete;
        private Guid idArmazem;
        private string numeroDocumento;
        private string placa;
        private string descricaoPalete;
        private string zona;
        private Guid idEndereco;

        public PaleteEstaConforme(Guid idPalete, Guid idArmazem, string numeroDocumento, string placa, string descricaoPalete, string zona, Guid idEndereco)
        {
            this.idPalete = idPalete;
            this.idArmazem = idArmazem;
            this.numeroDocumento = numeroDocumento;
            this.placa = placa;
            this.descricaoPalete = descricaoPalete;
            this.zona = zona;
            this.idEndereco = idEndereco;
        }
    }
}