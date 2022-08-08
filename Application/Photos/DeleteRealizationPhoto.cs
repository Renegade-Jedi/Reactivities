using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using MediatR;
using Persistence;


namespace Application.Photos
{
    public class DeleteRealizationPhoto
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessorRealization _photoAccessor;
            public Handler(DataContext context, IPhotoAccessorRealization photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var realizationPhoto = await _context.RealizationPhotos.FindAsync(request.Id);
                if (realizationPhoto == null) return null;

                var result = await _photoAccessor.DeletePhoto(request.Id);
                if (result == null) return Result<Unit>.Failure("Problem deleting photo from Cloudinary");

                _context.Remove(realizationPhoto);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Problem deleting photo from API");
            }
        }
    }
}
