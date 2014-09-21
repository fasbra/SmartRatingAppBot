using SmartRatingApp.Class.Bots.Base.Const;
using SmartRatingApp.Class.Bots.Impl;

namespace SmartRatingApp.Class.Bots.Base.Impl
{
    public class BotFactory : IBotFactory
    {
        public IBotConcorrente CreateBotConcorrente(Concorrente tipo)
        {
            IBotConcorrente botConcorrente = null;
            switch (tipo)
            {
                case Concorrente.PontoFrio:
                    botConcorrente = new PontoFrioBot();
                    break;
            }

            return botConcorrente;
        }
    }
}
