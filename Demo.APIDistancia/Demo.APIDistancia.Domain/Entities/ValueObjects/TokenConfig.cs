namespace Demo.APIDistancia.Domain.ValueObjects
{
    public class TokenConfig
    {
        public string Audiencia { get; set; }
        public string Emissor { get; set; }
        public int Segundos { get; set; }
    }
}
