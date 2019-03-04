namespace LabChainOfResponisbility.Domain.Servicos
{
    public interface ICriacaoTarefaFactory
    {
        ICriacaoTarefaHandler ObterHandler();
    }
}