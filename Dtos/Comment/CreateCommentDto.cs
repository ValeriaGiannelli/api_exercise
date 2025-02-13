namespace api.Dtos.Comment
{
    //quando si crea un commento ho solo bisogno di due elementi
    public class CreateCommentDto
    {
        public string Title { get; set; } = string.Empty; //titolo
        public string Content { get; set; } = string.Empty; //contenuto
    }
}
