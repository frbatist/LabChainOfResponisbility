namespace LabChainOfResponisbility.Application
{
    public class ResultadoBliz
    {
        public bool Eleito { get; set; }
        public decimal PercentualSorteio { get; internal set; }
        public string Nome { get; internal set; }
    }
}