namespace LabChainOfResponisbility.Domain.Servicos
{
    public interface IServicoMensageria
    {
        void EnfileirarMensagem<T>(T mensagem);        
    }
}