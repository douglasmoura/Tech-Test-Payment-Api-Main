namespace Tech_Test_Payment_Api_Main.Models.Enums
{
    public enum StatusDaVenda : ushort
    {
        AguardandoPagamento = 0,
        PagamentoAprovado = 1,
        EnviadoParaTransportadora = 2,
        Entregue = 3,
        Cancelada = 4
    }
}