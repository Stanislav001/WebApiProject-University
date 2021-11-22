using AutoMapper;
using AutoMapper.Configuration;
using Date;
using Models;
using Quartz;
using Services.Common;
using Services.Implementation;
using Services.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AppServer.ApiServices
{
    public class SchedFolderReaderJob : IJob
    {
        private ApplicationDbContext _dbContext;
        public IFilesReader Reader { get; }
        public ITransfer Transfer { get; }
        public IDatabaseTransfer Database { get; }
        public SchedFolderReaderJob(ApplicationDbContext dbContext, IFilesReader reader, ITransfer transfer, IDatabaseTransfer database)
        {
            _dbContext = dbContext;
            Reader = reader;
            Transfer = transfer;
            Database = database;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var dirFiles = Directory.GetFiles(DirectoryString.FolderDirectory);

            foreach (var item in dirFiles)
            {
                var files = Reader.FileReader(Path.Combine(DirectoryString.FolderDirectory, item)).ToList();
                var models = Transfer.ModelHandler(files);
                await Database.TransferAsync(models, item);
            }
        }
    }
}

