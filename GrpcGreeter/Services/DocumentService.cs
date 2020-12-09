using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
namespace DocumentService
{
    public class GrpcCrudService : DocumentService.DocumentServiceBase
    {
        private readonly List<Document> _documents = new List<Document>();
        private int idCount = 0;
        private readonly ILogger<GrpcCrudService> _logger;
        public GrpcCrudService(ILogger<GrpcCrudService> logger)
        {
            _logger = logger;
            _documents.Add(new Document()
            {
                DocumentId = idCount++,
                DocumentName = "test doc"
            });
        }
        public override Task<Documents> GetDocument(Empty empty, ServerCallContext context)
        {
            Documents pl = new Documents();
            pl.Items.AddRange(_documents);
            return Task.FromResult(pl);
        }
    }
}