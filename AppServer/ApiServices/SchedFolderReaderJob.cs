using AutoMapper;
using AutoMapper.Configuration;
using Date;
using Models;
using Quartz;
using Services.Common;
using Services.Implementation;
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
        public SchedFolderReaderJob(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            FilesReader fileReader = new FilesReader();
            var lastReadedFile = _dbContext.LastReadedFiles.OrderByDescending(x => x.LastRead);
            var fileDate = Path.GetFileNameWithoutExtension(DirectoryString.FolderDirectory);
            if (lastReadedFile.Count() == 0)
            {
                var models = fileReader.FileReader(DirectoryString.FolderDirectory).ToList();
                Transfer transfer = new Transfer();
                var data = transfer.ModelHandler(models);

            }
            else {
                var last = lastReadedFile.First().LastRead.ToShortDateString();
                if (DateTime.Parse(last) < DateTime.Parse(fileDate))
                {
                    var models = fileReader.FileReader(DirectoryString.FolderDirectory).ToList();
                    Transfer transfer = new Transfer();
                    var data = transfer.ModelHandler(models);

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Region, RegionViewModel>().ReverseMap();
                        cfg.CreateMap<Country, CountryViewModel>().ReverseMap();
                        cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
                        cfg.CreateMap<Sales, SalesViewModel>().ReverseMap();
                    });

                    var mapper = new Mapper(config);
                    DatabaseTransfer databaseTransfer = new DatabaseTransfer(new Date.ApplicationDbContext(), mapper);
                    await databaseTransfer.TransferAsync(data, fileDate);

                }
            }
        }
    }
}

