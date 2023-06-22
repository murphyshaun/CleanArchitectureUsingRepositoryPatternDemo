using Application.Common.Interface;
using Domain.Master;
using Microsoft.EntityFrameworkCore;

namespace Application.Master
{
    public class MasterServices : IMasterServices
    {
        #region Fields

        private IUnitOfWork _unitOfWork;

        #endregion Fields

        #region Constructor

        public MasterServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region Commands

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var isDeleted = await _unitOfWork.AppSettingRepository.Delete(id);
                await _unitOfWork.SaveAsync();
                return isDeleted;
            }
            catch (Exception)
            {
                //handle exception
                throw;
            }
        }

        public async Task<AppSetting> UpsertAsync(AppSetting appSetting)
        {
            try
            {
                if (appSetting.Id > 0) _unitOfWork.AppSettingRepository.Update(appSetting);
                else _unitOfWork.AppSettingRepository.Add(appSetting);

                await _unitOfWork.SaveAsync();

                return appSetting;
            }
            catch (Exception)
            {
                //handle exception
                throw;
            }
        }

        #endregion Commands

        #region Queries

        public async Task<List<AppSetting>> GetAppSettingAsync()
        {
            var appSettings = await _unitOfWork.AppSettingRepository
                .TableNoTracking
                .OrderBy(t => t.ReferenceKey)
                .ToListAsync();

            return appSettings;
        }

        public async Task<AppSetting> GetAppSettingByIdAsync(int id)
        {
            try
            {
                var appSetting = await _unitOfWork.AppSettingRepository.Get(id);
                return appSetting;
            }
            catch (Exception)
            {
                //handle exception
                throw;
            }
        }

        #endregion Queries
    }
}