using Domain.Master;

namespace Application.Master
{
    public interface IMasterServices
    {
        Task<List<AppSetting>> GetAppSettingAsync();

        Task<AppSetting> GetAppSettingByIdAsync(int id);

        Task<AppSetting> UpsertAsync(AppSetting appSetting);

        Task<bool> DeleteAsync(int id);
    }
}