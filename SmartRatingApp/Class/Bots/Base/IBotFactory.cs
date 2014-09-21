using System;
using SmartRatingApp.Class.Bots.Base.Const;

namespace SmartRatingApp.Class.Bots.Base
{
    public interface IBotFactory
    {
        IBotConcorrente CreateBotConcorrente(Concorrente tipo);
    }
}
