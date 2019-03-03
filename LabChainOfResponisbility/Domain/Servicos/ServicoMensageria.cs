using System;

namespace LabChainOfResponisbility.Domain.Servicos
{
    public class ServicoMensageria : IServicoMensageria
    {
        public void EnfileirarMensagem<T>(T mensagem)
        {
            Console.WriteLine($"Enfileirando mensagem de integração do tipo: {mensagem.GetType().Name}");
        }
    }
}