interface IRepository<T> {
    addOrUpdate(entity:T) : T;
    find(entity:T) : T;
    query(query:string) : any
}