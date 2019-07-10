﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.EF
{
    public class MailSenderDB : DbContext
    {
        static MailSenderDB() => Database.SetInitializer(new MigrateDatabaseToLatestVersion<MailSenderDB, Migrations.Configuration>());

        public MailSenderDB() : this("Name=MailSenderDB") { }

        public MailSenderDB(string ConnectionString) : base(ConnectionString) { }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<MailMessage> MailMessages { get; set; }

        public DbSet<Server> Servers { get; set; }

        public DbSet<RecipientsList> RecipientsLists { get; set; }

        public DbSet<SchedulerTask> SchedulerTasks { get; set; }
    }
}