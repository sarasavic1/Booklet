using Booklet.Application;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Implementation.Logging
{
    public class UseCaseLogger : IUseCaseLogger
    {
        private readonly BookletContext _context;
        public UseCaseLogger(BookletContext context){
            _context = context;

        }
        public void Log(IUseCase userCase, IApplicationActor actor, object useCaseData)
        {
            var actorDataBase = _context.Users.Find(actor.Id);

            if (actorDataBase != null)
            {
                var log = new AuditLog
                {
                    LogDate = DateTime.Now,
                    UserId = actor.Id,
                    UseCaseId = userCase.Id,
                    UseCaseName = userCase.Name
                };


                _context.AuditLogs.Add(log);
                _context.SaveChanges();
            }
            
        }
    }
}
