public abstract class RepositoryContent<T> {

    public int repositoryIndex;

    public string contentName;

    public abstract void Save ();

    public abstract void Load (T load);

    public abstract void Debug ();


}