using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ACPD_WebAPI.Services;

namespace ACPD_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcpdController : ControllerBase
    {
        private readonly AcpdService _service;

        public AcpdController(IConfiguration configuration)
        {
            _service = new AcpdService(configuration);
        }

        /// <summary>
        /// 新增 ACPD 使用者資料
        /// </summary>
        [HttpPost("insert")]
        public IActionResult Insert([FromBody] object json)
        {
            string jsonStr = json.ToString();
            string result = _service.ExecuteStoredProcedure("usp_ACPD_Insert", jsonStr);
            return Ok(result);
        }

        /// <summary>
        /// 更新 ACPD 使用者資料
        /// </summary>
        [HttpPost("update")]
        public IActionResult Update([FromBody] object json)
        {
            string jsonStr = json.ToString();
            string result = _service.ExecuteStoredProcedure("usp_ACPD_Update", jsonStr);
            return Ok(result);
        }

        /// <summary>
        /// 刪除 ACPD 使用者資料
        /// </summary>
        [HttpPost("delete")]
        public IActionResult Delete([FromBody] object json)
        {
            string jsonStr = json.ToString();
            string result = _service.ExecuteStoredProcedure("usp_ACPD_Delete", jsonStr);
            return Ok(result);
        }

        /// <summary>
        /// 查詢 ACPD 使用者資料
        /// </summary>
        [HttpPost("select")]
        public IActionResult Select([FromBody] object json)
        {
            string jsonStr = json.ToString();
            string result = _service.ExecuteStoredProcedure("usp_ACPD_Select", jsonStr);
            return Ok(result);
        }
    }
}
