using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Classes
{
    public interface ICardContainer
    {
        List<Card> Cards { get; }
    }
}
