using GerenciadorMaterial.Domain;
using GerenciadorMaterial.Infra.Repositorio.Interface;

namespace GerenciadorMaterial.Api.Service
{
    public class MaterialService : IMaterialService
    {
        public readonly IMaterialRepositorio _materialRepositorio;

        public MaterialService(IMaterialRepositorio materialRepositorio)
        {
            _materialRepositorio = materialRepositorio;
        }

        public async Task<Boolean> MaterialInserir(Material material)
        {
            await _materialRepositorio.AddAsync(material);
            return true;
        }

        public async Task<Boolean> MaterialAtualizar (Material material)
        {
            await _materialRepositorio.UpdateAsync(material);
            return true;
        }


        public async Task<Boolean> MaterialDeletar(Material material)
        {
            await _materialRepositorio.DeleteAsync(material);
            return true;
        }

        public async Task<Material> MaterialObter(Material material)
        {
            var matrial = await _materialRepositorio.GetSingleOrDefaultAsync(material);
            return material;
        }

        public async Task<List<Material>> MaterialObterTodos()
        {
            var matriallist = await _materialRepositorio.GetAllAsync();
            return matriallist;
        }

    }
}
