using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PTCApi.Controllers {
  public class AppControllerBase : ControllerBase {
    protected void SimulateLongRunning() {
      System.Threading.Thread.Sleep(1500);
    }

    protected IActionResult HandleException(Exception ex,
                                            string msg) {
      IActionResult ret;

      // Create new exception with generic message        
      ret = StatusCode(
          StatusCodes.Status500InternalServerError,
              new Exception(msg, ex));

      return ret;
    }
  }
}
