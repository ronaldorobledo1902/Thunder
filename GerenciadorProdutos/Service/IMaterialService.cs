using GerenciadorMaterial.Domain;

namespace GerenciadorMaterial.Api.Service
{
    public interface IMaterialService 
    {
        Task<Boolean> MaterialInserir(Material material);
        Task<Boolean> MaterialDeletar(Material material);
        Task<Material> MaterialObter(Material material);
        Task<List<Material>> MaterialObterTodos();
        Task<Boolean> MaterialAtualizar(Material material);

    }
}
