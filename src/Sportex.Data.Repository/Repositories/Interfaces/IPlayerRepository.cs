namespace Sportex.Data.Repository.Interfaces
{
    using Sportex.Data.Repository.Model;

    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();

        Player? GetPlayerById(int id);

        IEnumerable<Player> SearchPlayers(string searchQuery);
    }
}