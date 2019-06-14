using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    public abstract class GameCard
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public GameCard(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public abstract void CardAction(Player player);
    }
}
