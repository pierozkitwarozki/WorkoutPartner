using MediatR;
using WorkoutPartner.Application.Commands;

namespace WorkoutPartner.Infrastructure.Handlers.Commands;

public class SignInCommandHandler : IRequestHandler<SignInCommand>
{
    public async Task Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(15000, cancellationToken);
    }
}