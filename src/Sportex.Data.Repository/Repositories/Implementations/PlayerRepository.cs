namespace Sportex.Data.Repository.Implementations
{
    using Sportex.Data.Repository.Contexts;
    using Sportex.Data.Repository.Interfaces;
    using Sportex.Data.Repository.Model;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly SportexDBContext SportexDBContext;

        public PlayerRepository(SportexDBContext SportexDBContext)
        {
            this.SportexDBContext = SportexDBContext;
        }

        public Player? GetPlayerById(int id)
        {
            if (this.SportexDBContext.Players == null)
            {
                return null;
            }

            return this.SportexDBContext.Players.First(e => e.PlayerId == id);
        }

        public IEnumerable<Player> GetAll()
        {
            return this.SportexDBContext.Players;
        }

        public IEnumerable<Player> SearchPlayers(string searchQuery)
        {
            return this.SportexDBContext.Players.Where(p => p.Username.Contains(searchQuery));
        }
    }
}