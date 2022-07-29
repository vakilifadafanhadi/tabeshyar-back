using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using tabeshyar_back.Repositories;
using tabeshyar_back.ModelViews;

namespace tabeshyar_back.Controllers
{
    [Route("sms")]
    [ApiController]
    public class SmallMessageSystemController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public SmallMessageSystemController(IRepositoryWrapper repositoryWrapper)
        {
            _httpClient = new HttpClient();
            _baseUrl = "https://ippanel.com/services.jspd";
            _repositoryWrapper = repositoryWrapper;
        }
        [HttpPost(template:"[action]")]
        public async Task<IActionResult> Send(SmallMessageSystemModelView request)
        {
            try
            {
                var rcpts = JsonSerializer.Serialize(request.To);
                var postData = $"op={request.Op}&uname={request.Uname}&pass={request.Pass}&message={request.Message}&to={rcpts}&from={request.From}";
                var content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
                var result = await _httpClient.PostAsync(_baseUrl, content);
                var responce = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    string resp = responce.Replace("\"", "\'");
                    resp = responce.Replace("[", "");
                    resp = resp.Replace("]", "");
                    string[] res = resp.Split('\u002C');
                    int status = 0;
                    int msgId = 0;
                    try
                    {
                        status = int.Parse(res[0]);
                        msgId = int.Parse(res[1]);
                    }
                    catch
                    {
                    }
                    var newOutBox = await _repositoryWrapper.SmsOutboxRepository.CreateAsync(
                        new SmsOutboxDto
                        {
                            From = request.From!,
                            Receptions = rcpts!,
                            MessageId = msgId,
                            Message = request.Message!,
                        });
                    await _repositoryWrapper.SaveAsync();
                    return Ok(responce);
                }
                return BadRequest(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet(template:"[action]/{pageNumber}/{take}")]
        public async Task<IActionResult> Outbox([FromRoute] int pageNumber, [FromRoute] int take) 
        {
            var result = new SmsOutboxPagination
            {
                Count = await _repositoryWrapper.SmsOutboxRepository.CountAsync(),
                Data = await _repositoryWrapper.SmsOutboxRepository.GetPaginationAsync(pageNumber, take)
            };
            return Ok(result);
        }
        [HttpGet(template: "[action]/{pageNumber}/{take}")]
        public async Task<IActionResult> Inbox([FromRoute] int pageNumber, [FromRoute] int take)
        {
            var result = new SmsInboxPagination
            {
                Data = await _repositoryWrapper.SmsInboxRepository.GetPaginationAsync(pageNumber, take),
                Count = await _repositoryWrapper.SmsInboxRepository.CountAsync()
            };
            return Ok(result);
        }
        [HttpGet(template:"[action]")]
        public async Task<IActionResult> New([FromQuery] string from, [FromQuery] string to, [FromQuery] string message)
        {
            try
            {
                var newSmsInbox = await _repositoryWrapper.SmsInboxRepository.CreateAsync(
                    new SmsInboxDto
                    {
                        From = from,
                        To = to,
                        Message = message
                    });
                var oldLottery = await _repositoryWrapper.LatteryCodeRepository.FindByProductIdAsync(message);
                var rcpts = new List<string>
                {
                    from
                };
                string textMessage = "";
                if (oldLottery == null)
                    textMessage = "کد موجود نمی باشد.";
                else if (oldLottery.Owner != null && oldLottery.Owner == from)
                    textMessage = "این کد شما است: " + oldLottery.ResponceCode;
                else if (oldLottery.Owner != null && oldLottery.Owner != from)
                    textMessage = "این کد استفاده شده است.";
                else if (oldLottery.Owner == null)
                {
                    oldLottery.Owner = from;
                    var newLatteryCode = await _repositoryWrapper.LatteryCodeRepository.UpdateAsync(oldLottery);
                    var count = await _repositoryWrapper.LatteryCodeRepository.CountCurrentLatteryOwnersAsync(oldLottery.LatteryName);
                    textMessage = $"این کد جدید است:  {oldLottery.ResponceCode}\n تا کنون {count} نفر در قرعه کشی شرکت کرده اند.";
                }
                string To = JsonSerializer.Serialize(rcpts);
                try
                {
                    var postData = $"op=send&uname=u-9129335812&pass=Med@0901161365&message={textMessage}&to={To}&from=3000505";
                    var content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
                    var result = await _httpClient.PostAsync(_baseUrl, content);
                    var responce = await result.Content.ReadAsStringAsync();
                    if (result.IsSuccessStatusCode)
                    {
                        string resp = responce.Replace("\"", "\'");
                        resp = responce.Replace("[", "");
                        resp = resp.Replace("]", "");
                        string[] res = resp.Split('\u002C');
                        int status = 0;
                        int msgId = 0;
                        try
                        {
                            status = int.Parse(res[0]);
                            msgId = int.Parse(res[1]);
                        }
                        catch
                        {
                        }
                        string receptions = JsonSerializer.Serialize(rcpts);
                        var newOutbox = await _repositoryWrapper.SmsOutboxRepository.CreateAsync(
                            new SmsOutboxDto
                            {
                                From = "3000505",
                                Receptions = receptions!,
                                MessageId = msgId,
                                Message = textMessage!,
                            });
                        await _repositoryWrapper.SaveAsync();
                        return Ok(responce);
                    }
                    return BadRequest(responce);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet(template:"[action]")]
        public async Task<IActionResult> GetContactsList()
        {
            try
            {
                return Ok(await _repositoryWrapper.SmsInboxRepository.GetContactsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

    }
}
