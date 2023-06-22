using Application.Master;
using Application.Master.Dto;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ApiResponse;
using WebAPI.Enum;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterAPIController : ControllerBase
    {
        private readonly IMasterServices _masterServices;

        public MasterAPIController(IMasterServices masterServices)
        {
            _masterServices = masterServices;
        }

        [HttpPost("UpsertAsync")]
        public async Task<IActionResult> InsertUpdate(AppSettingVm appSettingModel)
        {
            var appSetting = await _masterServices.UpsertAsync(AppSettingVm.ConvertToDomain(appSettingModel));

            var appSettingDto = AppSettingVm.ConvertToView(appSetting);

            return Ok(ResponseModel.ResponseTemplate(StatusRespone.Success, appSettingDto));
        }

        [HttpGet("GetAppSettingByIdAsync{id:int}")]
        public async Task<IActionResult> GetAppSettingByIdAsync(int id)
        {
            var appSetting = await _masterServices.GetAppSettingByIdAsync(id);

            var appSettingDto = AppSettingVm.ConvertToView(appSetting);

            return Ok(ResponseModel.ResponseTemplate(StatusRespone.Success, appSettingDto));
        }

        [HttpGet("DeleteAsync{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDeleted = await _masterServices.DeleteAsync(id);
            return Ok(ResponseModel.ResponseTemplate(StatusRespone.Success, isDeleted));
        }

        [HttpGet("GetAppSettingsAsync")]
        public async Task<IActionResult> GetAllAppSetting()
        {
            var appSettingDto = (await _masterServices.GetAppSettingAsync()).Select(i => AppSettingVm.ConvertToView(i)).ToList();

            return Ok(ResponseModel.ResponseTemplate(StatusRespone.Success, appSettingDto));
        }
    }
}