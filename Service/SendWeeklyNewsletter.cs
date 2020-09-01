using Coravel.Invocable;
using Data.UnitOfWork;
using Microsoft.Extensions.Logging;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SendWeeklyNewsletter : IInvocable
    {
        private IEmailSender _emailSender;
        private IUnitOfWork _uw;
        public SendWeeklyNewsletter(IEmailSender emailSender, IUnitOfWork uw)
        {
            _emailSender = emailSender;
            _uw = uw;
        }

        public async Task Invoke()
        {
            //var users = _uw.BaseRepository<Newsletter>().FindByConditionAsync(l => l.IsActive == true).Result.ToList();
            //string emailContent = await _uw.NewsRepository.GetWeeklyNewsAsync();
            //if (emailContent!="")
            //{
            //    foreach (var item in users)
            //        await _emailSender.SendEmailAsync(item.Email, "خبرنامه هفتگی ,emailContent );
            //} 
        }
    }
}
