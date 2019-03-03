using System;

namespace LabChainOfResponisbility.Domain.DTO
{
    public class TarefaDto
    {
        public Guid IdArmazem { get; internal set; }
        public Guid IdPalete { get; internal set; }
        public string Placa { get; internal set; }
        public string DescricaoPalete { get; internal set; }
        public string Zona { get; internal set; }
        public Guid IdEndereco { get; internal set; }
        public string NumeroDocumento { get; internal set; }
        public bool Blitz { get; set; }

        public override string ToString()
        {
            return $"Armazem: {IdArmazem}, palete: {IdPalete}, placa: {Placa}, descrição palete: {DescricaoPalete}, zona: {Zona}, endereço: {IdEndereco}, documento: {NumeroDocumento}.";
        }
    }
}