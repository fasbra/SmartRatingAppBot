using SmartRatingApp.Class.Bots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRatingApp.Class
{
    public class BotFactory
    {
        public static IBotConcorrente CreateBot(int idConcorrente)
        {
            IBotConcorrente botConcorrente = null;
            switch (idConcorrente)
            {
                case 1:
                    botConcorrente = new PontoFrio();
                    break;
                case 2:
                    botConcorrente = new Kabum();
                    break;
            }

            return botConcorrente;
        }
    }
}
