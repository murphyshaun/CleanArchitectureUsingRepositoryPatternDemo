using Application.Master.Dto;
using Domain.Master;

namespace Application.Common.Mapping
{
    public static class ManualViewMapping
    {
        //TO-DO: use Automaper
        public static AppSetting ConvertToModel(this AppSettingVm appSettingVm)
        {
            if (appSettingVm == null)
                return null;

            var appSetting = new AppSetting
            {
                Id = appSettingVm.Id,
                ReferenceKey = appSettingVm.ReferenceKey,
                Value = appSettingVm.Value,
                Description = appSettingVm.Description,
                Type = appSettingVm.Type,
            };
            return appSetting;
        }
    }
}