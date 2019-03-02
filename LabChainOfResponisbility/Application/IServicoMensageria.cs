namespace LabChainOfResponisbility.Application
{
    public interface IServicoMensageria
    {
        void EnfileirarMensagem(PaleteEleitoEmBlitzConferncia palletElectedBlitzEvent);
        void EnfileirarMensagem(PaleteEstaConforme paleteEstaConforme);
    }
}