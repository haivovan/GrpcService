using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcGreeter.DatabaseHelper;
using Microsoft.Extensions.Logging;
namespace DocumentService
{
    public class GrpcCrudService : DocumentService.DocumentServiceBase
    {
        private readonly ILogger<GrpcCrudService> _logger;
        public GrpcCrudService(ILogger<GrpcCrudService> logger)
        {
            _logger = logger;
        }
        public override Task<Documents> GetDocument(Empty empty, ServerCallContext context)
        {
            Documents pl = new Documents();
            DocumentDapper documentDapper = new DocumentDapper();
            var result = documentDapper.GetDocument();
            pl.Items.AddRange(result);
            return Task.FromResult(pl);
        }
    }
}