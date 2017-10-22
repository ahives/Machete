namespace Machete
{
    using System.IO;
    using System.Threading.Tasks;


    public interface IFormatter<TSchema>
        where TSchema : Entity
    {
        Task<FormatResult<TSchema>> FormatAsync(Stream output, EntityResult<TSchema> input);
    }
    
    public interface IFormatter<TSchema, TLayout>
        where TSchema : Entity
        where TLayout : Layout
    {
        Task<FormatResult<TSchema>> FormatAsync(Stream output, LayoutList<TLayout> input);
    }
}