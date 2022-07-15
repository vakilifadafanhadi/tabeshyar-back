using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace tabeshyar_back.Controllers
{
    [Route("sms")]
    [ApiController]
    public class SmallMessageSystemController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly TabeshyarDb _db;
        public SmallMessageSystemController(TabeshyarDb db)
        {
            _httpClient = new HttpClient();
            _baseUrl = "https://ippanel.com/services.jspd";
            _db = db;
        }
        [HttpPost(template:"[action]")]
        public async Task<IActionResult> Send(ModelViews.SmallMessageSystemModelView request)
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
                    _db.SmsOutboxes.Add(
                        new Models.SmsOutbox
                        {
                            CreateAt = DateTime.Now,
                            From = request.From!,
                            Receptions = rcpts!,
                            MessageId = msgId,
                            Message = request.Message!,
                            Status = status
                        });
                    _db.SaveChanges();
                    return Ok(responce);
                }
                return BadRequest(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost(template: "[action]")]
        public async Task<IActionResult> NewUnreadMessages(ModelViews.SmallMessageSystemModelView request)
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
                    return Ok(responce);
                }
                return BadRequest(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet(template:"[action]")]
        public async Task<IActionResult> Outbox() 
        {
            var result = await _db.SmsOutboxes.ToListAsync();
            return Ok(result);
        }
        [HttpGet(template: "[action]")]
        public async Task<IActionResult> Inbox()
        {
            var result = await _db.SmsInboxes.ToListAsync();
            return Ok(result);
        }
        [HttpGet(template:"[action]")]
        public async Task<IActionResult> New([FromQuery] string from, [FromQuery] string to, [FromQuery] string message)
        {
            try
            {
                _db.SmsInboxes.Add(new Models.SmsInbox
                {
                    From = from,
                    To = to,
                    Message = message
                });
                var oldLottery = _db.LatteryCodes.Where(current => current.ProductId == message).FirstOrDefault();
                var rcpts = new List<string>();
                rcpts.Add(from);
                string textMessage = "";
                if (oldLottery == null)
                    textMessage = "کد موجود نمی باشد.";
                else if (oldLottery.Owner != null)
                    textMessage = "این کد شما است: " + oldLottery.ResponceCode;
                else if (oldLottery.Owner == null)
                {
                    oldLottery.Owner = from;
                    _db.Entry(oldLottery).State = EntityState.Modified;
                    textMessage = "این کد جدید است: " + oldLottery.ResponceCode;
                }
                try
                {
                    var postData = $"op=send&uname=u-9129335812&pass=Med@0901161365&message={textMessage}&to={rcpts}&from={to}";
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
                        _db.SmsOutboxes.Add(
                            new Models.SmsOutbox
                            {
                                From = to!,
                                Receptions = receptions!,
                                MessageId = msgId,
                                Message = textMessage!,
                                Status = status
                            });
                        _db.SaveChanges();
                        return Ok(responce);
                    }
                    return BadRequest(responce);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
                _ = Send(new ModelViews.SmallMessageSystemModelView
                {
                    
                });
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
