namespace JBragon.Business.Interfaces
{
    public interface IBaseService<in TPrimarykey> //where TPrimarykey : class
    {
        TOutputModel Create<TOutputModel>(object inputModel);

        TOutputModel GetById<TOutputModel>(TPrimarykey Id);

        TOutputModel Update<TOutputModel>(object entity);

        void Delete(TPrimarykey id);

        bool Exist(TPrimarykey Id);
    }
}
