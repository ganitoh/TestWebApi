using MediatR;

namespace TestWebApi.Application.CQRS.Pictures.Commands.PictureCreate
{
    public class PictureCreateCommand : IRequest
    {
        public string Description { get; set; } = string.Empty;
        public string RelativePath { get; set; } = string.Empty;
        public int UserID { get; set; }

        public PictureCreateCommand(string description, string relativePath, int userID)
        {
            Description = description;
            RelativePath = relativePath;
            UserID = userID;
        }
    }
}
