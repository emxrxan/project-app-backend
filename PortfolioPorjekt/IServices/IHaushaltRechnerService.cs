using PortfolioPorjekt.Resources;

namespace PortfolioPorjekt.IServices
{
    public interface IHaushaltRechnerService
    {
        Task<IEnumerable<HaushaltRechnerResource>> getAll();

        Task<HaushaltRechnerResource> Create(HaushaltRechnerResource neuHaushaltRechner);
        Task<HaushaltRechnerResource> Update(int id, HaushaltRechnerResource updateHaushaltRechner);
        Task<string> Delete(int id);
    }
}
