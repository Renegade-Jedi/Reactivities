using Application.Core;
using Application.Interfaces;
using Domain.Realizations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Photos
{
    public class AddRealizationPhoto
    {
        public class Command : IRequest<Result<RealizationPhoto>>
        {
            public IFormFile File { get; set; }
            public Guid RealizationId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<RealizationPhoto>>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessorRealization _photoAccessor;

            public Handler(DataContext context, IPhotoAccessorRealization photoAccessor)
            {
                _context = context;
                _photoAccessor = photoAccessor;
            }
            public async Task<Result<RealizationPhoto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var photoUploadResult = await _photoAccessor.AddPhoto(request.File);

                var photo = new RealizationPhoto
                {
                    Url = photoUploadResult.Url,
                    Id = photoUploadResult.PublicId,
                    RealizationId = request.RealizationId
                };

                _context.RealizationPhotos.Add(photo);
                var result = await _context.SaveChangesAsync() > 0;

                if (result) return Result<RealizationPhoto>.Success(photo);
                return Result<RealizationPhoto>.Failure("Problem adding photo");
            }

        }
    }
}
