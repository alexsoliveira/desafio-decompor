using Desafio.Decompor.Business.Notificacoes;

namespace Desafio.Decompor.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
